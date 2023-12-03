# Ndax.Api
A .Net Standard client for the NDAX cryptocurrency API.

[![nuget](https://img.shields.io/nuget/v/Ndax.Api.svg)](https://www.nuget.org/packages/Ndax.Api/)
[![Downloads](https://img.shields.io/nuget/dt/Ndax.Api.svg)

An account is not required to access the public API methods. 
However, if you do create an account, please use my affiliate link when you register.
It's an easy way to give back to this project at no cost to you: https://refer.ndax.io/jbBH


## Installation via NuGet
```
Install-Package Ndax.Api
```

## Example usage

```csharp
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

```

### Output
```
Hello NDAX!

Trading pair: BTC_CAD
ID: 1, Bid = 37187.53, Ask = 37318.28, % Change = 0.4331174089068826

Trading pair: ETH_CAD
ID: 3, Bid = 937, Ask = 949.98, % Change = -1.6769884513187416

Trading pair: XRP_CAD
ID: 4, Bid = 0.29101, Ask = 0.30753, % Change = 1.1546621222133342

Trading pair: LTC_CAD
ID: 5, Bid = 157, Ask = 164.44, % Change = 1.302710378465148

Trading pair: EOS_CAD
ID: 75, Bid = 3.252, Ask = 3.4132, % Change = 3.4702380952380953

Trading pair: XLM_CAD
ID: 76, Bid = 0.165713, Ask = 0.172918, % Change = 10.664092516972241

Trading pair: DOGE_CAD
ID: 77, Bid = 0.006605, Ask = 0.0069388, % Change = 17.24194073591664

Trading pair: ADA_CAD
ID: 78, Bid = 0.22115, Ask = 0.2283, % Change = -2.6991525423728815

Trading pair: USDT_CAD
ID: 80, Bid = 1.2821, Ask = 1.2961, % Change = 0.14683153013910355

Trading pair: LINK_CAD
ID: 81, Bid = 15, Ask = 15.43, % Change = 7.9020979020979025

Trading pair: BTC_USDT
ID: 82, Bid = 29169.8, Ask = 29269.24, % Change =


...
Press any key to close this window . . .

```

## My related projects

Need more than what this Web API provides?  Follow the development of my [AlphaPoint.Api](https://github.com/RobJohnston/AlphaPoint.Api) project that uses the WebSocket API.

* [Coinsquare.Api](https://github.com/RobJohnston/Coinsquare.Api)
