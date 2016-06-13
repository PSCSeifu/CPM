using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CPM.Data.Entities
{
    [Table("Client")]
    public class ClientEntity : IdentityUser
    {
        public int ClientId { get; set; }       

        public int? WebUserType { get; set; }
        public int? WebSubscriptionType { get; set; }
        public bool? AgreedOnTerms { get; set; }
        public bool? Suspended { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? DateRegistered { get; set; }

        public string NickName { get; set; }
        public string ForumUserName { get; set; }


        public bool? eMarketData { get; set; }
        public bool? eForum { get; set; }
        public bool? eAnalytics { get; set; }
        public bool? eNews { get; set; }
        
    }
}
