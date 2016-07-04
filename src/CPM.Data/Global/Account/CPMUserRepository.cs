using CPM.Data.Entities;
using CPM.Data.Global.Account;
using CpmLib.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPM.Data.Global.Account
{
    public interface ICPMUserRepositoryBase : IRepositoryBase
    {

    }

    public class CPMUserRepository : RepositoryBase , ICPMUserRepositoryBase
    {
        private readonly CPMUserContext _context;

        public CPMUserRepository(CPMUserContext context)
        {
            _context = context;
        }

        public CPMUserRepository()
        {
            _context = new CPMUserContext();
        }

        #region _Get_

        public CPMUserDM GetRecordById(int id)
        {
            var entity = (from user in _context.CPMUsers
                          join client in _context.Clients on user.ClientId equals client.Id
                          where user.Id == id
                          select new { user, client.cpmModerate, client.cpmAutoBargain, client.cpmAnalytics, client.cpmForum, client.cpmNews, client.cpmEscrow})
                          .SingleOrDefault();

            if (entity != null){
                var dataModel = AutoMapper.Mapper.Map<CPMUserDM>(entity);

                dataModel.cpmModerate = entity.cpmModerate ?? false;
                dataModel.cpmAutoBargain = entity.cpmAutoBargain ?? false;
                dataModel.cpmAnalytics = entity.cpmAnalytics ?? false;
                dataModel.cpmForum = entity.cpmForum ?? false;
                dataModel.cpmNews = entity.cpmNews ?? false;
                dataModel.cpmEscrow = entity.cpmEscrow ?? false;

                return dataModel;
            }

            return null;
        }

        public CPMUserDM GetUserByUserName(string username)
        {
            return null;
        }

        public bool UserNameExists(string username)
        {
            return false;
        }

        #endregion

        #region _Modify

        public void InsertRecord(CPMUserEntity cpmUser)
        {

        }

        public void UpdateRecord(CPMUserEntity cpmUser)
        {

        }

        public void DeleteRecord(CPMUserEntity cpmUser)
        {

        }
        #endregion
    }
}
