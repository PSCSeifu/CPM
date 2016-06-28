using AutoMapper;
using CPM.Data.Wallet;
using CpmLib.Business.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business.Wallet
{
    public interface IWalletService :ICrudServiceBase<WalletInfoBM,WalletBM>
    {
        GetItemResult<WalletBM> GetWallet(int clientId, int walletId);
        GetListResult<WalletBM> GetListBySearchTerm(int clientId, string searchTerm);
        GetListResult<WalletBM> GetListById(int clientId);
        GetItemResult<WalletBM> GetWalletById(int walletId);
    }

    public class WalletService : CrudServiceBase<WalletInfoBM, WalletBM>, IWalletService
    {
        private  IWalletRepository _repository;
        private  IWalletValidator _validator;

        public WalletService()
        {
            _repository = new WalletRepository();
        }

        public WalletService(IWalletRepository repository,IWalletValidator validator )
        {
            _repository = repository;
            _validator = validator;
        }

        public GetListResult<WalletBM> GetListById(int clientId)
        {            
            //ModelMappings.Configure();
            try
            {
                var result = Mapper.Map<List<WalletBM>>(_repository.GetWalletsByClientId(clientId));
                return ServiceResultsHelper.FillGetListResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetListResultForError<WalletBM>(ex);
            }
        }

        public GetListResult<WalletBM> GetListBySearchTerm(int clientId, string searchTerm)
        {
            //ModelMappings.Configure();
            try
            {
                var result = Mapper.Map<List<WalletBM>>(_repository.GetWalletsBySearchTerm(clientId,searchTerm));
                return ServiceResultsHelper.FillGetListResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetListResultForError<WalletBM>(ex);
            }
        }

        public GetItemResult<WalletBM> GetWallet(int clientId, int walletId)
        {
            //ModelMappings.Configure();
            try
            {
                var result = Mapper.Map<WalletBM>(_repository.GetWalletByClientIdAndWalletId(clientId,walletId));
                return ServiceResultsHelper.FillGetItemResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetItemResultForError<WalletBM>(ex);
            }           
        }

        public GetItemResult<WalletBM> GetWalletById( int walletId)
        {
            //ModelMappings.Configure();
            try
            {
                var result = Mapper.Map<WalletBM>(_repository.GetWalletByWalletId( walletId));
                return ServiceResultsHelper.FillGetItemResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetItemResultForError<WalletBM>(ex);
            }
        }

        //CRUD

        public override ProcessResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return ServiceResultsHelper.FillProcessResult(null);
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillProcessResultForError(ex);
            }
        }

        public override GetItemResult<WalletBM> GetItem(int id)
        {
           try
            {
                //ModelMappings.Configure();
                var result = Mapper.Map<WalletBM>(_repository.GetItem(id));
                return ServiceResultsHelper.FillGetItemResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetItemResultForError<WalletBM>(ex);
            }
        }

        public override GetListResult<WalletInfoBM> GetList(int key, string searchTerm)
        {
            try
            {
                //ModelMappings.Configure();
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    var result = Mapper.Map<List<WalletInfoBM>>(_repository.GetList(key, searchTerm));
                    return ServiceResultsHelper.FillGetListResult(result);
                }

                var resultEx = Mapper.Map<List<WalletInfoBM>>(_repository.GetList(key));
                return ServiceResultsHelper.FillGetListResult(resultEx);
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetListResultForError<WalletInfoBM>(ex);
            }
        }

        public override ProcessResult Save(WalletBM item)
        {
            try
            {
                //validation optional
                if (item.IsNew)
                {
                    _repository.Insert(Mapper.Map<WalletDM>(item));
                }
                else
                {
                    _repository.Update(Mapper.Map<WalletDM>(item));
                }

                return ServiceResultsHelper.FillProcessResult(_validator.Validations);
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillProcessResultForError(ex);
            }
        }


    }
}
