using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CpmLib.Data.Core
{
    public interface IIdentityDBContextBase<T>
    {
        void SetModified(object entity);
    }

    public abstract class IdentityDbContextBase<T>: IdentityDbContext, IIdentityDBContextBase<T>
    {
        IConfigurationRoot Configuration { get; set; }

        public IdentityDbContextBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");

            Configuration = builder.Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration["Data:CPMConnection"];
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }


        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //    builder.Entity<IdentityUser>().HasKey(i => i.Id);

            //    builder.Entity<IdentityUser>().Property(i => i.Id).ValueGeneratedOnAdd();
         
            //builder.Entity<IdentityUser>().Property(i => i.Id).IsRequired(true);


            base.OnModelCreating(builder);
        }

    }
}
