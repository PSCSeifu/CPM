using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Test.Fakes
{
    public class FakeDbSet<TEntity> : DbSet<TEntity> where TEntity : class
    {
        ObservableCollection<TEntity> _data;
        IQueryable _query;

        public FakeDbSet()
        {
            _data = new ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        //public  override TEntity Add(TEntity item)
        //{
        //    _data.Add(item);
        //    return item;
        //}
    }
}
