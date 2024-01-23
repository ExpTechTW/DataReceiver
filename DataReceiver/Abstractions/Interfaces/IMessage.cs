namespace DataReceiver.Abstractions.Interfaces
{
    public interface IMessage
    {
        public string? MessageType { get; set; }
        public string? RawMessage { get; set; }
    }
}
