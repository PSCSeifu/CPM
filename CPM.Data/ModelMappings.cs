using AutoMapper;
using CPM.Data.Entities;
using CPM.Data.Offer;
using CPM.Data.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPM.Data
{
    public class ModelMappings
    {
        public static void Configure()
        {
            Mapper.Initialize(Configure =>
           {
               Configure.CreateMap<WalletEntity, WalletDM>();
               Configure.CreateMap<WalletTypeEntity, WalletTypeDM>();



               Configure.CreateMap<OfferEntity, OfferDM>();
               Configure.CreateMap<OfferDM, OfferInfoDM>();
           });
        }
    }
}
