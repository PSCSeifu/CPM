using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpmLib.Data.Core
{

    public interface ICurdRepositoryBase<TInfo,TItem> : IRepositoryBase
        where TInfo : class
        where TItem : class
    {
        List<TInfo> GetList();
        TItem GetItem();
    }

    public abstract class CurdRepositoryBase<TInfo, TItem> : RepositoryBase,
        ICurdRepositoryBase<TInfo,TItem>  
        where TInfo : class
        where TItem : class
    {
        public virtual List<TInfo> GetList() { throw new NotImplementedException(); }
        public virtual TItem GetItem() { throw new NotImplementedException(); }
    }

   
}
