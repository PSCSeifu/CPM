using CPM.Data.Wallet;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPM.Test.Fakes
{
    public class FakeWalletDbContext : Mock<IWalletContext>
    {
       
    }
}
