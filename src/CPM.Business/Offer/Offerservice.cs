using CPM.Data.Offer;
using CpmLib.Business.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business.Offer
{
    public interface IOfferService : IServiceBase
    {

    }

    public class Offerservice: ServiceBase, IOfferService
    {
        private readonly IOfferRepository _repository;

        public Offerservice()
        {
            _repository = new OfferRepository();
        }

        public Offerservice(IOfferRepository repository)
        {
            _repository = repository;
        }

        public GetListResult<OfferBM> GetListById( int clientId)
        {
            throw new NotImplementedException();
        }

        public GetListResult<OfferBM> GetListBySearchTerm(int clientId,string searchTerm)
        {
            throw new NotImplementedException();
        }

        public GetListResult<OfferBM> GetOffer(int clientId, string searchTerm)
        {
            throw new NotImplementedException();
        }

        public GetListResult<OfferBM> GetOfferById(int offerId)
        {
            throw new NotImplementedException();
        }
    }
}
