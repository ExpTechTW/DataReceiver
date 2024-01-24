using DataReceiver.Abstractions.Models.WebSocket.Message;

namespace DataReceiver.Abstractions.Models.WebSocket
{
    public class WebSocketMessageReceiverBase
    {
        public delegate void MessageHandler(WebSocketMessageBase message);
        public event MessageHandler? OnMessageReceived;
        internal void BroadcastMessage(WebSocketMessageBase message)
        {
            OnMessageReceived?.Invoke(message);
        }
    }
}
