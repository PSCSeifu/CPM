using AutoMapper;
using CPM.Business.Currency;
using CPM.Business.Global.Account;
using CPM.Business.Offer;
using CPM.Business.Wallet;
using CPM.Data.Currency;
using CPM.Data.Entities;
using CPM.Data.Global.Account;
using CPM.Data.Offer;
using CPM.Data.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business
{
    public class BusinessModelMappings :Profile
    {
        public BusinessModelMappings()
        {
            #region _User_
            CreateMap<CPMUserDM, CPMUserBM>();
            CreateMap<CPMUserEntity, CPMUserBM>().ReverseMap();
            #endregion

            #region _Wallet_
            CreateMap<WalletDM, WalletBM>();
            CreateMap<WalletInfoDM, WalletInfoBM>();
            CreateMap<WalletTypeDM, WalletTypeBM>();
            #endregion

            #region _Offer_
            CreateMap<OfferDM, OfferBM>();
            CreateMap<OfferInfoDM, OfferInfoBM>();
            #endregion

            #region _Currency_
            CreateMap<CurrencyDM, CurrencyBM>();
            CreateMap<CurrencyInfoDM, CurrencyInfoBM>();
            CreateMap<PriceTickerBM, PriceTickerInfoBM >();
            CreateMap<FiatDM, FiatBM>();
            #endregion
        }
    }
}
