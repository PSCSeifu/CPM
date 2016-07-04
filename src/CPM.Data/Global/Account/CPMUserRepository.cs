using AutoMapper;
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
                var dataModel = Mapper.Map<CPMUserDM>(entity);

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
            var entity = (from user in _context.CPMUsers
                          join client in _context.Clients on user.ClientId equals client.Id
                          where user.Username == username
                          select new { user, client.cpmModerate, client.cpmAutoBargain, client.cpmAnalytics, client.cpmForum, client.cpmNews, client.cpmEscrow })
                            .SingleOrDefault();

            if (entity != null)
            {
                var dataModel = Mapper.Map<CPMUserDM>(entity);

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

        public bool UserNameExists(string username)
        {
            return _context.CPMUsers.Any(u => u.Username == username);
        }

        #endregion

        #region _Modify

        public void InsertRecord(CPMUserEntity cpmUser)
        {
            _context.CPMUsers.Add(cpmUser);
            _context.SaveChanges();
        }

        public void UpdateRecord(CPMUserEntity cpmUser)
        {
            var entity = (from user in _context.CPMUsers
                          where user.Id == cpmUser.Id
                          select user).SingleOrDefault();

            entity = Mapper.Map(cpmUser, entity);

            _context.SetModified(entity);
            _context.SaveChanges();
        }

        public void DeleteRecord(CPMUserEntity cpmUser)
        {
            var entity = (from user in _context.CPMUsers
                          where user.Id == cpmUser.Id
                          select user).SingleOrDefault();

            entity = Mapper.Map(cpmUser, entity);

            _context.Remove(entity);
            _context.SaveChanges();
        }
        #endregion
    }
}
