using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class User
    {
        private readonly string _username;
        [JsonProperty("Password", Order = 2)]
        private readonly string _password;
        private int _messageCount;

        [JsonProperty("Name", Order = 1)]
        public string Username
        {
            get { return _username; }
        }

        [JsonProperty("MessageCount", Order = 3)]
        public int MessageCount
        {
            get { return _messageCount; }
        }

        [JsonConstructor]
        public User(string username, string password)
        {
            _username = username;
            _password = password;
            _messageCount = 0;
        }

        public User(string username)
        {
            _username = username;
            _messageCount = 0;
        }

        public bool IsLoginAccess(string username, string password)
        {
            return username == _username && password == _password;
        }
    }
}
