using CPM.Business.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Web.Common.Session
{
    public class SessionCPMUserVM
    {
        public int Id { get; set; }
        public int ClientId { get; set; }

        public WebUserType WebUserType { get; set; }
        public WebSubscriptionType WebSubscriptionType { get; set; }
        public bool AgreedOnTerms { get; set; }

        public bool? cpmModerate { get; set; }
        public bool? cpmAutoBargain { get; set; }
        public bool? cpmAnalytics { get; set; }
        public bool? cpmForum { get; set; }
        public bool? cpmNews { get; set; }
        public bool? cpmEscrow { get; set; }

        public List<string> Products
        {
            get
            {
                var list = new List<string>();

                switch (WebSubscriptionType)
                {
                    case WebSubscriptionType.Basic:
                        list.Add("cpmForum"); list.Add("cpmMember");
                        break;
                    case WebSubscriptionType.Silver:
                        list.Add("cpmForum");
                        list.Add("cpmNews");
                        break;
                    case WebSubscriptionType.Gold:
                        list.Add("cpmForum");
                        list.Add("cpmNews");
                        list.Add("cpmAnalytics");
                        break;
                    default:
                        break;
                }

                if (WebUserType == WebUserType.Customer &&
                    WebSubscriptionType == WebSubscriptionType.Gold)
                {
                    list.Add("cpmAutoBargain");
                }

                if(WebUserType == WebUserType.Vendor &&
                    WebSubscriptionType == WebSubscriptionType.Gold)
                {
                    list.Add("cpmAutoBargain");
                }

                if (WebUserType == WebUserType.EscrowAgent &&
                    WebSubscriptionType == WebSubscriptionType.Gold)
                {
                    list.Add("cpmEscrow");
                }
                if (WebUserType == WebUserType.Resolver &&
                    WebSubscriptionType == WebSubscriptionType.Gold)
                {
                    list.Add("cpmModerate");
                }

                return list;
            }
        }
    }
}
