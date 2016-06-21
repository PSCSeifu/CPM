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
        public int Id { get; set; } = 0;
        public string ClientId { get; set; } = "";
        public string Name { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string Currency { get; set; } = "";
        public decimal Balance { get; set; } = 0;
        public bool IsLocked { get; set; } = false;
       // public WalletTypeEntity Type { get; set; } = new WalletTypeEntity();

    }
}
