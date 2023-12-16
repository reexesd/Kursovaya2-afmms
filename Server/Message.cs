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
        private readonly string _contentRtf;
        private readonly DateTime _sendTime;
        private DateTime _receiveTime;
        private readonly string _theme;
        private readonly string _content;

        [JsonProperty("id", Order = 1)]
        public int Id { get { return _id; } }

        [JsonProperty("Send Time", Order = 2)]
        public DateTime SendTime {  get { return _sendTime; } }

        [JsonProperty("Receive Time", Order = 3)]
        public DateTime ReceiveTime { get { return _receiveTime; } internal set { _receiveTime = value; } }

        [JsonProperty("MessageType", Order = 4)]
        public MessageType Type { get { return _type; } internal set { _type = value; } }

        [JsonProperty("From", Order = 5)]
        public string From { get { return _from; } }

        [JsonProperty("To", Order = 6)]
        public List<string> To { get { return _to; } }

        [JsonProperty("Theme", Order = 7)]
        public string Theme { get { return _theme; } }

        [JsonProperty("ContentRtf", Order = 8)]
        public string ContentRtf { get { return _contentRtf; } }

        [JsonProperty("Content", Order = 9)]
        public string Content { get { return _content; } }

        [JsonConstructor]
        public Message(string from, List<string> to, string theme, string contentRtf, string content, MessageType type, DateTime sendTime, int id = 0)
        {
            _theme = theme;
            _sendTime = sendTime;
            if(id ==0)
                _id = GetHashCode();
            else
                _id = id;
            _from = from;
            _to = to;
            _contentRtf = contentRtf;
            _type = type;
            _content = content;
        }
    }
}
