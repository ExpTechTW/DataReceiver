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
        public static WebSocketReceiver CreateWebsocketClient(Uri targetUri)
        {
            WebsocketClient client = new WebsocketClient(targetUri);
            var result = new WebSocketReceiver(client);
            return result;
        }
        private WebSocketReceiver(WebsocketClient webSocketClient)
        {
            WebSocketClient = webSocketClient;
            _disposeObject = webSocketClient.MessageReceived.Subscribe(OnRawMessageReceived);
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

        void IDisposable.Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
