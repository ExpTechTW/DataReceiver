using System;
using System.Collections.Generic;
using System.Text;

namespace DataReceiver.Abstractions.Interfaces
{
    public interface IMessage
    {
        public string? MessageType { get; set; }
    }
}
