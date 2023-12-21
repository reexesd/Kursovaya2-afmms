using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Web;

namespace Server
{
    internal class MailBox
    {
        private readonly string _path;
        private readonly string _receivedMsgPath;
        private readonly string _sentMsgPath;
        private readonly string _draftMsgPath;

        private Dictionary<string, List<Message>> _messages = new Dictionary<string, List<Message>>();

        internal Dictionary<string, List<Message>> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value; 
            }
        }

        public MailBox(string username) 
        {
            _path = $"DB/{username}";
            if(!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            _sentMsgPath = Path.Combine(_path, "Sent");

            _receivedMsgPath = Path.Combine(_path, "Received");

            _draftMsgPath = Path.Combine(_path, "Draft");

            if (!Directory.Exists(_sentMsgPath))
                Directory.CreateDirectory(_sentMsgPath);

            if (!Directory.Exists(_receivedMsgPath))
                Directory.CreateDirectory(_receivedMsgPath);

            if (!Directory.Exists(_draftMsgPath))
                Directory.CreateDirectory(_draftMsgPath);

            InitMessagesList();
        }

        public void AddMessage(Message msg)
        {
            string path;

            if (msg.Type == Message.MessageType.Sent)
            {
                path = _sentMsgPath;
                _messages["sent"].Insert(_messages["sent"].Count, msg);
            }
            else if (msg.Type == Message.MessageType.Received)
            {
                path = _receivedMsgPath;
                _messages["received"].Insert(_messages["received"].Count, msg);
            }
            else
            {
                path = _draftMsgPath;
                if (!_messages["draft"].Contains(msg))
                    _messages["draft"].Insert(_messages["draft"].Count, msg);
                else
                {
                    _messages["draft"].RemoveAt(_messages["draft"].FindIndex(message => message.Id == msg.Id));
                    _messages["draft"].Insert(_messages["draft"].Count, msg);
                }
            }

            string messagePath = Path.Combine(path, msg.Id) + ".json";

            string newMail = JsonConvert.SerializeObject(msg, Formatting.Indented);

            File.WriteAllText(messagePath, newMail);
        }

        private void InitMessagesList()
        {
            _messages.Add("sent", new List<Message>());

            _messages.Add("received", new List<Message>());

            _messages.Add("draft", new List<Message>());

            DirectoryInfo _sentDirectoryInfo = new DirectoryInfo(_sentMsgPath);

            DirectoryInfo _receivedDirectoryInfo = new DirectoryInfo(_receivedMsgPath);

            DirectoryInfo _draftDirectoryInfo = new DirectoryInfo(_draftMsgPath);

            var sentFiles = _sentDirectoryInfo.GetFiles().OrderBy(file => file.CreationTime).ToList();

            var receivedFiles = _receivedDirectoryInfo.GetFiles().OrderBy(file => file.CreationTime).ToList();

            var draftFiles = _draftDirectoryInfo.GetFiles().OrderBy(file => file.CreationTime).ToList();

            foreach (var sentFile in sentFiles)
            {
                string messageContent;

                using (StreamReader sr = sentFile.OpenText())
                    messageContent = sr.ReadToEnd();

                _messages["sent"].Add(JsonConvert.DeserializeObject<Message>(messageContent));
            }

            foreach (var receivedFile in receivedFiles)
            {
                string messageContent;

                using (StreamReader sr = receivedFile.OpenText())
                    messageContent = sr.ReadToEnd();

                _messages["received"].Add(JsonConvert.DeserializeObject<Message>(messageContent));
            }
            
            foreach (var draftFile in draftFiles)
            {
                string messageContent;

                using (StreamReader sr = draftFile.OpenText())
                    messageContent = sr.ReadToEnd();

                _messages["draft"].Add(JsonConvert.DeserializeObject<Message>(messageContent));
            }
        }

        public void MarkMessageAsRead(Message.MessageType type, string id)
        {
            switch (type)
            {
                case Message.MessageType.Sent:
                    {
                        Message msg = _messages["sent"].Find(message => message.Id == id);
                        msg.IsOpened = true;

                        string changedMessage = JsonConvert.SerializeObject(msg, Formatting.Indented);
                        string path = Path.Combine(_sentMsgPath, $"{id}.json");

                        File.WriteAllText(path, changedMessage);
                    }
                    break;

                case Message.MessageType.Received:
                    {
                        Message msg = _messages["received"].Find(message => message.Id == id); 
                        msg.IsOpened = true;

                        string changedMessage = JsonConvert.SerializeObject(msg, Formatting.Indented);
                        string path = Path.Combine(_receivedMsgPath, $"{id}.json");

                        File.WriteAllText(path, changedMessage);
                    }
                    break;

                case Message.MessageType.Draft:
                    {
                        Message msg = _messages["draft"].Find(message => message.Id == id);
                        msg.IsOpened = true;

                        string changedMessage = JsonConvert.SerializeObject(msg, Formatting.Indented);
                        string path = Path.Combine(_draftMsgPath, $"{id}.json");

                        File.WriteAllText(path, changedMessage);
                    }
                    break;
            }
        }

        public void DeleteMessage(Message.MessageType type, string id)
        {
            string stype;
            string path;

            if (type == Message.MessageType.Sent)
            {
                stype = "sent";
                path = _sentMsgPath;
            }
            else if (type == Message.MessageType.Draft)
            {
                stype = "draft";
                path = _draftMsgPath;
            }
            else
            {
                stype = "received";
                path = _receivedMsgPath;
            }

            path = Path.Combine(path, $"{id}.json");

            _messages[stype].RemoveAt(_messages[stype].FindIndex(msg => msg.Id == id));

            File.Delete(path);
        }
    }
}
