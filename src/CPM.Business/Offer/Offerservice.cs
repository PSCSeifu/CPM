using AutoMapper;
using CPM.Data.Offer;
using CpmLib.Business.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business.Offer
{
    public interface IOfferService : ICrudServiceBase<OfferInfoBM,OfferBM>
    {
        GetListResult<OfferBM> GetListById(int clientId);
        GetListResult<OfferBM> GetListBySearchTerm(int clientId, string searchTerm);
        GetListResult<OfferBM> GetOffer(int clientId, string searchTerm);
        GetListResult<OfferBM> GetOfferById(int offerId);
    }

    public class OfferService: CrudServiceBase<OfferInfoBM,OfferBM>, IOfferService
    {
        private  IOfferRepository _repository;
        private  IOfferValidator _validator;

        public OfferService()
        {
            _repository = new OfferRepository();
        }

        public OfferService(IOfferRepository repository,IOfferValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public GetListResult<OfferBM> GetListById( int clientId)
        {
            ModelMappings.Configure();
            try
            {
                var result = AutoMapper.Mapper.Map<List<OfferBM>>(_repository.GetList(clientId));
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

        public override GetItemResult<OfferBM> GetItem(int id)
        {
            try
            {
                ModelMappings.Configure();
                var result = Mapper.Map<OfferBM>(_repository.GetItem(id));
                return ServiceResultsHelper.FillGetItemResult(result);
            }
            catch (Exception ex)
            {
               return ServiceResultsHelper.FillGetItemResultForError<OfferBM>(ex);
            }
        }

        public override GetListResult<OfferInfoBM> GetList(int key, string searchTerm)
        {
           try
            {
                ModelMappings.Configure();
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    var result = Mapper.Map<List<OfferInfoBM>>(_repository.GetList(key,searchTerm));
                    return ServiceResultsHelper.FillGetListResult(result);
                }

                var resultEx = Mapper.Map<List<OfferInfoBM>>(_repository.GetList(key));
                return ServiceResultsHelper.FillGetListResult(resultEx);

            }
            catch(Exception ex)
            {
                return ServiceResultsHelper.FillGetListResultForError<OfferInfoBM>(ex);
            }
        }

        public override GetListResult<OfferInfoBM> GetList(int key)
        {
            return GetList(key, "");
        }

        public override ProcessResult Save(OfferBM item)
        {
            try
            {
                //Validation can be inserted here
                if (item.IsNew)
                {
                    _repository.Insert(Mapper.Map<OfferDM>(item));
                }
                else
                {
                    _repository.Update(Mapper.Map<OfferDM>(item));
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
