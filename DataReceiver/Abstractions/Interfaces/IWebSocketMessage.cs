namespace DataReceiver.Abstractions.Interfaces
{
    public interface IWebSocketMessage
    {
        public string? RawMessage { get; set; }
    }
}
