using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Entities
{
    public class WalletEntity
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Balance { get; set; }       
        public bool IsLocked { get; set; }
        public string Currency { get; set; }
        public WalletType Type { get; set; }
        public WalletSettings WalletSettings { get; set; }
    }

    public class WalletType
    {     
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class WalletSettings
    {     
        public decimal SpendLimit { get; set; }
        public decimal WithdrawLimit { get; set; }
        public decimal NotificationLimit { get; set; }
        public bool LockOnSpendLimit { get; set; }
        public bool LockOnNotificationLimit { get; set; }
        public bool LockOnWithdrawLimit { get; set; }
    }
}
