﻿using AutoMapper;
using CPM.Data.Currency;
using CPM.Data.Entities;
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
            CreateMap<WalletEntity, WalletDM>();
            CreateMap<WalletTypeEntity, WalletTypeDM>();

            CreateMap<OfferEntity, OfferDM>();
            CreateMap<OfferDM, OfferInfoDM>();

            CreateMap<CurrencyEntity, CurrencyDM>();
            CreateMap<CurrencyDM, CurrencyInfoDM>();
        }

        //public static void Configure()
        //{
        //    Mapper.Initialize(Configure =>
        //   {
        //       Configure.CreateMap<WalletEntity, WalletDM>();
        //       Configure.CreateMap<WalletTypeEntity, WalletTypeDM>();
               
        //       Configure.CreateMap<OfferEntity, OfferDM>();
        //       Configure.CreateMap<OfferDM, OfferInfoDM>();

        //       Configure.CreateMap<CurrencyEntity, CurrencyDM>();
        //       Configure.CreateMap<CurrencyDM, CurrencyInfoDM>();
        //   });
        //}
    }
}
