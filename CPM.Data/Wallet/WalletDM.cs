using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Wallet
{
    public class WalletDM
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public bool IsLocked { get; set; }
        public string Currency { get; set; }
    }
}
