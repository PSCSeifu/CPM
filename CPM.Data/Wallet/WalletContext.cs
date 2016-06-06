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
        DbSet<WalletEntity> Wallet { get; set; }
    } 


    public class WalletContext : DbContextBase, IWalletContext
    {
        public DbSet<WalletEntity> Wallet { get; set; }
    }
}
