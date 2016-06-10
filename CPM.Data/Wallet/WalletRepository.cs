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
        WalletDM GetWalletByClientIdAndWalletId(string clientId, int walletId);
        List<WalletDM> GetWalletsByClientId(string clientId);
        object GetWalletsBySearchTerm(string clientId, string searchTerm);
        void EnsureSeedWalletData(string filePath);
    }

    public class WalletRepository: RepositoryBase , IWalletRepository
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

        public List<WalletDM> GetWalletsByClientId(string clientId)
        {
            List<WalletDM> wallets = MockPopulateWalletRepository();

            return wallets.Where(w => w.ClientId == clientId).ToList();
        }

        public object GetWalletsBySearchTerm(string clientId, string searchTerm)
        {
            List<WalletDM> wallets = MockPopulateWalletRepository();

            return wallets.Where(w => w.ClientId == clientId 
                            && w.Name.ToLower().Contains(searchTerm.ToLower()) )                            
                            .ToList();
        }

        public WalletDM GetWalletByClientIdAndWalletId(string clientId, int walletId)
        {
            List<WalletDM> wallets = MockPopulateWalletRepository();

            return wallets.Where(w => w.ClientId == clientId && w.Id == walletId).SingleOrDefault(); 
        }

        private List<WalletDM> MockPopulateWalletRepository()
        {
            //Mock
            List<WalletDM> walletList = new List<WalletDM>();
            walletList.Add(new WalletDM { Id = 1, ClientId = "ab", Name = "MyPurse", Balance = 523.5m, IsLocked = false });
            walletList.Add(new WalletDM { Id = 2, ClientId = "ab", Name = "MyPocket", Balance = 1023, IsLocked = false });
            walletList.Add(new WalletDM { Id = 3, ClientId = "abc", Name = "MyFancyWallet", Balance = 2.5m, IsLocked = true });
            walletList.Add(new WalletDM { Id = 4, ClientId = "abc", Name = "MyOtherPocket", Balance = 142.5m, IsLocked = false });
            walletList.Add(new WalletDM { Id = 5, ClientId = "abc", Name = "MyMattress", Balance = 852m, IsLocked = false });
            walletList.Add(new WalletDM { Id = 6, ClientId = "abc", Name = "MyStash", Balance = 142.5m, IsLocked = false });

            return walletList;
        }

        public  void EnsureSeedWalletData(string filePath)
        {
            if (!_context.Wallets.Any())
            {
                //Read seed json file
                JArray jarray = JArray.Parse(File.ReadAllText(filePath)) as JArray;
                dynamic jsonData = jarray;
                foreach (dynamic d in jsonData)
                {
                    _context.Wallets.Add(new WalletEntity()
                    {
                        ClientId = d.ClientId,
                        Name = d.Name,
                        Balance = d.Balance,
                        IsLocked = d.IsLocked,
                        Currency = d.Currency,
                        DateCreated = d.DateCreated,
                        DateModified = d.DateModified
                    });
                }
                _context.SaveChanges();
            }

        }

       
    }
}
