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
    public interface IOfferRepository : IRepositoryBase
    {
        OfferDM GetOfferById(int id);
        List<OfferInfoDM> GetOffersByClientId(int clientId);
        List<OfferInfoDM> GetListBySearch(int key, string searchTerm);        
    }

    public class OfferRepository : CrudRepositoryBase<OfferInfoDM,OfferDM>, IOfferRepository
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

        public override List<OfferInfoDM> GetList(int key)
        {
            var entity = from offer in _context.Offers
                         join client in _context.Clients on offer.ClientId equals client.Id
                         join wallet in _context.Wallets on offer.WalletId equals wallet.Id
                         join currency in _context.Currencies on offer.DefaultCurrencyId equals currency.Id
                         where offer.Id == key
                         orderby offer.DateCreated
                         select new OfferInfoDM
                         {
                             Id = offer.Id,                         
                             ClientName = client.NickName,                            
                             CurrencyCode = currency.Code,
                             DateCreated = offer.DateCreated,
                             ExpiryDate= offer.ExpiryDate,
                             Name = offer.Name,                            
                         };

            return entity.ToList();
        }

        public  List<OfferInfoDM> GetListBySearch(int key,string searchTerm)
        {
            var entity = from offer in _context.Offers
                         join client in _context.Clients on offer.ClientId equals client.Id
                         join wallet in _context.Wallets on offer.WalletId equals wallet.Id
                         join currency in _context.Currencies on offer.DefaultCurrencyId equals currency.Id
                         where offer.Id == key && offer.Name.ToLower().Contains(searchTerm.ToLower())
                         orderby offer.DateCreated
                         select new OfferInfoDM
                         {
                             Id = offer.Id,                            
                             ClientName = client.NickName,
                             CurrencyCode = currency.Code,
                             DateCreated = offer.DateCreated,
                             ExpiryDate = offer.ExpiryDate,
                             Name = offer.Name,                          
                         };

            return entity.ToList();
        }



        public List<OfferInfoDM> GetOffersByClientId(int clientId)
        {
            var entity = from offer in _context.Offers
                         join client in _context.Clients on offer.ClientId equals client.Id
                         join wallet in _context.Wallets on offer.WalletId equals wallet.Id
                         join currency in _context.Currencies on offer.DefaultCurrencyId equals currency.Id
                         where client.Id == clientId
                         orderby offer.DateCreated
                         select new OfferInfoDM
                         {
                             Id = offer.Id,                             
                             ClientName = client.NickName,                             
                             CurrencyCode = currency.Code,
                             DateCreated = offer.DateCreated,
                             ExpiryDate = offer.ExpiryDate,
                             Name = offer.Name,
                         };

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
            offers.Add(new OfferDM { Id = 1, ClientId = 1, Name = "Half_Price_Extras",WalletId = 2, DateCreated = DateTime.UtcNow, DefaultCurrencyId = 1, ExpiryDate = new DateTime(2017, 01, 01), Detail = "Very short time Limited offer on stuff, Great stuff, huuge stuff,I tell you...great stuff!" });
            offers.Add(new OfferDM { Id = 2, ClientId = 1, Name = "Summer Crypto Discount", WalletId = 2, DateCreated = DateTime.UtcNow, DefaultCurrencyId = 1, ExpiryDate = new DateTime(2016, 08, 13), Detail = "Great summmer deals on the big names in crypto." });
            offers.Add(new OfferDM { Id = 3, ClientId = 2, Name = "Home Decor Discount", WalletId = 4, DateCreated = DateTime.UtcNow, DefaultCurrencyId = 1, ExpiryDate = new DateTime(2016, 11, 25), Detail = "Up to one third off on DIY tools!" });
            return offers;
        }



    }
}
