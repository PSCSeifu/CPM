using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPM.Web.Areas.Currency.Models
{
    public class CurrencyInfoVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public PriceTickerInfoVM PriceTickerInfo { get; set; } 
    }

    public class PriceTickerInfoVM
    {
        public string CryptoCode { get; set; }
        public string FiatCode { get; set; }

       // [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal Price { get; set; }
        

        public decimal Volume { get; set; }
      
        public decimal Change { get; set; }        

        public DateTime DateTime { get; set; } 
        public bool Success { get; set; }
        public string Error { get; set; }

        public PriceTickerInfoVM()
        {

        }
    }
}
