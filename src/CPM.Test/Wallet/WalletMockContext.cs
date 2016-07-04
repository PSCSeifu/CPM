using CPM.Data.Entities;
using CPM.Data.Wallet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using CPM.Test.Fakes;
using Moq;

namespace CPM.Test.Wallet
{
    public class WalletMockContext :IWalletContext
    {
        public DbSet<WalletEntity> Wallets { get; set; }
        public DbSet<WalletTypeEntity> WalletTypes { get; set; }

        public DbSet<OfferEntity> Offers { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<CurrencyEntity> Currency { get; set; }
        public DbSet<CPMUserEntity> CPMUser { get; set; }

        public WalletMockContext()
        {
            Wallets = new FakeDbSet<WalletEntity>();
        }

        public int setModifiedCalled = 0;

        public DatabaseFacade Database
        {
            get
            {
                throw new NotImplementedException();
            }
        }

       
        public int SaveChanges()
        {
            return 0;
        }

        public void SetModified(object entity)
        {
           setModifiedCalled++;
        }
    }
}
