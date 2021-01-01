using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ndax.Api;

namespace ConsoleApp1
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            Console.WriteLine("Hello NDAX!\n");

            var builder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHttpClient<INdaxClient, NdaxClient>(c =>
                {
                    c.BaseAddress = new Uri("https://core.ndax.io/");
                }
                );

                services.AddTransient<NdaxClient>();
            }).UseConsoleLifetime();

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var ndaxService = services.GetRequiredService<INdaxClient>();
                    var ticker = await ndaxService.GetTickerAsync();

                    foreach (var item in ticker)
                    {
                        var pair = item.Key;
                        var instrument = item.Value;

                        Console.WriteLine(string.Format("Trading pair: {0}", pair));
                        Console.WriteLine(string.Format("ID: {0}, Bid = {1}, Ask = {2}, % Change = {3}\n",
                        instrument.Id, instrument.HighestBid, instrument.LowestAsk, instrument.PercentChange));
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();

                    logger.LogError(ex, "An error occurred.");
                }
            }

            return 0;
        }
    }
}
