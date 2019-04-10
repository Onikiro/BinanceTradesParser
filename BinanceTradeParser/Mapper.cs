using BinanceExchange.API.Models.WebSocket;
using DAL.Models;

namespace BinanceTradeParser
{
    public static class Mapper
    {
        public static AggregateTrade Map(BinanceAggregateTradeData data)
        {
            return new AggregateTrade
            {
                AggregateTradeId = data.AggregateTradeId,
                EventTime = data.EventTime,
                EventType = data.EventType,
                FirstTradeId = data.FirstTradeId,
                LastTradeId = data.LastTradeId,
                Price = data.Price,
                Quantity = data.Quantity,
                Symbol = data.Symbol,
                TradeTime = data.TradeTime,
                WasBestPriceMatch = data.WasBestPriceMatch,
                WasBuyerMaker = data.WasBuyerMaker
            };
        }
    }
}
