using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Currency
{
    public class CurrencyDM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal? MarketCap { get; set; }
        public string Description { get; set; }
        public List<FiatDM> FiatList { get; set; }
    }
    
    public class CurrencyInfoDM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }  
    }

    public class FiatDM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }
        public int? ImageId { get; set; }
        public int? FlagId { get; set; }
    }
}
