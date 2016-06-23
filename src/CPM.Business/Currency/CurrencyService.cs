using AutoMapper;
using CPM.Data.Currency;
using CpmLib.Business.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business.Currency
{
    public interface ICurrencySerivce : ICrudServiceBase<CurrencyInfoBM, CurrencyBM>
    {

    }

    public class CurrencyService : CrudServiceBase<CurrencyInfoBM, CurrencyBM>, ICurrencySerivce
    {
        private ICurrencyRepository _repository;
        private ICurrencyValidator _validator;

        public CurrencyService()
        {
            _repository = new CurrencyRepository();
        }

        public CurrencyService(ICurrencyRepository repository, ICurrencyValidator validator)
        {
            _repository = repository;
            _validator = validator;
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

        public override GetItemResult<CurrencyBM> GetItem(int id)
        {
            try
            {
                ModelMappings.Configure();
                var result = Mapper.Map<CurrencyBM>(_repository.GetItem(id));
                return ServiceResultsHelper.FillGetItemResult(result);
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetItemResultForError<CurrencyBM>(ex);
            }
        }

        public override GetListResult<CurrencyInfoBM>GetList(int key, string searchTerm)
        {
            try
            {
                ModelMappings.Configure();
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    var result = Mapper.Map<List<CurrencyInfoBM>>(_repository.GetList(key, searchTerm));
                    return ServiceResultsHelper.FillGetListResult(result);
                }

                var resultEx = Mapper.Map<List<CurrencyInfoBM>>(_repository.GetList(key));
                return ServiceResultsHelper.FillGetListResult(resultEx);
            }
            catch (Exception ex)
            {
                return ServiceResultsHelper.FillGetListResultForError<CurrencyInfoBM>(ex);
            }
        }
        
        public override ProcessResult Save(CurrencyBM item)
        {
            try
            {
                //validation optional
                if (item.IsNew)
                {
                    _repository.Insert(Mapper.Map<CurrencyDM>(item));
                }
                else
                {
                    _repository.Update(Mapper.Map<CurrencyDM>(item));
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
