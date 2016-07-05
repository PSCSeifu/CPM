using CpmLib.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CpmLib.Data.Core
{
    public interface IDbContextBase
    {
        int SaveChanges();
        void SetModified(object entity);
        DatabaseFacade Database { get; }
    }

    public abstract class DbContextBase : DbContext, IDbContextBase
    {
         IConfiguration Configuration { get;  set; }

        public DbContextBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");

            Configuration = builder.Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration["Data:CPMConnection"];
            //optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("CPM.Web"));
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly(Configuration["Data:MigrationAssembly"]));            
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
