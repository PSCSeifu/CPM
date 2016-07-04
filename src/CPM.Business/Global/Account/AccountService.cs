using AutoMapper;
using CPM.Data.Entities;
using CPM.Data.Global.Account;
using CpmLib.Business.Core.Service;
using System;

namespace CPM.Business.Global.Account
{
    public interface IAccountService : IServiceBase
    {
        ProcessResult CreateUser(CPMUserBM user);
        ProcessResult UpdateUser(CPMUserBM user);
        ProcessResult DelteUser(CPMUserBM user);
        GetItemResult<CPMUserBM> FinduserById(int id);
        GetItemResult<CPMUserBM> FinduserByUsername(string username);
        GetItemResult<bool> UserExists(string username);
    }

    public class AccountService :IAccountService
    {
        #region _Constructor_

        private CPMUserRepository _repo;

        public AccountService()
        {
            _repo = new CPMUserRepository();
        }

        public AccountService(CPMUserRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region _Methods_

        public ProcessResult CreateUser (CPMUserBM user)
        {
            try
            {
                _repo.InsertRecord(Mapper.Map<CPMUserEntity>(user));

                return ServiceResultsHelper.FillProcessResult();
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillProcessResultForError(ex);
            }
        }

        public ProcessResult UpdateUser(CPMUserBM user)
        {
            try
            {
                _repo.UpdateRecord(Mapper.Map<CPMUserEntity>(user));

                return ServiceResultsHelper.FillProcessResult();
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillProcessResultForError(ex);
            }
        }

        public ProcessResult DelteUser(CPMUserBM user)
        {
            try
            {
                _repo.DeleteRecord(Mapper.Map<CPMUserEntity>(user));

                return ServiceResultsHelper.FillProcessResult();
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillProcessResultForError(ex);
            }
        }

        public GetItemResult<CPMUserBM> FinduserById(int id)
        {
            try
            {
                return ServiceResultsHelper.FillGetItemResult<CPMUserBM>(Mapper.Map<CPMUserBM>(_repo.GetRecordById(id)));
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetItemResultForError<CPMUserBM>(ex);
            }
        }

        public GetItemResult<CPMUserBM> FinduserByUsername(string username)
        {
            try
            {
                return ServiceResultsHelper.FillGetItemResult<CPMUserBM>(Mapper.Map<CPMUserBM>(_repo.GetUserByUserName(username)));
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetItemResultForError<CPMUserBM>(ex);
            }
        }

        public GetItemResult<bool> UserExists(string username)
        {
            try
            {
                return ServiceResultsHelper.FillGetItemResult(_repo.UserNameExists(username));
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetItemResultForError<bool>(ex);
            }
        }



        #endregion
    }
}
