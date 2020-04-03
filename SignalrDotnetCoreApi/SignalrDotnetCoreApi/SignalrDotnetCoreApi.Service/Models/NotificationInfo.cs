using System;

namespace SignalrDotnetCoreApi.Service.Models
{
    public class NotificationInfo
    {
        public MessageType MessageType { get; set; }

        public DateTime DateTime { get; set; }

        public dynamic Message { get; set; }
    }
}