using CPM.Business.Wallet;
using CPM.Data.Wallet;
using CpmLib.Business.Core.Service;
using Moq;
using System;
using Xunit;

namespace CPM.Test.Wallet
{
    //[TestFixture]
    public class WalletServiceTests
    {
        public GetResultEnum _getResultEnum ;      
        public Mock<IWalletValidator> fakeValidator { get; private set; }
        public WalletService sut { get; private set; }
        public WalletRepository fakeRepository { get; private set; }
        public WalletMockContext fakeContext { get; private set; }

        private void Setup()
        {
             fakeContext = new WalletMockContext();
            fakeContext.Wallets.Add(new Data.Entities.WalletEntity()
            { Balance = 523.5m, ClientId = 1, Currency = "ETH", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow, WithdrawLimit = 200.0m, Id = 1, ImageId = 1, IsLocked = false, LockOnNotificationLimit = false, LockOnSpendLimit = false, LockOnWithdrawLimit = false, Name = "MyPurse", NotificationLimit = 0.0m, SpendLimit = 0.0m, IsDeleted = false, DeleteDate = null, WalletTypeId = 1 });
            fakeContext.Wallets.Add(new Data.Entities.WalletEntity()
            { Balance = 4.5m, ClientId = 2, Currency = "BTC", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow, WithdrawLimit = 1.25m, Id = 1, ImageId = 1, IsLocked = false, LockOnNotificationLimit = false, LockOnSpendLimit = false, LockOnWithdrawLimit = false, Name = "MyPurse", NotificationLimit = 2.0m, SpendLimit = 1.5m, IsDeleted = null, DeleteDate = null, WalletTypeId = 1 });


            fakeRepository = new WalletRepository(fakeContext);
            fakeValidator = new Mock<IWalletValidator>();

            sut = new WalletService(fakeRepository, fakeValidator.Object);
        }

        [Fact]
        public void Creation()
        {
           
            // fakeContext.Wallets.Add(new Data.Entities.WalletEntity()
            //{ Balance = 523.5m, ClientId = 1, Currency = "ETH", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow, WithdrawLimit = 200.0m, Id = 1, ImageId = 1, IsLocked = false, LockOnNotificationLimit = false, LockOnSpendLimit = false, LockOnWithdrawLimit = false, Name = "MyPurse", NotificationLimit = 0.0m, SpendLimit = 0.0m, IsDeleted = false, DeleteDate = null, WalletTypeId = 1 });
            Setup();
            // var service = new WalletService(fakeRepository, fakeValidator.Object);

            Assert.NotNull(fakeContext);
        }

        //[Fact]
        public void GetItem_Wallet_Returns_GetItemResult_Type()
        {
            //Arrange 
            Setup();

            //Act 
            var result = sut.GetItem(1);
                        
            //result.GetType().Equals(typeof(GetItemResult<WalletBM>));
            Assert.Equal (typeof(GetItemResult<WalletBM>),result.GetType());
        }

       //[Fact]
        public void GetItem_Returns_Correct_Wallet_Id()
        {
            //Arrange 
            Setup();
            GetItemResult<WalletBM> result;

            //Act 
            result = sut.GetItem(0);

            Assert.Equal(GetResultEnum.Error, result.Result);
            //result.Result.Equals(GetResultEnum.Error);
        }
    }
}
