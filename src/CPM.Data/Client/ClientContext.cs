using CPM.Data.Entities;
using CpmLib.Data.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        public ClientContext()
        {
            Database.EnsureCreated();
            /*
             SERIOUS ERROR:
             Cannot remove key {'Id'} from entity type 'Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser' 
because it is referenced by a foreign key in entity type
 'Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>'. 
All foreign keys must be removed or redefined before the referenced key can be removed.
             */
        }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    //    builder.Entity<IdentityUser>().HasKey(i => i.Id);

        //    //    builder.Entity<IdentityUser>().Property(i => i.Id).ValueGeneratedOnAdd();

        //    builder.Entity<ClientEntity>().Property(i => i.ClientId).IsRequired(true);
        //    builder.Entity<IdentityUser>().Property(i => i.Id).IsRequired(true);
            

        //    base.OnModelCreating(builder);
        //}

        public DbSet<ClientEntity> Clients { get; set; }

      
    }
}
