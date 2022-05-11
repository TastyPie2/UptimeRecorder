using UptimeRecorder.Backend; 

namespace UptimeRecorder
{
    public class TimeUpdater : BackgroundService
    {
        private readonly ILogger<TimeUpdater> _logger;

        public TimeUpdater(ILogger<TimeUpdater> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var runtime = RuntimeTasks.Instance;

            while(!stoppingToken.IsCancellationRequested)
            {
                runtime.UpdateSessionEndTime();
                await Task.Delay(1000 * 60, stoppingToken);
            }

            return;
        }
    }
}