using DataReceiver.Abstractions.Interfaces;
using Newtonsoft.Json;

namespace DataReceiver.Abstractions.Models.Message
{
    public class MessageBase : IMessage
    {
        [JsonProperty("type")]
        public string? MessageType { get; set; }
        [JsonIgnore]
        public string? RawMessage { get; set; }
    }
}
