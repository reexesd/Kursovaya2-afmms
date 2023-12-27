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

        private Dictionary<Message.MessageType, List<Message>> _messages = new Dictionary<Message.MessageType, List<Message>>();

        internal Dictionary<Message.MessageType, List<Message>> Messages
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

            InitMessagesDictionary();
        }

        public void AddMessage(Message msg)
        {
            string path;

            if (msg.Type == Message.MessageType.Sent)
                path = _sentMsgPath;
            else if (msg.Type == Message.MessageType.Received)
                path = _receivedMsgPath;
            else
                path = _draftMsgPath;

            if (!_messages[msg.Type].Contains(msg))
                _messages[msg.Type].Add(msg);
            else
            {
                _messages[msg.Type].RemoveAt(_messages[msg.Type].FindIndex(message => message.Id == msg.Id));
                _messages[msg.Type].Add(msg);
            }

            string messagePath = Path.Combine(path, msg.Id) + ".json";

            string newMail = JsonConvert.SerializeObject(msg, Formatting.Indented);

            File.WriteAllText(messagePath, newMail);
        }

        private void InitMessagesDictionary()
        {
            _messages.Add(Message.MessageType.Sent, new List<Message>());

            _messages.Add(Message.MessageType.Received, new List<Message>());

            _messages.Add(Message.MessageType.Draft, new List<Message>());

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

                _messages[Message.MessageType.Sent].Add(JsonConvert.DeserializeObject<Message>(messageContent));
            }

            foreach (var receivedFile in receivedFiles)
            {
                string messageContent;

                using (StreamReader sr = receivedFile.OpenText())
                    messageContent = sr.ReadToEnd();

                _messages[Message.MessageType.Received].Add(JsonConvert.DeserializeObject<Message>(messageContent));
            }
            
            foreach (var draftFile in draftFiles)
            {
                string messageContent;

                using (StreamReader sr = draftFile.OpenText())
                    messageContent = sr.ReadToEnd();

                _messages[Message.MessageType.Draft].Add(JsonConvert.DeserializeObject<Message>(messageContent));
            }
        }

        public void MarkMessageAsRead(Message.MessageType type, string id)
        {
            Message msg = _messages[type].Find(message => message.Id == id);
            msg.IsOpened = true;

            string changedMessage = JsonConvert.SerializeObject(msg, Formatting.Indented);
            string path = Path.Combine(_path, type.ToString(), $"{id}.json");

            File.WriteAllText(path, changedMessage);
        }

        public void DeleteMessage(Message.MessageType type, string id)
        {
            string path;

            if (type == Message.MessageType.Sent)
                path = _sentMsgPath;
            else if (type == Message.MessageType.Draft)
                path = _draftMsgPath;
            else
                path = _receivedMsgPath;

            path = Path.Combine(path, $"{id}.json");

            _messages[type].RemoveAt(_messages[type].FindIndex(msg => msg.Id == id));

            File.Delete(path);
        }
    }
}
