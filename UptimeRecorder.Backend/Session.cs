using System;

namespace UptimeRecorder.Backend
{
    public class Session
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime StartDateTime { get; set; }

        public DateTime? StopDateTime { get; set; }

        public Session()
        {
            StartDateTime = DateTime.Now;
        }

        public Session(DateTime startDateTime, DateTime stopDateTime)
        {
            StartDateTime = startDateTime;
            StopDateTime = stopDateTime;
        }
    }
}
