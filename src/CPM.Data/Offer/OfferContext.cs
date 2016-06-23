using CPM.Data.Entities;
using CpmLib.Data.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Offer
{
    public interface IOfferContext : IDbContextBase
    {
        DbSet<OfferEntity> Offers { get; set; }
        DbSet<ClientEntity> Clients { get; set; }
        DbSet<WalletEntity> Wallets { get; set; }
        DbSet<CurrencyEntity> Currencies { get; set; }

    }

    public class OfferContext :DbContextBase, IOfferContext
    {
        public OfferContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<OfferEntity> Offers { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<WalletEntity> Wallets { get; set; }
        public DbSet<CurrencyEntity> Currencies { get; set; }
    }
}
