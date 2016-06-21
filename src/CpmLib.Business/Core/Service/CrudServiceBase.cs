using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmLib.Business.Core.Service
{
    public interface ICrudServiceBase<TInfo, TItem> : IServiceBase
    {
        GetListResult<TInfo> GetList();
        GetListResult<TInfo> GetList(string searchTerm);
        GetListResult<TInfo> GetList(int key);
        GetListResult<TInfo> GetList(int key, string searchTerm);
        GetItemResult<TItem> GetItem(int id);
        ProcessResult Save(TItem item);
        ProcessResult Delete(int id);
    }

    public abstract class CrudServiceBase<TInfo, TItem> : ServiceBase,
                                                        ICrudServiceBase<TInfo, TItem>
    {
        public virtual GetListResult<TInfo> GetList() { throw new NotImplementedException(); }
        public virtual GetListResult<TInfo> GetList(string searchTerm) { throw new NotImplementedException(); }
        public virtual GetListResult<TInfo> GetList(int key) { throw new NotImplementedException(); }
        public virtual GetListResult<TInfo> GetList(int key, string searchTerm) { throw new NotImplementedException(); }
        public virtual GetItemResult<TItem> GetItem(int id) { throw new NotImplementedException(); }
        public virtual ProcessResult Save(TItem item) { throw new NotImplementedException(); }
        public virtual ProcessResult Delete(int id) { throw new NotImplementedException(); }
    }
}
