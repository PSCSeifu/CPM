using CPM.Data.Entities;
using CpmLib.Data.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CPM.Data.Global.Account
{
    public interface IUserContext : IDbContextBase
    {
        DbSet<CPMUserEntity> CPMUsers { get; set; }
        DbSet<ClientEntity> Clients { get; set; }
    }

    public class CPMUserContext : DbContextBase, IUserContext
    {
        public CPMUserContext()
        {
            Database.EnsureCreated();  
        }

        public DbSet<CPMUserEntity> CPMUsers { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        
    }
}
