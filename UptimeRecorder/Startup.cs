using System.Diagnostics;
using UptimeRecorder.Backend;

namespace UptimeRecorder
{
    public class Startup
    {
        public void Run()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;

            var startupTasks = StartupTasks.Instance;
            startupTasks.StartSession();
        }
    }
}