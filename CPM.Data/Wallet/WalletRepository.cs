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
    public interface IWalletRepository :IRepositoryBase
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
            var entity = from wallet in _context.Wallets
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
                             IsDeleted = wallet.IsDeleted ?? false,
                             ImageId = wallet.ImageId
                         };

            return entity.ToList();
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
