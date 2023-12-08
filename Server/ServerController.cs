using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO.Pipes;
using System.Threading;
using System.Collections.Concurrent;
using System.Net.NetworkInformation;

namespace Server
{
    public static class ServerController
    {
        private static readonly string _registredUsersInfoPath = @"DB/RegistredUsers.json";
        private static List<User> _users = new List<User>();
        private static Dictionary<string, MailBox> _mailBoxes = new Dictionary<string, MailBox>();
        private static CancellationTokenSource _cancellationTokenSource;
        private static NamedPipeServerStream _serverStream;
        internal static event EventHandler NewUserAdded;
        internal static event EventHandler<Message> MessageSent;
        internal static event EventHandler<User> NeedToUpdate;
        internal static event EventHandler<Message> ProcessingStarted;
        internal static event EventHandler<Message> ProcessingCompleted;
        internal static event EventHandler ProcessingEnded;

        static ServerController()
        {
            InitFiles();
        }

        private static void InitFiles()
        {
            string needPath = @"DB/RegistredUsers.json";
            string needDirectory = @"DB";
            if (!Directory.Exists(needDirectory))
            {
                Directory.CreateDirectory(needDirectory);
            }
            if (!File.Exists(needPath))
            {
                File.Create(needPath).Dispose();
            }
            string fileContent = File.ReadAllText(_registredUsersInfoPath);

            string[] directories = Directory.GetDirectories(needDirectory, "*@afmms.ru", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < directories.Length; i++)
            {
                directories[i] = directories[i].Remove(0, 3);
                _mailBoxes.Add(directories[i], new MailBox(directories[i]));
            }

            _users = JsonConvert.DeserializeObject<List<User>>(fileContent);
        }

        private static void OnProcessingEnded(EventArgs e)
        {
            ProcessingEnded?.Invoke(null, e);
        }

        private static void OnProcessingStarted(Message message)
        {
            ProcessingStarted?.Invoke(null, message);
        }

        private static void OnProcessingCompleted(Message message)
        {
            ProcessingCompleted?.Invoke(null, message);
        }

        private static void OnNewUserAdded(EventArgs e)
        {
            NewUserAdded?.Invoke(null, e);
        }

        private static void OnMessageSent(Message msg)
        {
            MessageSent?.Invoke(null, msg);
        }

        private static void OnNeedToUpdate(User user)
        {
            NeedToUpdate?.Invoke(null, user);
        }

        internal static List<User> GetUsersList()
        {
            return _users;
        }

        internal static User GetUserInfo(string username)
        {
            string fileContent = File.ReadAllText(_registredUsersInfoPath);
            _users = JsonConvert.DeserializeObject<List<User>>(fileContent);
            User user = _users.Find(x => x.Username == username);
            return user;
        }

        public static string GetNewUserInfo()
        {
            string fileContent = File.ReadAllText(_registredUsersInfoPath);

            var lastObj = JArray.Parse(fileContent).Last();
            dynamic data = JObject.Parse(lastObj.ToString());
            return data.Name;
        }

        public static bool IsUserExist(string username)
        {
            string fileContent = File.ReadAllText(_registredUsersInfoPath);

            _users = JsonConvert.DeserializeObject<List<User>>(fileContent);
            if (_users == null)
                return false;
            foreach (User user in _users)
            {
                if (user.Username == username)
                    return true;
            }
            return false;
        }

        public static async Task SendMessage(Message msg)
        {
            string messageToServer = JsonConvert.SerializeObject(msg, Formatting.Indented);
            await SendCommandToServerAsync($"Send Message To Server\n{messageToServer}");
        }

        public static async Task RegisterUserAsync(string username, string password)
        {
            await SendCommandToServerAsync($"New User Added\n{username}\n{password}");
        }

        private static void AddNewUser(string username, string password)
        {
            string fileContent = File.ReadAllText(_registredUsersInfoPath);

            username = username.ToLower();

            _users = JsonConvert.DeserializeObject<List<User>>(fileContent);

            User newUser = new User(username, password);
            _users.Add(newUser);

            MailBox newMailBox = new MailBox(username);
            _mailBoxes.Add(username, newMailBox);

            string newFileContent = JsonConvert.SerializeObject(_users, Formatting.Indented);

            File.WriteAllText(_registredUsersInfoPath, newFileContent);
        }

