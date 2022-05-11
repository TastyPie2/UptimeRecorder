using System;
using System.IO;

namespace UptimeRecorder.Backend
{
    internal static class TaskHelpers
    {

        public static string localApplicationDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UptimeRecorder");
        public static string currentSessionFolder = Path.Combine(localApplicationDataPath, "CurrentSession");
        public static string sessionsFolder = Path.Combine(localApplicationDataPath, "Sessions");
    }
}