using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.WindowsServices;
using Microsoft.Extensions.Logging;
using ServiceGeolocationWPOSS.Works;

internal class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureLogging(options => options.AddFilter(level => level >= LogLevel.Information))
        .ConfigureServices((hostContext, services) =>
        {
            services.AddHostedService<WorkerGeolocation>();
           
        }).UseWindowsService();
}

public static class WindowsServiceHelpers
{
    public static bool IsWindowsService()
    {
        return !(Console.IsInputRedirected || Console.IsOutputRedirected || Console.IsErrorRedirected || Environment.UserInteractive);
    }
}
