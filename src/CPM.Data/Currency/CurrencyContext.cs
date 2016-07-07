using CPM.Data.Entities;
using CpmLib.Data.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Currency
{
    public interface ICurrencyContext :IDbContextBase
    {
        DbSet<CurrencyEntity> Currency { get; set; }
        DbSet<FiatEntity> Fiat { get; set; }
    }

    public class CurrencyContext : DbContextBase, ICurrencyContext
    {
        IConfiguration Configuration { get; set; }

        public CurrencyContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<CurrencyEntity> Currency {get;set;}
        public DbSet<FiatEntity> Fiat { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = Configuration["Data:CPMConnection"];
        //    optionsBuilder.UseSqlServer(connectionString);
        //}
    }
}
