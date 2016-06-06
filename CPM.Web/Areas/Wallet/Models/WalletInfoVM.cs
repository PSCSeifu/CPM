using CPM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Web.Areas.Wallet.Models
{
    public class WalletInfoVM
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Balance { get; set; }
        public bool IsLocked { get; set; }
        public WalletType Type { get; set; }
        public WalletSettings WalletSettings { get; set; }


    }
}
