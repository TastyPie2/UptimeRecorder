using System;
using System.Collections.Generic;
using System.Text;

namespace UptimeRecorder.Backend
{
    internal sealed class Misc
    {
        public static int GetQuarter(DateTime dateTime)
        {
            return (int)Math.Ceiling(dateTime.Month / 3.0);
        }

        public static int[] GetQuarters()
        {
            return new[] { 1, 2, 3, 4 };
        }
    }
}
