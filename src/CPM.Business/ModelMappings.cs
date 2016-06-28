using AutoMapper;
using CPM.Business.Currency;
using CPM.Business.Offer;
using CPM.Business.Wallet;
using CPM.Data.Currency;
using CPM.Data.Entities;
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
            CreateMap<WalletDM, WalletBM>();
            CreateMap<WalletInfoDM, WalletInfoBM>();
            CreateMap<WalletTypeDM, WalletTypeBM>();


            CreateMap<OfferDM, OfferBM>();
            CreateMap<OfferInfoDM, OfferInfoBM>();


            CreateMap<CurrencyDM, CurrencyBM>();
            CreateMap<CurrencyInfoDM, CurrencyInfoBM>();

        }

        //public static void Configure()
        //{
        //    Mapper.Initialize(config =>
        //   {
        //       config.CreateMap<WalletDM, WalletBM>();
        //       config.CreateMap<WalletInfoDM, WalletInfoBM>();
        //       config.CreateMap<WalletTypeDM, WalletTypeBM>();


        //       config.CreateMap<OfferDM, OfferBM>();               
        //       config.CreateMap<OfferInfoDM, OfferInfoBM>();


        //       config.CreateMap<CurrencyDM, CurrencyBM>();
        //       config.CreateMap<CurrencyInfoDM, CurrencyInfoBM>();               
        //   });

        //}
    }
}
