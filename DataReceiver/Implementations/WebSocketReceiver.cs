using DataReceiver.Abstractions.Models.WebSocket;
using DataReceiver.Abstractions.Models.WebSocket.Message;
using Newtonsoft.Json;
using System;
using System.Net.WebSockets;
using Websocket.Client;

namespace DataReceiver.Implementations
{
    public class WebSocketReceiver : WebSocketMessageReceiverBase, IDisposable
    {
        public readonly WebsocketClient WebSocketClient;
        private readonly JsonSerializerSettings DefaultSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };
        private IDisposable _disposeObject;
        public WebSocketReceiver(Uri targetUri)
        {
            WebsocketClient client = new WebsocketClient(targetUri);
            WebSocketClient = client;
            _disposeObject = client.MessageReceived.Subscribe(OnRawMessageReceived);
        }
        private void OnRawMessageReceived(ResponseMessage message)
        {
            if (message.MessageType == WebSocketMessageType.Text && message.Text != null)
            {
                var messageBase = new WebSocketMessageBase() { RawMessage = message.Text };
                BroadcastMessage(messageBase);
            }
        }
        private bool disposedValue;

        public void ThrowExceptionsIfDisposed()
        {
            if (disposedValue) throw new ObjectDisposedException(typeof(WebSocketReceiver).Name);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _disposeObject.Dispose();
                    WebSocketClient.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
