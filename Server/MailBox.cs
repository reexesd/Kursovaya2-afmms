using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class MailBox
    {
        private string _path;
        private List<Message> messages = new List<Message>();

        public MailBox(string username) 
        {
            _path = $"DB/{username}";
            if(!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
        }

        public void AddMessage(Message msg)
        {
            messages.Add(msg);
        }
    }
}
