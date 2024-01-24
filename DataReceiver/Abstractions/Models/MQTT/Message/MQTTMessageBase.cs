using DataReceiver.Abstractions.Interfaces;
using MQTTnet;

namespace DataReceiver.Abstractions.Models.MQTT.Message
{
    public class MQTTMessageBase : IMQTTMessage
    {
        public virtual MqttApplicationMessage? RawMessage { get; set; }
    }
}
