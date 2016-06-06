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
    public interface IWalletService
    {
        WalletBM GetWallet(string clientId, int walletId);
        GetListResult<WalletBM> GetListById(string clientId);
    }

    public class WalletService
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

        public GetListResult<WalletBM> GetListById(string clientId, int walletId)
        {
            try
            {
                var result = Mapper.Map<List<WalletBM>>(_repository.GetWalletByClientIdAndWalletId(clientId, walletId));
                return ServiceResultsHelper.FillGetListResult<WalletBM>(result);
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetListResultForError<WalletBM>(ex);
            }
        }

        public WalletBM GetWallet(string clientId, int walletId)
        {
            //GetItemResult<WalletBM>
            //void to PscLib.Business.Core.Service.GetListResult<
            throw new NotImplementedException();
        }
    }
}
