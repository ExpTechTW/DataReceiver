using DataReceiver.Abstractions.Models.MQTT.Message;
using DataReceiver.Abstractions.Models.MQTT;
using MQTTnet;
using MQTTnet.Client;
using System.Threading.Tasks;
using System;

namespace DataReceiver.Implementations
{
    public class MQTTReceiver : MQTTMessageReceiverBase, IDisposable
    {
        public IMqttClient MQTTClient;
        private bool disposedValue;

        private Task OnRawMessageReceived(MqttApplicationMessageReceivedEventArgs arg)
        {
            var messageBase = new MQTTMessageBase() { RawMessage = arg.ApplicationMessage };
            return Task.CompletedTask;
        }
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
                    if(MQTTClient.IsConnected)
                    {
                        MQTTClient.TryDisconnectAsync().GetAwaiter().GetResult();
                    }
                    MQTTClient.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        public MQTTReceiver(IMqttClient mqttClient)
        {
            MQTTClient = mqttClient;
            MQTTClient.ApplicationMessageReceivedAsync += OnRawMessageReceived;
        }
    }
}
