using DataReceiver.Abstractions.Models.MQTT.Message;

namespace DataReceiver.Abstractions.Models.MQTT
{
    public class MQTTMessageReceiverBase
    {
        public delegate void MessageHandler(MQTTMessageBase message);
        public event MessageHandler? OnMessageReceived;
        internal void BroadcastMessage(MQTTMessageBase message)
        {
            OnMessageReceived?.Invoke(message);
        }
    }
}
