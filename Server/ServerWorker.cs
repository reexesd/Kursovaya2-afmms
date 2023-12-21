using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using NamedPipeLib;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;

namespace Server
{
    internal static class ServerWorker
    {
        #region Private static fields

        private static readonly string _registredUsersInfoPath = @"DB/RegistredUsers.json";

        private static List<User> _users = new List<User>();

        private static readonly Dictionary<string, MailBox> _mailBoxes = new Dictionary<string, MailBox>();

        private static NamedPipeServer _server;

        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        #endregion

        #region Events

        internal static event EventHandler<User> NewUserRegistred;

        internal static event EventHandler<User> UserInfoUpdated;

        internal static event EventHandler<Message> MessageSentRequired;

        internal static event EventHandler<Message> MessageProcessingStarted;

        internal static event EventHandler<string> MessageProcessingFailed;

        internal static event EventHandler<Message> MessageProcessingCompleted;

        #endregion

        #region C'tor

        static ServerWorker()
        {
            InitDB();
        }

        #endregion

        #region Events Invokers
        
        private static void OnNewUserRegistred(User user)
        {
            NewUserRegistred?.Invoke(null, user);
        }

        private static void OnMessageSentRequired(Message message)
        {
            MessageSentRequired?.Invoke(null, message);
        }

        private static void OnMessageProcessingStarted(Message message)
        {
            MessageProcessingStarted?.Invoke(null, message);
        }

        private static void OnUserInfoUpdated(User user)
        {
            UserInfoUpdated?.Invoke(null, user);
        }

        private static void OnMessageProcessingCompleted(Message message)
        {
            MessageProcessingCompleted?.Invoke(null, message);
        }

        private static void OnMessageProcessingFailed(string message)
        {
            MessageProcessingFailed?.Invoke(null, message);
        }

        #endregion

        #region Internal Methods

        internal static List<User> GetUsersList()
        {
            return _users;
        }

        internal static void StartServer()
        {
            _server = new NamedPipeServer("Mail Service", -1, 1);
            _server.newRequestEvent += OnNewRequest;
        }

        internal static void StopServer()
        {
            _server.newRequestEvent -= OnNewRequest;
            _server?.Dispose();
        }

        internal static User GetUser(string username)
        {
            return _users.Find(x => x.Username == username);
        }

        #endregion

        #region Private Methods

        private static void InitDB()
        {
            string needPath = _registredUsersInfoPath;
            string needDirectory = @"DB";

            if (!Directory.Exists(needDirectory))
                Directory.CreateDirectory(needDirectory);

            if (!File.Exists(needPath))
            {
                File.Create(needPath).Dispose();

                string newContent = "[]";

                File.WriteAllText(needPath, newContent);
            }
            else
            {
                string fileContent = File.ReadAllText(_registredUsersInfoPath);

                _users = JsonConvert.DeserializeObject<List<User>>(fileContent);
            }

            string[] directories = Directory.GetDirectories(needDirectory, "*@afmms.ru", SearchOption.TopDirectoryOnly);

            if(directories != null)
            {
                for (int i = 0; i < directories.Length; i++)
                {
                    directories[i] = directories[i].Remove(0, 3);
                    _mailBoxes.Add(directories[i], new MailBox(directories[i]));
                }
            }
        }

