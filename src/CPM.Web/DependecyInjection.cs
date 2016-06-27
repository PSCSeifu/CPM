using CPM.Business.Currency;
using CPM.Business.Offer;
using CPM.Business.Wallet;
using CPM.Data.Global.Account;
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

            #region " CPMUser "
            services.AddScoped<CPMUserContext, CPMUserContext>();
            #endregion

            #region " Wallet "
            services.AddScoped<IWalletService, WalletService>();            
            #endregion

            #region " Offer "         
            services.AddScoped<IOfferService, OfferService>();
            #endregion

            #region " Currency " 
            services.AddScoped<ICurrencySerivce, CurrencyService>();
            #endregion

            #region " Global "
            //services.AddScoped<ISessionHelper, SessionHelper>();
            #endregion


        }
    }
}
