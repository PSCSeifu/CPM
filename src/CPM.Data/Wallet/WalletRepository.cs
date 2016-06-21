using AutoMapper;
using CPM.Data.Entities;
using CpmLib.Data.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Wallet
{
    public interface IWalletRepository : ICrudRepositoryBase<WalletInfoDM, WalletDM>
    {
        WalletDM GetWalletByClientIdAndWalletId(int clientId, int walletId);
        List<WalletDM> GetWalletsByClientId(int clientId);
        List<WalletDM> GetWalletsBySearchTerm(int clientId, string searchTerm);
        WalletDM GetWalletByWalletId(int walletId);
       // void EnsureSeedWalletData(string filePath);
    }

    public class WalletRepository: CrudRepositoryBase<WalletInfoDM,WalletDM> , IWalletRepository
    {
        private readonly IWalletContext _context;

        public WalletRepository()
        {
            _context = new WalletContext();
        }

        public WalletRepository(IWalletContext context)
        {
            _context = context;
        }

        public override List<WalletInfoDM> GetList(int key)
        {
            var entity = (from wallet in _context.Wallets
                          where wallet.ClientId == key
                          orderby wallet.DateModified descending
                          select new WalletInfoDM
                          {
                              Id = wallet.Id,
                              Balance = wallet.Balance,
                              Currency = wallet.Currency,
                              DateModified = wallet.DateModified,
                              Name = wallet.Name,
                              IsLocked = wallet.IsLocked,
                              IsDeleted = wallet.IsDeleted,
                              ImageId = wallet.ImageId
                          }).ToList();

            return Mapper.Map<List<WalletInfoDM>>(entity);
        }

        public List<WalletDM> GetWalletsByClientId(int clientId)
        {
            List<WalletDM> wallets = MockPopulateWalletRepository();

            return wallets.Where(w => w.ClientId == clientId).ToList();
        }

        public List<WalletDM> GetWalletsBySearchTerm(int clientId, string searchTerm)
        {
            List<WalletDM> wallets = MockPopulateWalletRepository();

            return wallets.Where(w => w.ClientId == clientId 
                            && w.Name.ToLower().Contains(searchTerm.ToLower()) )                            
                            .ToList();
        }

        public WalletDM GetWalletByClientIdAndWalletId(int clientId, int walletId)
        {
            List<WalletDM> wallets = MockPopulateWalletRepository();

            return wallets.Where(w => w.ClientId == clientId && w.Id == walletId).SingleOrDefault(); 
        }

        public WalletDM GetWalletByWalletId(int walletId)
        {
            List<WalletDM> wallets = MockPopulateWalletRepository();

            return wallets.Where(w => w.Id == walletId).SingleOrDefault();
        }

        //CRUD
        public override WalletDM GetItem(int id)
        {
            var entity = from wallet in _context.Wallets
                         where wallet.Id == id
                         select new WalletDM
                         {
                             Id = wallet.Id,
                             Balance = wallet.Balance,
                             ClientId = wallet.ClientId,
                             Currency = wallet.Currency,
                             DateCreated = wallet.DateCreated,
                             DateModified = wallet.DateModified,
                             DeleteDate = wallet.DeleteDate,
                             ImageId = wallet.ImageId,
                             IsDeleted = wallet.IsDeleted,
                             IsLocked = wallet.IsLocked,
                             LockOnNotificationLimit = wallet.LockOnNotificationLimit,
                             LockOnSpendLimit = wallet.LockOnSpendLimit,
                             LockOnWithdrawLimit = wallet.LockOnWithdrawLimit,
                             Name = wallet.Name,
                             NotificationLimit = wallet.NotificationLimit,
                             SpendLimit = wallet.SpendLimit,
                             WithdrawLimit = wallet.WithdrawLimit,

                             Type = (from walletType in _context.WalletTypes
                                     where walletType.Id == wallet.WalletTypeId
                                     select new WalletTypeDM
                                     {
                                         Id = walletType.Id,
                                         Category = walletType.Category,
                                         Description = walletType.Description,
                                         Name = walletType.Name
                                     }).SingleOrDefault()
                         };

            return entity.SingleOrDefault();
        }

        public override int? Insert(WalletDM item)
        {
            var wallet = Mapper.Map<WalletEntity>(item);
            _context.Wallets.Add(wallet);
            _context.SaveChanges();

            return item.Id;
        }

        public override void Update(WalletDM item)
        {
            _context.SetModified(Mapper.Map<WalletEntity>(item));
            _context.SaveChanges();            
        }

        public override void Delete(int id)
        {
            var dbwallet = from wallet in _context.Wallets
                           where wallet.Id == id
                           select wallet;
            _context.Wallets.Remove(dbwallet.SingleOrDefault());
            _context.SaveChanges();
        }
        
        //MOCK  DATA    
        private List<WalletDM> MockPopulateWalletRepository()
        {
            //Mock
            List<WalletDM> walletList = new List<WalletDM>();
            walletList.Add(new WalletDM { Id = 1, ClientId = 1, Name = "MyPurse", Balance = 523.5m, IsLocked = false });
            walletList.Add(new WalletDM { Id = 2, ClientId = 1, Name = "MyPocket", Balance = 1023, IsLocked = false });
            walletList.Add(new WalletDM { Id = 3, ClientId = 2, Name = "MyFancyWallet", Balance = 2.5m, IsLocked = true });
            walletList.Add(new WalletDM { Id = 4, ClientId = 2, Name = "MyOtherPocket", Balance = 142.5m, IsLocked = false });
            walletList.Add(new WalletDM { Id = 5, ClientId = 2, Name = "MyMattress", Balance = 852m, IsLocked = false });
            walletList.Add(new WalletDM { Id = 6, ClientId = 2, Name = "MyStash", Balance = 142.5m, IsLocked = false });

            return walletList;
        }        
    }
}
