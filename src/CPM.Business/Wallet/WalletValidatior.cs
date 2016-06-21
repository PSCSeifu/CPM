using CPM.Data.Wallet;
using CpmLib.Business.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business.Wallet
{

    public interface IWalletValidator : IValidatorBase<WalletBM>
    {

    }

    public class WalletValidatior : ValidatorBase<WalletBM>, IWalletValidator
    {
        private  IWalletRepository _repo;

        public WalletValidatior(IWalletRepository repo)
        {
            _repo = repo;
        }    

        protected override void AddValidations()
        {

        }
    }
}
