using AutoMapper;
using CPM.Business.Wallet;
using CPM.Data.Entities;
using CPM.Data.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business
{
    public static class ModelMappings
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
           {
               config.CreateMap<WalletDM, WalletBM>();
           });
       
        }
    }
}