        public static async Task TryConnect()
        {
            using (NamedPipeClientStream client = new NamedPipeClientStream(
                ".", "MailServer", PipeDirection.Out, PipeOptions.Asynchronous))
            {
                await client.ConnectAsync(2000);
            }
        }

        public static bool TryLogin(string username, string password)
        {
            username = username.ToLower();

            string fileContent = File.ReadAllText(_registredUsersInfoPath);

            _users = JsonConvert.DeserializeObject<List<User>>(fileContent);

            if (_users == null) return false;
            foreach (User user in _users)
            {
                if (user.Username == username)
                {
                    if (user.IsLoginAccess(username, password))
                        return true;
                }
            }
            return false;
        }

        public static async Task SendCommandToServerAsync(string command)
        {
            using (NamedPipeClientStream client = new NamedPipeClientStream(
                ".", "MailServer", PipeDirection.Out, PipeOptions.Asynchronous))
            {
                await client.ConnectAsync(2000);
                using (StreamWriter sr = new StreamWriter(client))
                {
                    await sr.WriteAsync(command);
                }
            }
        }

        private static async Task ReceiveCommandAsync(PipeStream pipeStream)
        {
            using (StreamReader sr = new StreamReader(pipeStream))
            {
                string command = await sr.ReadLineAsync();
                switch (command)
                {
                    case "New User Added":
                        string username = await sr.ReadLineAsync();
                        string password = await sr.ReadLineAsync();
                        AddNewUser(username, password);
                        OnNewUserAdded(EventArgs.Empty);
                        break;

                    case "Send Message To Server":
                        string receivedMessage = await sr.ReadToEndAsync();
                        Message message = JsonConvert.DeserializeObject<Message>(receivedMessage);
                        SendMsgAsync(message);
                        break;

                    default:
                        break;
                }
            }
        }

        private static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1);

        private async static void SendMsgAsync(Message messageToServer)
        {
            string newFileContent;
            OnMessageSent(messageToServer);
            await _semaphoreSlim.WaitAsync();
            messageToServer.Type = Message.MessageType.Recieved;
            for (int i = 0; i < messageToServer.To.Count; i++)
            {
                OnProcessingStarted(messageToServer);
                await Task.Delay(3000);
                if (_mailBoxes.ContainsKey(messageToServer.To[i]))
                {
                    messageToServer.ReceiveTime = DateTime.Now;
                    _mailBoxes[messageToServer.To[i]].AddMessage(messageToServer);

                    User receiver = _users.Find(user => user.Username == messageToServer.To[i]);
                    receiver.MessageCount++;

                    newFileContent = JsonConvert.SerializeObject(_users, Formatting.Indented);

                    File.WriteAllText(_registredUsersInfoPath, newFileContent);
                    OnNeedToUpdate(receiver);
                }
                OnProcessingCompleted(messageToServer);
                await Task.Delay(3000);
                OnProcessingEnded(EventArgs.Empty);
            }

            messageToServer.Type = Message.MessageType.Sent;
            _mailBoxes[messageToServer.From].AddMessage(messageToServer);
            User sender = _users.Find(user => user.Username == messageToServer.From);
            sender.MessageCount++;

            newFileContent = JsonConvert.SerializeObject(_users, Formatting.Indented);
            File.WriteAllText(_registredUsersInfoPath, newFileContent);

            OnNeedToUpdate(sender);
            _semaphoreSlim.Release();
        }

        public static void StopServer()
        {
            _cancellationTokenSource.Cancel();
        }

        public static async Task StartServerAsync()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            while (true)
            {
                using (_serverStream = new NamedPipeServerStream(
                    "MailServer", PipeDirection.InOut,
                    NamedPipeServerStream.MaxAllowedServerInstances,
                    PipeTransmissionMode.Message, PipeOptions.Asynchronous))
                {
                    try
                    {
                        await _serverStream.WaitForConnectionAsync(_cancellationTokenSource.Token);
                    }
                    catch
                    {
                        return;
                    }
                    await Task.Run(() => ReceiveCommandAsync(_serverStream));
                }
            }
        }
    }
}
