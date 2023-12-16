using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class MailBox
    {
        private string _path;
        private string _receivedMsgPath;
        private string _sentMsgPath;
        private string _draftMsgPath;

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
                _messages["sent"].Add(msg);
            }
            else if (msg.Type == Message.MessageType.Recieved)
            {
                path = _receivedMsgPath;
                _messages["received"].Add(msg);
            }
            else
            {
                path = _draftMsgPath;
                _messages["draft"].Add(msg);
            }

            string messagePath = Path.Combine(path, msg.Id.ToString()) + ".json";

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

            var sentFiles = _sentDirectoryInfo.GetFiles().OrderByDescending(file => file.CreationTime).ToList();

            var receivedFiles = _receivedDirectoryInfo.GetFiles().OrderByDescending(file => file.CreationTime).ToList();

            var draftFiles = _draftDirectoryInfo.GetFiles().OrderByDescending(file => file.CreationTime).ToList();

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
    }
}
