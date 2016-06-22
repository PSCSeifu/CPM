using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPM.Data.Entities
{
    [Table("Wallet")]
    public class WalletEntity
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
        public bool LockOnNotificationLimit { get; set; }
        public bool LockOnSpendLimit { get; set; }
        public bool LockOnWithdrawLimit { get; set; }
        public string Name { get; set; }
        public decimal NotificationLimit { get; set; }
        public decimal SpendLimit { get; set; }
        public int? WalletTypeId { get; set; }
        public decimal WithdrawLimit { get; set; }
    }
}