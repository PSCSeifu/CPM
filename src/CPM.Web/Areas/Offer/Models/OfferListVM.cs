using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Web.Areas.Offer.Models
{
    public class OfferListVM
    {
        public List<OfferInfoVM> Offers { get; set; } 
        public string SearchTerm { get; set; }
    }
}
