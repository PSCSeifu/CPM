using CPM.Data.Offer;
using CpmLib.Business.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business.Offer
{
    public interface IOfferValidator : IValidatorBase<OfferBM>
    {

    }

    public class OfferValidator:ValidatorBase<OfferBM>, IOfferValidator
    {
        private  IOfferRepository _repo;

        public OfferValidator(IOfferRepository repo)
        {
            _repo = repo;
        }

        protected override void AddValidations()
        {
            
        }
    }
}
