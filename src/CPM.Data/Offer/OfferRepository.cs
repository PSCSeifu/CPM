using AutoMapper;
using CPM.Data.Entities;
using CpmLib.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Offer
{
    public interface IOfferRepository : ICrudRepositoryBase<OfferInfoDM, OfferDM>
    {
        OfferDM GetOfferById(int id);
        List<OfferInfoDM> GetOffersByClientId(int clientId);
        List<OfferInfoDM> GetListBySearch(int key, string searchTerm);
    }

    public class OfferRepository : CrudRepositoryBase<OfferInfoDM, OfferDM>, IOfferRepository
    {
        private readonly OfferContext _context;

        public OfferRepository()
        {
            _context = new OfferContext();
        }

        public OfferRepository(OfferContext context)
        {
            _context = context;
        }

        public List<OfferInfoDM> GetListBySearch(int clientId, string searchTerm)
        {
            var entity = from offer in _context.Offers
                             //join client in _context.Clients on offer.ClientId equals client.Id
                             //join wallet in _context.Wallets on offer.WalletId equals wallet.Id
                             //join currency in _context.Currencies on offer.DefaultCurrencyId equals currency.Id
                             //where offer.ClientId == clientId && offer.Name.ToLower().Contains(searchTerm.ToLower())
                         orderby offer.DateCreated
                         select new OfferInfoDM
                         {
                             Id = offer.Id,
                             //ClientName = client.NickName,
                             //CurrencyCode = currency.Code,
                             DateCreated = offer.DateCreated,
                             ExpiryDate = offer.ExpiryDate,
                             Name = offer.Name,
                         };

            return entity.ToList();
        }

        public List<OfferInfoDM> GetOffersByClientId(int clientId)
        {
            //var entity = from offer in _context.Offers
            //                 //join client in _context.Clients on offer.ClientId equals client.Id
            //                 //join wallet in _context.Wallets on offer.WalletId equals wallet.Id
            //                 //join currency in _context.Currencies on offer.DefaultCurrencyId equals currency.Id
            //                 //where client.Id == clientId
            //             orderby offer.DateCreated
            //             select new OfferInfoDM
            //             {
            //                 Id = offer.Id,
            //                 //ClientName = client.NickName,
            //                 //CurrencyCode = currency.Code,
            //                 DateCreated = offer.DateCreated,
            //                 ExpiryDate = offer.ExpiryDate,
            //                 Name = offer.Name,
            //             };
            var entity = Mapper.Map<List<OfferInfoDM>>(MockPopulateOfferRepository());

            return entity.ToList();
        }

        public OfferDM GetOfferById(int id)
        {
            var entity = (from o in _context.Offers
                          where o.Id == id
                          select o).SingleOrDefault();

            return Mapper.Map<OfferDM>(entity);
        }

        private List<OfferDM> MockPopulateOfferRepository()
        {
            List<OfferDM> offers = new List<OfferDM>();
            offers.Add(new OfferDM { Id = 1, ClientId = 1, Name = "Half_Price_Extras", WalletId = 2, DateCreated = DateTime.UtcNow, DefaultCurrencyId = 1, ExpiryDate = new DateTime(2017, 01, 01), Detail = "Very short time Limited offer on stuff, Great stuff, huuge stuff,I tell you...great stuff!" });
            offers.Add(new OfferDM { Id = 2, ClientId = 1, Name = "Summer Crypto Discount", WalletId = 2, DateCreated = DateTime.UtcNow, DefaultCurrencyId = 1, ExpiryDate = new DateTime(2016, 08, 13), Detail = "Great summmer deals on the big names in crypto." });
            offers.Add(new OfferDM { Id = 3, ClientId = 2, Name = "Home Decor Discount", WalletId = 4, DateCreated = DateTime.UtcNow, DefaultCurrencyId = 1, ExpiryDate = new DateTime(2016, 11, 25), Detail = "Up to one third off on DIY tools!" });
            return offers;
        }

        // CRUD

        public override List<OfferInfoDM> GetList(int key)
        {
            var entity = from offer in _context.Offers
                             //join client in _context.Clients on offer.ClientId equals client.Id
                             //join wallet in _context.Wallets on offer.WalletId equals wallet.Id
                             //join currency in _context.Currencies on offer.DefaultCurrencyId equals currency.Id
                         where offer.ClientId == key
                         orderby offer.DateCreated
                         select new OfferInfoDM
                         {
                             Id = offer.Id,
                             //ClientName = client.NickName,                            
                             //CurrencyCode = currency.Code,
                             DateCreated = offer.DateCreated,
                             ExpiryDate = offer.ExpiryDate,
                             Name = offer.Name,
                         };

            return entity.ToList();
        }

        public override List<OfferInfoDM> GetList()
        {
            var entity = from offer in _context.Offers
                             //join client in _context.Clients on offer.ClientId equals client.Id
                             //join wallet in _context.Wallets on offer.WalletId equals wallet.Id
                             //join currency in _context.Currencies on offer.DefaultCurrencyId equals currency.Id                         
                         orderby offer.DateCreated descending
                         select new OfferInfoDM
                         {
                             Id = offer.Id,
                             //ClientName = client.NickName,                            
                             //CurrencyCode = currency.Code,
                             DateCreated = offer.DateCreated,
                             ExpiryDate = offer.ExpiryDate,
                             Name = offer.Name,
                         };

            return entity.ToList();
        }

        public override OfferDM GetItem(int id)
        {

            var entity = from offer in _context.Offers
                         where offer.Id == id
                         select new OfferDM
                         {
                             Id = offer.Id,
                             ClientId = offer.ClientId,
                             ClientName = offer.Name,
                             CurrencyCode = (from currency in _context.Currencies
                                             where currency.Id == offer.DefaultCurrencyId
                                             select currency.Code).SingleOrDefault(),
                             DateCreated = offer.DateCreated,
                             Detail = offer.Detail,
                             ExpiryDate = offer.ExpiryDate,
                             Name = offer.Name,
                             WalletName = (from wallet in _context.Wallets
                                           where wallet.Id == offer.WalletId
                                           select wallet.Name
                                          ).SingleOrDefault(),
                             WebUserType = (from client in _context.Clients
                                            where client.Id == offer.ClientId
                                            select client.WebUserType.Value
                                            ).SingleOrDefault()
                         };

            return entity.SingleOrDefault();
        }

        public override int? Insert(OfferDM item)
        {
            var offer = Mapper.Map<OfferEntity>(item);
            _context.Offers.Add(offer);
            _context.SaveChanges();

            return item.Id;
        }
        
        public override void Update(OfferDM item)
        {
            _context.SetModified(Mapper.Map<OfferEntity>(item));
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var dbOffer = from offer in _context.Offers
                          where offer.Id == id
                          select offer;

            _context.Offers.Remove(dbOffer.SingleOrDefault());
            _context.SaveChanges();
        }
    }
}
