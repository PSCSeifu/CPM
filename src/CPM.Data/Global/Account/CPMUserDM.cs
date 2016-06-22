using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPM.Data.Global.Account
{
    public class CPMUserDM
    {
        public int Id { get; set; }
        public int ClientId { get; set; }

        public int? WebUserType { get; set; }
        public int? WebSubscriptionType { get; set; }
        public bool AgreedOnTerms { get; set; }

        public bool? cpmModerate { get; set; }
        public bool? cpmAutoBargain { get; set; }
        public bool? cpmAnalytics { get; set; }
        public bool? cpmNews { get; set; }
    }
}
