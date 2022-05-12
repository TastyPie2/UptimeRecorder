using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UptimeRecorder.Backend;

namespace UptimeView
{
    internal class UptimeWeekData
    {
        public List<UptimeDayInfo> weekDays { get; set; } = new();

        public int Uptime { get; set; }


    }

    internal class UptimeDayInfo
    {
        
        public DateTime DateTime { get; private set; }

        public DayOfWeek DayOfWeek { get; private set; }

        public List<Session> Sessions { get; private set; }

        public UptimeDayInfo(List<Session> sessions)
        {
            Sessions = sessions;
        }
    }   
}
