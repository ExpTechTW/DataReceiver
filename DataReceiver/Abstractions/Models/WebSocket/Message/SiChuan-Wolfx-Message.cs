using System;

namespace DataReceiver.Abstractions.Models.WebSocket.Message
{
    public class SiChuanWolfxMessage : WolfxMessageBase
    {
        public int? ID { get; set; }
        public string? EventID { get; set; }
        public DateTime? ReportTime { get; set; }
        public int? ReportNum { get; set; }
        public DateTime? OriginTime { get; set; }
        public string? HypoCenter { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Magunitude { get; set; }
        public double? MaxIntensity { get; set; }
    }
}
