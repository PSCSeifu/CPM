using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business.Common.Enums
{
    public enum WebUserType
    {
        Customer,
        Vendor,
        EscrowAgent,
        Resolver

    }

    public enum WebSubscriptionType
    {
        Basic,
        Silver,
        Gold,
        Premium
    }

    public enum IncorporationType
    {
        [Description("Ltd")]
        LimitedLiability,
        Private
    }

    public enum BusinessCategory
    {
        Services,
        Commodities,

    }

    public enum BusinessSector
    {
        Agriculture,

    }

}
