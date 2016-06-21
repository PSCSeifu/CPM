using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Entities
{
    [Table("Offer")]
    public class OfferEntity
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int WalletId { get; set; }
        public int? DefaultCurrencyId { get; set; }
        public DateTime DateCreated { get; set; } 
        public DateTime ExpiryDate { get; set; } 
        public string Name { get; set; }
        public string Detail { get; set; }
    }
}
