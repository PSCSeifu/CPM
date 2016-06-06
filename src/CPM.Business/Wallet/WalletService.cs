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
    public interface IWalletService :IServiceBase
    {
        GetItemResult<WalletBM> GetWallet(string clientId, int walletId);
        GetListResult<WalletBM> GetListById(string clientId);
    }

    public class WalletService :ServiceBase, IWalletService
    {
        private  IWalletRepository _repository;

        public WalletService()
        {
            _repository = new WalletRepository();
        }

        public WalletService(IWalletRepository repository )
        {
            _repository = repository;
        }

        public GetListResult<WalletBM> GetListById(string clientId)
        {            
            ModelMappings.Configure();
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

        public GetItemResult<WalletBM> GetWallet(string clientId, int walletId)
        {
            ModelMappings.Configure();
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
    }
}
