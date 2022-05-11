namespace UptimeRecorder
{
    internal static class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            new Startup().Run();

            GetHostBuilder(args).Run();
            Task.Delay(-1).GetAwaiter();
        }

        static IHost GetHostBuilder(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddHostedService<TimeUpdater>();
            })
            .Build();

            return host;
        }

        private static void CurrentDomain_ProcessExit(object? sender, EventArgs e)
        {
            ExitWorker worker = new ExitWorker();
            worker.Run();
        }
    }
}