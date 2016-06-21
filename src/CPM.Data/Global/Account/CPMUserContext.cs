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
    public interface IUserContext 
    {
        int SaveChanges();
        DbSet<CPMUserEntity> CPMUsers { get; set; }
    }

    public class CPMUserContext : IdentityDbContextBase<CPMUserEntity>, IUserContext
    {
        public CPMUserContext()
        {
            //
        }

        public DbSet<CPMUserEntity> CPMUsers { get; set; }
        
    }
}
