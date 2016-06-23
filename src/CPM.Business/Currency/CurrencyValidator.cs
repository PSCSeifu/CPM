using CpmLib.Business.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business.Currency
{
    public interface ICurrencyValidator : IValidatorBase<CurrencyBM>
    {

    }

    public class CurrencyValidator : ValidatorBase<CurrencyBM>, ICurrencyValidator
    {
        private  ICurrencyValidator _repo;

        public CurrencyValidator(ICurrencyValidator repo)
        {
            _repo = repo;
        }

        protected override void AddValidations()
        {
            
        }
    }
}
