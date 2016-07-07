using AutoMapper;
using CPM.Business.Currency;
using CPM.Business.Global.Account;
using CPM.Business.Offer;
using CPM.Business.Wallet;
using CPM.Data.Global.Account;
using CPM.Data.Wallet;
using CPM.Web.Areas.Currency.Models;
using CPM.Web.Areas.Offer.Models;
using CPM.Web.Areas.Wallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPM.Web
{
    public class WebModelMappings :Profile
    {
        public WebModelMappings()
        {
            #region " CPMUsers  "
            CreateMap<CPMUserBM, CPMUserDM>();
            #endregion

            #region " Wallets "
            CreateMap<WalletTypeBM, WalletTypeVM>();
            CreateMap<WalletInfoBM, WalletInfoVM>();
            CreateMap<WalletBM, WalletVM>();
            #endregion

            #region " Offers "
            CreateMap<OfferInfoBM, OfferInfoVM>();
            CreateMap<OfferBM, OfferVM>();
            #endregion

            #region " Currency "         
            CreateMap<CurrencyInfoBM, CurrencyInfoVM>();
            CreateMap<CurrencyBM, CurrencyVM>();

            CreateMap<PriceMarketBM, PriceMarketVM>();
            CreateMap<PriceTickerBM, PriceTickerVM>();           
            CreateMap<PriceTickerInfoBM, PriceTickerInfoVM>();

            CreateMap<FiatBM, FiatVM>();
            #endregion

            #region Global

            #endregion
        }
        //public static void Configure()
        //{
        //    Mapper.Initialize(config =>
        //  {
        //      #region " Wallets "
        //      config.CreateMap<WalletTypeBM, WalletTypeVM>();              
        //      config.CreateMap<WalletInfoBM, WalletInfoVM>();
        //      config.CreateMap<WalletBM, WalletVM>();
        //      #endregion

        //      #region " Offers "
        //      config.CreateMap<OfferInfoBM, OfferInfoVM>();
        //      #endregion

        //      #region " Currency "
        //      config.CreateMap<CurrencyInfoBM, CurrencyInfoVM>();
        //      #endregion

        //      #region Global

        //      #endregion
        //  });
        //}
    }
}
