using System;
using System.Threading.Tasks;
using Ndax.Api;

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
