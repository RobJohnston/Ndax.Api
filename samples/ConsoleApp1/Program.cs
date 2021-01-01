using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ndax.Api;
using Refit;

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
                services.AddHttpClient("ndax", c =>
                {
                    c.BaseAddress = new Uri("https://core.ndax.io/");
                }
                )
                .AddTypedClient(c => Refit.RestService.For<INdaxClient>(c));
            }).UseConsoleLifetime();

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();

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
                catch (ApiException ex)
                {
                    logger.LogError(ex, $"{ex.StatusCode} - {ex.ReasonPhrase}");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred.");
                }
            }

            return 0;
        }
    }
}
