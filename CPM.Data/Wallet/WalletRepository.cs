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

        public List<WalletDM> GetWalletByClientIdAndWalletId(string clientId, int walletId)
        {
            //Mock
            List<WalletDM> walletList = new List<WalletDM>();
            walletList.Add(new WalletDM{    Id = 1 ,ClientId = "ab", Name ="MyPurse",Balance = 523.5m, IsLocked=false});
            walletList.Add(new WalletDM { Id = 2, ClientId = "abc", Name = "MyPocket", Balance = 1023, IsLocked = false });
            walletList.Add(new WalletDM { Id = 3, ClientId = "abcd",Name = "MyFancyWallet", Balance = 2.5m, IsLocked = true });
            walletList.Add(new WalletDM { Id = 4, ClientId = "abcde", Name = "MyOtherPocket", Balance = 142.5m, IsLocked = false });

            return walletList;
        }
    }
}
