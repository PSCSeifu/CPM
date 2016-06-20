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
        GetListResult<OfferBM> GetListById(int clientId);
        GetListResult<OfferBM> GetListBySearchTerm(int clientId, string searchTerm);
        GetListResult<OfferBM> GetOffer(int clientId, string searchTerm);
        GetListResult<OfferBM> GetOfferById(int offerId);
    }

    public class OfferService: ServiceBase, IOfferService
    {
        private readonly IOfferRepository _repository;

        public OfferService()
        {
            _repository = new OfferRepository();
        }

        public OfferService(IOfferRepository repository)
        {
            _repository = repository;
        }

        public GetListResult<OfferBM> GetListById( int clientId)
        {
            ModelMappings.Configure();
            try
            {
                var result = AutoMapper.Mapper.Map<List<OfferBM>>(_repository.GetOffersByClientId(clientId));
                return ServiceResultsHelper.FillGetListResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetListResultForError<OfferBM>(ex);
            }
        }

        public GetListResult<OfferBM> GetListBySearchTerm(int clientId,string searchTerm)
        {
            ModelMappings.Configure();
            try
            {
                var result = AutoMapper.Mapper.Map<List<OfferBM>>(_repository.GetListBySearch(clientId,searchTerm));
                return ServiceResultsHelper.FillGetListResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetListResultForError<OfferBM>(ex);
            }
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
