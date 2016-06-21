using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPM.Data.Entities
{
    [Table("WalletLedger")]
    public class WalletLedgerEntity
    {
        public bool? IsAutomated { get; set; }
        public decimal BalanceChange { get; set; }
        public int Id { get; set; }
        public DateTime LedgerDateTime { get; set; }
        public int? LedgerType { get; set; }
        public int WalletId { get; set; }
        public int TransactionId { get; set; }
    }
}