using CPM.Data.Entities;
using CpmLib.Data.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Client
{
    public interface IClientContext : IDbContextBase
    {
        DbSet<ClientEntity> Clients { get; set; }
    }

    public class ClientContext : DbContextBase, IClientContext
    {
        IConfiguration Configuration { get; set; }

        public ClientContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<ClientEntity> Clients { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = Configuration["Data:CPMConnection"];
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

    }
}
