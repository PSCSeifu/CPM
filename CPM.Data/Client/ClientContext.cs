using CPM.Data.Entities;
using CpmLib.Data.Core;
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
        }

       public  DbSet<ClientEntity> Clients { get; set; }
    }
}
