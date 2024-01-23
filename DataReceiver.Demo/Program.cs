using DataReceiver.Abstractions.Models;
using DataReceiver.Implementations;

internal class Program
{
    private static void Main(string[] args)
    {
        CreateMessageReceiver();
        while (true)
        {

        }
    }
    public static async void CreateMessageReceiver()
    {
        WebSocketReceiver receiver = WebSocketReceiver.CreateWebsocketClient(new Uri(""));
        receiver.OnMessageReceived += OnMessageReceived;
        await receiver.WebSocketClient.StartOrFail();
    }
    private static void OnMessageReceived(MessageBase message)
    {
        Console.WriteLine(message.MessageType);
    }
}