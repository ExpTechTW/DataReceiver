using DataReceiver.Abstractions.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataReceiver.Abstractions.Models
{
    public class MessageBase : IMessage
    {
        [JsonProperty("type")]
        public string? MessageType { get; set; }
    }
}
