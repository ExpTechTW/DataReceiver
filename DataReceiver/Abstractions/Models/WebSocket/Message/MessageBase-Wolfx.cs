using Newtonsoft.Json;

namespace DataReceiver.Abstractions.Models.WebSocket.Message
{
    public class WolfxMessageBase : WebSocketMessageBase
    {
        [JsonProperty("type")]
        public string? MessageType { get; set; }
        [JsonIgnore]
        public override string? RawMessage { get; set; }
    }
}
