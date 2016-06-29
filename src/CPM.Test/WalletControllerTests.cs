using CPM.Business.Wallet;
using CPM.Web.Areas.Wallet.Controllers;
using CPM.Web.Areas.Wallet.Models;
using CpmLib.Business.Core.Service;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
//using NUnit.Framework;

namespace CPM.Test
{
   // [TestFixture]
    public class WalletControllerTests
    {
        private CPM.Web.Areas.Wallet.Controllers.WalletController _sut;
        
        //[SetUp]
        public void Setup()
        {
            var fakewalletService = new Mock<IWalletService>();
            _sut = new CPM.Web.Areas.Wallet.Controllers.WalletController(fakewalletService.Object);
        }

        //    [Test]
        //    public void ShouldRenderDefaultView()
        //    {
        //        var result = _sut.Index() as ViewResult;
        //        Assert.That(result.ViewName, Is.EqualTo("Index"));
        //        //_sut.WithCallTo(x => x.Index()).ShouldRenderDefaultView();
        //    }

        //    [Test]
        //    public void ShouldRdirectToIndexViewOnSuccess()
        //    {


        //    }


        //    [Test]
        //public void ShouldRenderDefaultView()
        //{
        //    var fakewalletService = new Mock<IWalletService>();
        //    var sut = new WalletController(fakewalletService.Object);

        //    var result = sut.Index() as ViewResult;

        //    Assert.That(result, Is.EqualTo("Index"));
        //    //sut.WithCallTo(x => x.Index()).ShouldRenderDefaultView();
        //}
        //[Test]
        //public void SHouldRenderGridView()
        //{
        //    var fakewalletService = new Mock<IWalletService>();
        //    var sut = new WalletController(fakewalletService.Object);

        //    var result = sut.Grid() as ViewResult;

        //    Assert.That(result.ViewName, Is.EqualTo(null));
        //}

       // [Test]
        public void ShouldRenderEditView()
        {
            var fakewalletService = new Mock<IWalletService>();
           
            var sut = new WalletController(fakewalletService.Object);

            var result = sut.Edit(0) as ViewResult;

            //result.Model.Equals
            //Assert.That(result.ViewName, Is.EqualTo("Edit"));
        }

       // [Test]
        public void Detail_DetailView_ShouldRenderDetailViewOnValidId()
        {
            //Arrange
            var fakewalletService = new Mock<IWalletService>();
            var fakeWalletVM = new Mock<WalletVM>();

            var sut = new WalletController(fakewalletService.Object);

            //Act
            var result = sut.Detail(1)as ViewResult;

          
            // Assert.That(result.ViewName, Is.EqualTo("Detail"));
            //Assert.That(result.ViewName, Is.EqualTo("Detail"));
            //result.ViewName.Should().BeEquivalentTo("Detail");
        }

        //[Test]
        public void Create_DefaultWalletVM_ShouldReturnWalletVMType()
        {
            var fakewalletService = new Mock<IWalletService>();
            var fakeWalletVM = new Mock<WalletVM>();           

            var sut = new WalletController(fakewalletService.Object);

            var result = sut.Create(fakeWalletVM.Object) as ViewResult;

            //result.Model.Should().BeOfType<WalletVM>();
            //Assert.That(result.Model.GetType, Is.EqualTo(typeof(WalletVM)));
        }
    }
}
