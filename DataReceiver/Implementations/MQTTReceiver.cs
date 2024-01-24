using DataReceiver.Abstractions.Models.MQTT.Message;
using DataReceiver.Abstractions.Models.MQTT;
using MQTTnet;
using MQTTnet.Client;
using System.Threading.Tasks;

namespace DataReceiver.Implementations
{
    public class MQTTReceiver : MQTTMessageReceiverBase
    {
        public IMqttClient MQTTClient;
        public static MQTTReceiver CreateMQTTReceiver()
        {
            var mqttFactory = new MqttFactory();
            var client = mqttFactory.CreateMqttClient();
            return new MQTTReceiver(client);
        }
        private Task OnRawMessageReceived(MqttApplicationMessageReceivedEventArgs arg)
        {
            var messageBase = new MQTTMessageBase() { RawMessage = arg.ApplicationMessage };
            return Task.CompletedTask;
        }
        public MQTTReceiver(IMqttClient mqttClient)
        {
            MQTTClient = mqttClient;
            MQTTClient.ApplicationMessageReceivedAsync += OnRawMessageReceived;
        }
    }
}
