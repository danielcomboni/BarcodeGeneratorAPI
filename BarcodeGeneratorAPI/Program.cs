using System ;
using Microsoft.AspNetCore ;
using Microsoft.AspNetCore.Hosting ;
using Microsoft.Extensions.DependencyInjection ;
using Serilog ;
using Serilog.Events ;

namespace BarcodeGeneratorAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Logs\\hsports.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    Log.Information("Starting HSPORTS API");
                    host.Run();
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "Host terminated unexpectedly");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