        private static void OnNewRequest(object sender, PipeMsgEventArgs e)
        {
            int indexOfEndRequest = e.Request.IndexOf(":");

            string additionalParams = string.Empty;

            string request = e.Request;

            if (indexOfEndRequest != -1)
            {
                additionalParams = request.Substring(indexOfEndRequest + 1);

                request = e.Request.Substring(0, indexOfEndRequest);
            }

            switch (request)
            {
                case "Register New User":
                    {
                        string[] usernameAndPassword = additionalParams.Split(':');
                        RegisterNewUser(usernameAndPassword[0], usernameAndPassword[1]);
                        e.Response = "Success";
                    }
                    break;

                case "Is User Exists":
                    {
                        string username = additionalParams.Split(':')[0];
                        if (_users.Exists(u => u.Username == username))
                            e.Response = "T";
                        else
                            e.Response = "F";
                    }
                    break;

                case "Try Login":
                    {
                        string[] usernameAndPassword = additionalParams.Split(':');

                        usernameAndPassword[0] = usernameAndPassword[0].ToLower();

                        string registredUsers = File.ReadAllText(_registredUsersInfoPath);

                        _users = JsonConvert.DeserializeObject<List<User>>(registredUsers);

                        if(_users == null)
                        {
                            e.Response = "F";
                            break;
                        }

                        if (_users.Find(u => u.Username == usernameAndPassword[0]).IsLoginAccess(usernameAndPassword[0], usernameAndPassword[1]))
                            e.Response = "T";
                    }
                    break;

                case "Send Message":
                    {
                        string message = additionalParams;

                        Message msg = JsonConvert.DeserializeObject<Message>(message);

                        SendMessage(msg);

                        e.Response = "T";
                    }
                    break;

                case "Get Received Messages":
                    {
                        e.Response = JsonConvert.SerializeObject(_mailBoxes[additionalParams].Messages["received"], Formatting.None);
                    }
                    break;

                case "Get Sent Messages":
                    {
                        e.Response = JsonConvert.SerializeObject(_mailBoxes[additionalParams].Messages["sent"], Formatting.None);
                    }
                    break;

                case "Get Draft Messages":
                    {
                        e.Response = JsonConvert.SerializeObject(_mailBoxes[additionalParams].Messages["draft"], Formatting.None);
                    }
                    break;

                case "Set Message Read":
                    {
                        string[] parameters = additionalParams.Split(':');
                        if (parameters[2] == Message.MessageType.Sent.ToString())
                            _mailBoxes[parameters[0]].MarkMessageAsRead(Message.MessageType.Sent, parameters[1]);
                        else if (parameters[2] == Message.MessageType.Received.ToString())
                            _mailBoxes[parameters[0]].MarkMessageAsRead(Message.MessageType.Received, parameters[1]);
                        else
                            _mailBoxes[parameters[0]].MarkMessageAsRead(Message.MessageType.Draft, parameters[1]);
                    }
                    break;

                case "Save Message":
                    {
                        Message msg = JsonConvert.DeserializeObject<Message>(additionalParams);

                        msg.ReceiveTime = DateTime.Now;
                        msg.Type = Message.MessageType.Draft;

                        _mailBoxes[msg.From].AddMessage(msg);

                        int countOfMessages = 0;

                        countOfMessages += _mailBoxes[msg.From].Messages["draft"].Count;
                        countOfMessages += _mailBoxes[msg.From].Messages["sent"].Count;
                        countOfMessages += _mailBoxes[msg.From].Messages["received"].Count;

                        User usr = _users.Find(user => user.Username == msg.From);
                        usr.MessageCount = countOfMessages;

                        string updatedUserData = JsonConvert.SerializeObject(_users, Formatting.Indented);

                        File.WriteAllText(_registredUsersInfoPath, updatedUserData);
                        OnUserInfoUpdated(usr);
                    }
                    break;

                case "Delete Message":
                    {
                        string[] parameters = additionalParams.Split(':');
                        string username = parameters[0];
                        string id = parameters[1];
                        Message.MessageType type;

                        if (parameters[2] == Message.MessageType.Sent.ToString())
                            type = Message.MessageType.Sent;
                        else if (parameters[2] == Message.MessageType.Received.ToString())
                            type = Message.MessageType.Received;
                        else
                            type = Message.MessageType.Draft;

                        _mailBoxes[username].DeleteMessage(type, id);

                        User deletor = _users.Find(user => user.Username == username);

                        deletor.MessageCount--;

                        string updatedUserData = JsonConvert.SerializeObject(_users, Formatting.Indented);

                        File.WriteAllText(_registredUsersInfoPath, updatedUserData);
                        OnUserInfoUpdated(deletor);

                        e.Response = JsonConvert.SerializeObject(_mailBoxes[username].Messages, Formatting.None);
                    }
                    break;
            }
        }

        private static void RegisterNewUser(string username, string password)
        {
            username = username.ToLower();

            string registredUsers = File.ReadAllText(_registredUsersInfoPath);

            _users = JsonConvert.DeserializeObject<List<User>>(registredUsers);

            User newUser = new User(username, password);
            _users.Add(newUser);

            MailBox mailBoxForNewUser = new MailBox(username);
            _mailBoxes.Add(username, mailBoxForNewUser);

            string newRegistredUsers = JsonConvert.SerializeObject(_users, Formatting.Indented);

            File.WriteAllText(_registredUsersInfoPath, newRegistredUsers);

            OnNewUserRegistred(newUser);
        }

        private static async void SendMessage(Message message)
        {
            OnMessageSentRequired(message);

            await _semaphore.WaitAsync();

            bool isFailed = false;

            message.Type = Message.MessageType.Received;

            string updatedUserData;

            for(int i = 0; i < message.To.Count; i++)
            {
                OnMessageProcessingStarted(message);
                await Task.Delay(3000);

                if (_mailBoxes.ContainsKey(message.To[i]))
                {
                    message.ReceiveTime = DateTime.Now;
                    _mailBoxes[message.To[i]].AddMessage(message);

                    User receiver = _users.Find(user => user.Username == message.To[i]);
                    receiver.MessageCount++;

                    updatedUserData = JsonConvert.SerializeObject(_users, Formatting.Indented);

                    File.WriteAllText(_registredUsersInfoPath, updatedUserData);
                    OnUserInfoUpdated(receiver);
                    OnMessageProcessingCompleted(message);
                }
                else
                {
                    OnMessageProcessingFailed("Пользователь не найден");
                    isFailed = true;
                }
                await Task.Delay(3000);
            }

            if(!isFailed)
            {
                Message msgForSender = new Message(message.From, message.To, message.Theme, message.ContentRtf, message.Content, Message.MessageType.Sent, message.SendTime, message.Id);
                msgForSender.ReceiveTime = DateTime.Now;
                _mailBoxes[message.From].AddMessage(msgForSender);
            }
            else
            {
                message.Type = Message.MessageType.Draft;
                _mailBoxes[message.From].AddMessage(message);
            }

            User sender = _users.Find(user => user.Username == message.From);
            sender.MessageCount++;

            updatedUserData = JsonConvert.SerializeObject(_users, Formatting.Indented);
            File.WriteAllText(_registredUsersInfoPath, updatedUserData);

            OnUserInfoUpdated(sender);
            _semaphore.Release();
        }

        #endregion
    }
}
