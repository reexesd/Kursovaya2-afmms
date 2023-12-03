using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Message
    {
        public enum MessageType
        {
            Sent,
            Recieved,
            Draft
        }
        private MessageType _type;
        private readonly int _id;
        private readonly string _from;
        private readonly List<string> _to;
        private readonly string _content;

        [JsonProperty("MessageType", Order = 5)]
        public MessageType Type { get { return _type; } internal set { _type = value; } }

        [JsonProperty("id",Order = 1)]
        public int Id { get { return _id; } }

        [JsonProperty("From", Order = 2)]
        public string From { get { return _from; } }

        [JsonProperty("To", Order = 3)]
        public List<string> To { get { return _to; } }

        [JsonProperty("Content", Order = 4)]
        public string Content { get { return _content; } }

                                                                                                         
        public Message(string from, List<string> to, string content, MessageType type)
        {
            _id = GetHashCode();
            _from = from;
            _to = to;
            _content = content;
            _type = type;
        }
    }
}
