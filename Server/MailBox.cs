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

        private List<Message> _messages = new List<Message>();
        internal List<Message> Messages
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
        }

        public void AddMessage(Message msg)
        {
            _messages.Add(msg);
            string path;
            if(msg.Type == Message.MessageType.Sent)
                path = _sentMsgPath;
            else if(msg.Type == Message.MessageType.Recieved) 
                path = _receivedMsgPath;
            else 
                path = _draftMsgPath;
            string messagePath = Path.Combine(path, msg.Id.ToString()) + ".json";
            string newMail = JsonConvert.SerializeObject(msg, Formatting.Indented);
            File.WriteAllText(messagePath, newMail);
        }
    }
}
