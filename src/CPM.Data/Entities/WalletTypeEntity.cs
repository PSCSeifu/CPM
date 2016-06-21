using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Entities
{
    [Table("WalletType")]
    public class WalletTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
        //SubscriptionTier
    }
}
