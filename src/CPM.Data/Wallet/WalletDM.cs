using CPM.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Wallet
{
    public class WalletDM
    {
        public decimal Balance { get; set; }
        public int ClientId { get; set; }
        public string Currency { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int Id { get; set; }
        public int ImageId { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        //public List<WalletLedgerEntity> Ledgers { get; set; }
        public bool LockOnNotificationLimit { get; set; }
        public bool LockOnSpendLimit { get; set; }
        public bool LockOnWithdrawLimit { get; set; }
        public string Name { get; set; }
        public decimal NotificationLimit { get; set; }
        public decimal SpendLimit { get; set; }
        public WalletTypeDM Type { get; set; } = new WalletTypeDM();
        public decimal WithdrawLimit { get; set; }
        
    }

    public class WalletInfoDM
    {
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public DateTime DateModified { get; set; }
        public int Id { get; set; }
        public int ImageId { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        public string Name { get; set; }
        
    }

    public class WalletTypeDM
    {
        public int Category { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }

   

  

}
