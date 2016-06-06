using CpmLib.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Wallet
{
    public interface IWalletRepository :IRepositoryBase
    {
        List<WalletDM> GetWalletByClientIdAndWalletId(string clientId, int walletId);
        List<WalletDM> GetWalletsByClientId(string clientId);
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

        public List<WalletDM> GetWalletByClientIdAndWalletId(string clientId, int walletId)
        {
            List<WalletDM> wallets = MockPopulateWalletRepository();

            return wallets.Where(w => w.ClientId == clientId && w.Id == walletId).ToList(); 
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
    }
}
