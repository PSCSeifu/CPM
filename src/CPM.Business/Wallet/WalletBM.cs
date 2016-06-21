using CPM.Data.Entities;
using CPM.Data.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business.Wallet
{
    public class WalletBM
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Balance { get; set; }
        public bool IsLocked { get; set; }
        public string Currency { get; set; }
        public WalletTypeBM Type { get; set; }

        public bool IsNew { get; set; }
    }

    public class WalletTypeBM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
    }

    public class WalletInfoBM
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
        public string Name { get; set; }
    }
}
