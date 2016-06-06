using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Web.Areas.Wallet.Models
{
    public class WalletListVM
    {
        public List<WalletInfoVM> Wallets { get; set; }
        public string SearchTerm { get; set; }        
    }
}
