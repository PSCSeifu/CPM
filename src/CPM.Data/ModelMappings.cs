using AutoMapper;
using CPM.Data.Currency;
using CPM.Data.Entities;
using CPM.Data.Global.Account;
using CPM.Data.Offer;
using CPM.Data.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPM.Data
{
    public class DataModelMappings :Profile
    {
        public DataModelMappings()
        {
            #region _User_
            CreateMap<CPMUserEntity, CPMUserDM>();
            #endregion

            #region _Wallet_
            CreateMap<WalletEntity, WalletDM>();
            CreateMap<WalletTypeEntity, WalletTypeDM>();
            #endregion


            #region _Offer_        
            CreateMap<OfferEntity, OfferDM>();
            CreateMap<OfferDM, OfferInfoDM>();
            #endregion


            #region  _Currency 
            CreateMap<CurrencyEntity, CurrencyDM>();
            CreateMap<CurrencyDM, CurrencyInfoDM>();
            CreateMap<FiatEntity, FiatDM>();            
            #endregion            
        }
    }
}
