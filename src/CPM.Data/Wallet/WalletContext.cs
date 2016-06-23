using CPM.Data.Entities;
using CpmLib.Data.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Wallet
{
    public interface IWalletContext : IDbContextBase
    {
        DbSet<WalletEntity> Wallets { get; set; }
        DbSet<WalletTypeEntity> WalletTypes { get; set; }

        DbSet<OfferEntity> Offers { get; set; }
        DbSet<ClientEntity> Clients { get; set; }
        DbSet<CurrencyEntity> Currency { get; set; }
    }


    public class WalletContext : DbContextBase, IWalletContext
    {
        public WalletContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<WalletEntity> Wallets { get; set; }
        public DbSet<WalletTypeEntity> WalletTypes { get; set; }

        public DbSet<OfferEntity> Offers { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }        
        public DbSet<CurrencyEntity> Currency { get; set; }
    }
}
