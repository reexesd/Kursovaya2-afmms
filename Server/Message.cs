using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class Message
    {
        private readonly int _id;
        private readonly string _from;
        private readonly string _to;
        private readonly string _content;

        [JsonProperty("id",Order = 1)]
        public int Id { get { return _id; } }

        [JsonProperty("From", Order = 2)]
        public string From { get { return _from; } }

        [JsonProperty("To", Order = 3)]
        public string To { get { return _to; } }

        [JsonProperty("Content", Order = 4)]
        public string Content { get { return _content; } }

        public Message(string from, string to, string content)
        {
            _id = GetHashCode();
            _from = from;
            _to = to;
            _content = content;
        }
    }
}
