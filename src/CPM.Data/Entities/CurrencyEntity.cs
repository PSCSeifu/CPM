using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Entities
{
    public class CurrencyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal? MarketCap { get; set; }
        public string Description { get; set; }

    }
}
