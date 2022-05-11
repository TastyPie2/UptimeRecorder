namespace UptimeRecorder
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new Startup().Run();

            GetHostBuilder(args).Run();
            Task.Delay(-1).GetAwaiter();
        }

        static IHost GetHostBuilder(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddHostedService<Worker>();
            })
            .Build();

            return host;
        }
    }
}