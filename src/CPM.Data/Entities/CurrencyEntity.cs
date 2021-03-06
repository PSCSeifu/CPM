using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Entities
{
    [Table("Currency")]
    public class CurrencyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal? MarketCap { get; set; }
        public string Description { get; set; }

        

        public string Symbol { get; set; }
        public string DisplayName  { get; set; }
        public int? ImageId { get; set; }
        public int? FlagId { get; set; }
    }
}
