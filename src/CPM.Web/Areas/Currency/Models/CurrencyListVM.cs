using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPM.Web.Areas.Currency.Models
{
    public class CurrencyListVM
    {
        public List<CurrencyInfoVM> Currencies { get; set; }
        public string SearchTerm { get; set; }
    }
}
