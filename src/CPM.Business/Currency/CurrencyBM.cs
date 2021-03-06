using CpmLib.Business.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business.Currency
{
    public class CurrencyBM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal? MarketCap { get; set; }
        public string Description { get; set; }
        public List<PriceTickerBM> Prices { get; set; } = new List<PriceTickerBM>();
        public List<FiatBM> FiatList { get; set; }
        public bool IsNew { get; set; }
    }

    public class PriceTickerBM
    {
        public string CryptoCode { get; set; }
        public string FiatCode { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public decimal Change { get; set; }
        public long UnixTimeStamp { get; set; }
        public DateTime DateTime { get; set; }
        public List<PriceMarketBM> Markets { get; set; } = new List<PriceMarketBM>();
        public bool Success { get; set; }
        public string Error { get; set; }      
    }

    public class PriceMarketBM
    {
        public string Market { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
    }

    public class CurrencyInfoBM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public PriceTickerInfoBM PriceTickerInfo { get; set; }
           }

    public class PriceTickerInfoBM
    {
        public string CryptoCode { get; set; }
        public string FiatCode { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public decimal Change { get; set; }
        public long UnixTimeStamp { get; set; }
        public DateTime DateTime { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }

    public class FiatBM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }
        public int ImageId { get; set; }
        public int FlagId { get; set; }
    }

   
}
