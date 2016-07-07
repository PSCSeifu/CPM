using AutoMapper;
using CPM.Data.Entities;
using CpmLib.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Currency
{
    public interface ICurrencyRepository:ICrudRepositoryBase<CurrencyInfoDM,CurrencyDM>
    {

    }

    public class CurrencyRepository : CrudRepositoryBase<CurrencyInfoDM, CurrencyDM>,ICurrencyRepository
    {
        private  ICurrencyContext _context;

        public CurrencyRepository()
        {
            _context = new CurrencyContext ();
        }

        public CurrencyRepository(ICurrencyContext context)
        {
            _context = context;
        }

        
        //CRUD 

        public override List<CurrencyInfoDM> GetList()
        {
            var entity = (from currency in _context.Currency
                          select new CurrencyInfoDM
                          {
                              Id = currency.Id,
                              Code = currency.Code,
                              Name = currency.Name
                          });

            return entity.ToList();
        }

        public override List<CurrencyInfoDM> GetList(int key)
        {
            var entity = (from currency in _context.Currency
                          where currency.Id == key
                          select new CurrencyInfoDM
                          {
                              Id = currency.Id,
                              Code = currency.Code,
                              Name = currency.Name
                          });

            return entity.ToList();
        }

        public override CurrencyDM GetItem(int id)
        {
            var entity = (from currency in _context.Currency
                          where currency.Id == id
                          select new CurrencyDM
                          {
                              Id = currency.Id,
                              Code = currency.Code,
                              Name = currency.Name,
                              MarketCap = currency.MarketCap,
                              Description = currency.Description,
                              FiatList = (from fiat in _context.Fiat
                                          select new FiatDM
                                          {
                                              Id = fiat.Id,
                                              Name = fiat.Name,
                                              DisplayName = fiat.DisplayName,
                                              Code = fiat.Code,
                                              Description = fiat.Description,
                                              Symbol = fiat.Symbol,
                                              ImageId = fiat.ImageId,
                                              FlagId = fiat.FlagId
                                          }).ToList()
                          });

            return entity.SingleOrDefault();
        }

        public override int? Insert(CurrencyDM item)
        {
            var currency = Mapper.Map<CurrencyEntity>(item);
            _context.Currency.Add(currency);
            _context.SaveChanges();

            return item.Id;
        }

        public override void Delete(int id)
        {
            var dbCurrency = from currency in _context.Currency
                             where currency.Id == id
                             select currency;
            _context.Currency.Remove(dbCurrency.SingleOrDefault());
            _context.SaveChanges();
        }

        public override void Update(CurrencyDM item)
        {
            _context.SetModified(Mapper.Map<CurrencyEntity>(item));
            _context.SaveChanges();
        }
    }
}
