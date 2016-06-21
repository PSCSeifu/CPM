using CPM.Business.Offer;
using CPM.Business.Wallet;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPM.Web
{
    public class DependecyInjection
    {
        public static void Configure(IServiceCollection services)
        {
            #region " Global "

            #endregion

            #region Wallet
            services.AddScoped<IWalletService, WalletService>();            
            #endregion

            #region Offer           
            services.AddScoped<IOfferService, OfferService>();
            #endregion
        }
    }
}
