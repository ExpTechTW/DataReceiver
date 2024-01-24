using DataReceiver.Abstractions.Models.WebSocket.Message;
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
        WebSocketReceiver receiver = WebSocketReceiver.CreateWebsocketClient(new Uri("wss://ws-api.wolfx.jp/sc_eew"));
        receiver.OnMessageReceived += OnMessageReceived;
        await receiver.WebSocketClient.StartOrFail();
    }
    private static void OnMessageReceived(WebSocketMessageBase message)
    {
        Console.WriteLine(message.RawMessage);
    }
}