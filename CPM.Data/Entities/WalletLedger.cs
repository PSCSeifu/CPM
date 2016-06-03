using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Entities
{
    public class WalletLedger
    {
        public int Id { get; set; }
        public int WalletId { get; set; }

        public decimal BalanceChange { get; set; }
        public DateTime LedgeDateTime { get; set; }
        public string ChangeType { get; set; }
    }
}
