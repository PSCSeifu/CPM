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
    public interface IClientContext : IIdentityDBContextBase<ClientEntity>
    {
        DbSet<ClientEntity> Clients { get; set; }
    }

    public class ClientContext : IdentityDbContextBase<ClientEntity>, IClientContext
    {
        public ClientContext()
        {
            Database.EnsureCreated();
        }

       public  DbSet<ClientEntity> Clients { get; set; }
    }
}
