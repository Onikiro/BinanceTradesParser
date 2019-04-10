using BinanceExchange.API.Client;
using BinanceExchange.API.Websockets;
using DAL;
using System;

namespace BinanceTradeParser
{
    class Program
    {
        static void Main()
        {
            var apiKey = "test";
            var secretKey = "test";

            var client = new BinanceClient(new ClientConfiguration
            {
                ApiKey = apiKey,
                SecretKey = secretKey
            });

            Console.WriteLine("Interacting with Binance...");

            var binanceWebSocketClient = new InstanceBinanceWebSocketClient(client);
            var webSocketGuid = Guid.Empty;

            try
            {
                webSocketGuid = binanceWebSocketClient.ConnectToTradesWebSocket("ETHBTC", data =>
                {
                    using (var db = new ApplicationContext())
                    {
                        db.Trades.Add(Mapper.Map(data));
                        db.SaveChanges();
                    }
                });

                while (binanceWebSocketClient.IsAlive(webSocketGuid))
                {
                    //Ждем получения
                }
            }
            finally
            {
                Console.WriteLine("Stopped.");
                binanceWebSocketClient.CloseWebSocketInstance(webSocketGuid);
            }
        }
    }
}
