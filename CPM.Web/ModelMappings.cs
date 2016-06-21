using AutoMapper;
using CPM.Business.Offer;
using CPM.Business.Wallet;
using CPM.Data.Wallet;
using CPM.Web.Areas.Offer.Models;
using CPM.Web.Areas.Wallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPM.Web
{
    public class ModelMappings
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
          {
              #region " Wallets "
               //config.CreateMap<WalletBM, WalletInfoVM>();
              // config.CreateMap<List<WalletBM>, WalletListVM>();
              config.CreateMap<List<WalletBM>, List<WalletInfoVM>>();
              #endregion

              #region " Offers "
              config.CreateMap<OfferBM, OfferInfoVM>();
              #endregion
          });
        }
    }
}
