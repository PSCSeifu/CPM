using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CPM.Data.Global.Account
{
    public class CPMUserDM
    {
       
        public bool AgreedOnTerms { get; set; }
        public int ClientId { get; set; }
        public bool? cpmAnalytics { get; set; }
        public bool? cpmAutoBargain { get; set; }
        public bool? cpmModerate { get; set; }
        public bool? cpmNews { get; set; }
        public bool? cpmForum { get; set; }
        public bool? cpmEscrow { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public DateTime? LastSawMessage { get; set; }
        public string Password2 { get; set; }
        [Column("Password")]
        public string PasswordHash { get; set; }

        public string Username { get; set; }
        public int? WebSubscriptionType { get; set; }
        public int? WebUserType { get; set; }
    }
}
