using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Web.Areas.Offer.Models
{
    public class OfferInfoVM
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int WalletId { get; set; }
        public int? DefaultCurrencyId { get; set; }
        public int WebUserType { get; set; }
        public string ClientName { get; set; }
        public string WalletName { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
    }
}
