﻿using System;
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

namespace Server
{
    public static class UsersController
    {
        private static readonly string _registredUsersInfoPath = @"DB/RegistredUsers.json";
        private static List<User> _users = new List<User>();
        private static Dictionary<string,MailBox> _mailBoxes = new Dictionary<string, MailBox>();
        private static CancellationTokenSource _cancellationTokenSource;
        private static NamedPipeServerStream _serverStream;
        private static List<User> _usersToUpdate;
        public static event EventHandler NewUserAdded;
        internal static event EventHandler MessageSent;

        static UsersController()
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

            string[] directories = Directory.GetDirectories(needDirectory,"*@afmms.ru",SearchOption.TopDirectoryOnly);
            for(int i = 0; i < directories.Length; i++)
            {
                directories[i] = directories[i].Remove(0, 3);
                _mailBoxes.Add(directories[i], new MailBox(directories[i]));
            }

            _users = JsonConvert.DeserializeObject<List<User>>(fileContent);
        }

        private static void OnNewUserAdded(EventArgs e)
        {
            NewUserAdded?.Invoke(null, e);
        }

        private static void OnMessageSent(EventArgs e)
        {
            MessageSent?.Invoke(null, e);
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
            _usersToUpdate = new List<User>();
            _mailBoxes[msg.From].AddMessage(msg);
            _usersToUpdate.Add(_users.Find(x => x.Username == msg.From));
            _users.Find(user => user.Username == msg.From).MessageCount++;
            msg.Type = Message.MessageType.Recieved;
            for(int i = 0; i < msg.To.Count; i++)
            {
                if (_mailBoxes.ContainsKey(msg.To[i]))
                {
                    _mailBoxes[msg.To[i]].AddMessage(msg);
                    _users.Find(user => user.Username == msg.To[i]).MessageCount++;
                    _usersToUpdate.Add(_users.Find(x => x.Username == msg.To[i]));
                }
            }
            string newFileContent = JsonConvert.SerializeObject(_users, Formatting.Indented);

            File.WriteAllText(_registredUsersInfoPath, newFileContent);

            await SendCommandToServerAsync("Send Message");
        }

        public static async Task AddUserAsync(string username, string password)
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

            await SendCommandToServerAsync("New User Added");
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

        private static async Task ReceiveCommand(PipeStream pipeStream)
        {
            using (StreamReader sr = new StreamReader(pipeStream))
            {
                string command = await sr.ReadLineAsync();
                switch (command)
                {
                    case "New User Added":
                        OnNewUserAdded(EventArgs.Empty);
                        break;
                    case "Send Message":
                        OnMessageSent(EventArgs.Empty);
                        break;
                    default:
                        break;
                }
            }
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
                    await Task.Run(() => ReceiveCommand(_serverStream));
                }
            }
        }
    }
}
