using DataReceiver.Abstractions.Interfaces;

namespace DataReceiver.Abstractions.Models.WebSocket.Message
{
    public class WebSocketMessageBase : IWebSocketMessage
    {
        public virtual string? RawMessage { get; set; }
    }
}
