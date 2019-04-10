using BinanceExchange.API.Models.WebSocket;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class AggregateTrade : BinanceAggregateTradeData
    {
        [Key]
        public new long AggregateTradeId { get; set; }
    }
}
