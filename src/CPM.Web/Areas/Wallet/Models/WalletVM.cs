using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Web.Areas.Wallet.Models
{
    public class WalletTypeVM
    {
        public int Category { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class WalletVM
    {
        public decimal Balance { get; set; }
        public string ClientId { get; set; }
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        public bool IsNew { get; set; }
        public bool LockOnNotificationLimit { get; set; }
        public bool LockOnSpendLimit { get; set; }
        public bool LockOnWithdrawLimit { get; set; }
        public string Name { get; set; }
        public decimal NotificationLimit { get; set; }
        public decimal SpendLimit { get; set; }
        public decimal WithdrawLimit { get; set; }
        public WalletTypeVM Type { get; set; } = new WalletTypeVM();
    }
}
