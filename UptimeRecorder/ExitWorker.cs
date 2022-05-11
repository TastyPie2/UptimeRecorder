using UptimeRecorder.Backend;

namespace UptimeRecorder
{
    public sealed class ExitWorker
    {
        public void Run()
        {
            var runtime = RuntimeTasks.Instance;
            runtime.EndSession();
        }
    }
}
