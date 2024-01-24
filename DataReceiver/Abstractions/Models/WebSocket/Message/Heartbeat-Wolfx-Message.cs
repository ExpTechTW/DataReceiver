using Newtonsoft.Json;

namespace DataReceiver.Abstractions.Models.WebSocket.Message
{
    public class HeartbeatWolfxMessage : WolfxMessageBase
    {
        [JsonProperty("ver")]
        public int? ServerVersion { get; set; }
        [JsonProperty("id")]
        public string? ClientID { get; set; }
        [JsonProperty("timestamp")]
        public long? TimeStamp { get; set; }
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
