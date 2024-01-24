using MQTTnet;

namespace DataReceiver.Abstractions.Interfaces
{
    public interface IMQTTMessage
    {
        public MqttApplicationMessage? RawMessage { get; set; }
    }
}
