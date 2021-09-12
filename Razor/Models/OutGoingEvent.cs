using System;

namespace Razor.Models
{
    public class OutGoingEvent
    {
        public OutGoingEvent(Guid id, string incomingData, string serverRespone, DateTimeOffset dateTimeCreated, DateTimeOffset dateTimeUpdated)
        {
            Id = id;
            IncomingData = incomingData;
            ServerRespone = serverRespone;
            DateTimeCreated = dateTimeCreated;
            DateTimeUpdated = dateTimeUpdated;
        }

        public Guid Id { get; set; }
        public string IncomingData { get; set; }
        public string ServerRespone { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeUpdated { get; set; }
    }
}