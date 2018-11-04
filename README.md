# Ndax.Api
A .Net Standard client for the NDAX cryptocurrency API.

[![nuget](https://img.shields.io/nuget/v/Ndax.Api.svg)](https://www.nuget.org/packages/Ndax.Api/)
[![Downloads](https://img.shields.io/nuget/dt/Ndax.Api.svg)

An account is not required to access the public API methods. 
However, if you do create an account, please use my affiliate link when you register.
It's an easy way to give back to this project at no cost to you: https://ndax.io/signup.html?aff=rob_johnston


[![Sign-up with NDAX](https://github.com/RobJohnston/Ndax.Api/blob/master/300x250%20-%20Blue.png)](https://ndax.io/signup.html?aff=rob_johnston)

## Installation via NuGet
```
Install-Package Ndax.Api
```

## Example usage

```csharp
using Ndax.Api;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello NDAX!\n");

            using (var client = new NdaxClient())
            {
                try
                {
                    var t = Task.Run(() => client.GetTickerAsync());
                    var ticker = t.Result;

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
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}

```

### Output
```
Hello NDAX!

Trading pair: BTC_CAD
ID: 1, Bid = 8391.8951, Ask = 8562.01, % Change = -1.0274674681631022

Trading pair: BCH_CAD
ID: 2, Bid = 668.97, Ask = 696.29, % Change = 0

Trading pair: ETH_CAD
ID: 3, Bid = 289.03, Ask = 307.57, % Change = -8.864292589027912

Trading pair: XRP_CAD
ID: 4, Bid = 0.73146, Ask = 0.77764, % Change = -9.902446865070043

Trading pair: LTC_CAD
ID: 5, Bid = 75.87, Ask = 80.15, % Change = 0

Trading pair: BTC_USD
ID: 74, Bid = 0, Ask = 0, % Change = 0

Trading pair: EOS_CAD
ID: 75, Bid = 7.185, Ask = 7.6135, % Change = 0


Press any key to exit.
```

## My related projects

Need more than what this Web API provides?  Follow the development of my [AlphaPoint.Api](https://github.com/RobJohnston/AlphaPoint.Api) project that uses the WebSocket API.

* [QuadrigaCX.Api](https://github.com/RobJohnston/QuadrigaCX.Api)
* [CoinField.Api](https://github.com/RobJohnston/CoinField.Api)
* [Coinsquare.Api](https://github.com/RobJohnston/Coinsquare.Api)
* [EzBtc.Api](https://github.com/RobJohnston/EzBtc.Api)
* [AnxPro.Api](https://github.com/RobJohnston/AnxPro.Api)