using CPM.Data.Wallet;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Test.Fakes
{
    public class FakeRepository
    {
        private Mock<IWalletContext> _context;

        public FakeRepository()
        {
            _context = new FakeWalletDbContext();
        }
    }
}
