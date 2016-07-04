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
    public class ClientEntity 
    {
        //public override string Id { get; set; }
        public int Id { get; set; }
        //public string UserId { get; set; }
        //public int? WebUserType { get; set; }
        //public int? WebSubscriptionType { get; set; }
        //public bool? AgreedOnTerms { get; set; }
        //public bool? Suspended { get; set; }
        //public DateTime? ExpiryDate { get; set; }
        //public DateTime? DateRegistered { get; set; }

        public string NickName { get; set; }
        public string ForumUserName { get; set; }

        public bool? cpmModerate { get; set; }
        public bool? cpmAutoBargain { get; set; }
        public bool? cpmAnalytics { get; set; }
        public bool? cpmForum { get; set; }
        public bool? cpmNews { get; set; }
        public bool? cpmEscrow { get; set; }

    }
}
