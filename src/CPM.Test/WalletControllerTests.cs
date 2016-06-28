using CPM.Business.Wallet;
using CPM.Web.Areas.Wallet.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CPM.Test
{
    [TestFixture]
    public class WalletControllerTests
    {
        private WalletController _sut;

        [SetUp]
        public void Setup()
        {
            var fakewalletService = new Mock<IWalletService>();
            _sut = new WalletController(fakewalletService.Object);
        }

        [Test]
        public void ShouldRenderDefaultView()
        {
            var result = _sut.Index() as ViewResult;
            Assert.That(result.ViewName, Is.EqualTo("Index"));
            //_sut.WithCallTo(x => x.Index()).ShouldRenderDefaultView();
        }
    }
}
