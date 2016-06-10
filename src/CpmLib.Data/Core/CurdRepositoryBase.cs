using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpmLib.Data.Core
{

    public interface ICrudRepositoryBase<TInfo, TItem> : IRepositoryBase
                                                   where TInfo : class
                                                   where TItem : class
    {
        List<TInfo> GetList();
        List<TInfo> GetList(string searchTerm);
        List<TInfo> GetList(int key);
        List<TInfo> GetList(int key, string searchTerm);
        TItem GetItem(int id);
        int? Insert(TItem item);
        void Update(TItem item);
        void Delete(int id);
    }

    public abstract class CrudRepositoryBase<TInfo, TItem> : RepositoryBase,
                                                        ICrudRepositoryBase<TInfo, TItem>
                                                        where TInfo : class
                                                        where TItem : class
    {
        public virtual List<TInfo> GetList() { throw new NotImplementedException(); }
        public virtual List<TInfo> GetList(string searchTerm) { throw new NotImplementedException(); }
        public virtual List<TInfo> GetList(int key) { throw new NotImplementedException(); }
        public virtual List<TInfo> GetList(int key, string searchTerm) { throw new NotImplementedException(); }
        public virtual TItem GetItem(int id) { throw new NotImplementedException(); }
        public virtual int? Insert(TItem item) { throw new NotImplementedException(); }
        public virtual void Update(TItem item) { throw new NotImplementedException(); }
        public virtual void Delete(int id) { throw new NotImplementedException(); }
    }


}
