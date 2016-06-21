using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Web.Areas.Wallet.Models
{
    public class WalletVM
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Balance { get; set; }
        public bool IsLocked { get; set; }
        public string Currency { get; set; }
        public WalletTypeVM Type { get; set; }

        public bool IsNew { get; set; }
    }

    public class WalletTypeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
    }

}
