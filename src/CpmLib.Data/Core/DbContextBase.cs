﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpmLib.Data.Core
{
    public interface IDbContextBase
    {
        int SaveChanges();
    }

    //public abstract class DbContextBase : DbContext, IDbContextBase
    //{
    //}
}
