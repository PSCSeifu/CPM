using CPM.Data.Entities;
using CPM.Data.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Web.Areas.Wallet.Models
{
    public class WalletInfoVM
    {
        public decimal Balance { get; set; }
        public int CurrencyId { get; set; }
        public int ClientId { get; set; }
        public string Currency { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int Id { get; set; }
        public int ImageId { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        public string Name { get; set; }
        // public WalletTypeEntity Type { get; set; } = new WalletTypeEntity();

    }
}
