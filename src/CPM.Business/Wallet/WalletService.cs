using CPM.Data.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business.Wallet
{
    public interface IWalletService
    {
        void GetWallet(string clientId, int walletId);
    }

    public class WalletService
    {
        private readonly IWalletRepository _repository;

        public WalletService(IWalletRepository repository )
        {
            _repository = repository;
        }

        public IEnumerable<WalletBM> GetListById(string clientId)
        {
            throw new  NotImplementedException();
        }

        public WalletBM GetWallet(string clientId, int walletId)
        {
            //GetItemResult<WalletBM>
            //void to PscLib.Business.Core.Service.GetListResult<
            throw new NotImplementedException();
        }
    }
}
