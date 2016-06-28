﻿using CPM.Business.Wallet;
using CPM.Web.Areas.Wallet.Controllers;
using CpmLib.Business.Core.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CPM.Test
{
    [TestFixture]
    public class WalletControllerTests
    {
        //    private CPM.Web.Areas.Wallet.Controllers.WalletController _sut;

        //    [SetUp]
        //    public void Setup()
        //    {
        //        var fakewalletService = new Mock<IWalletService>();
        //        _sut = new CPM.Web.Areas.Wallet.Controllers.WalletController(fakewalletService.Object);
        //    }

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

        [Test]
        public void ShouldRenderEditView()
        {
            var fakewalletService = new Mock<IWalletService>();
            var sut = new WalletController(fakewalletService.Object);

            var result = sut.Edit(0) as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Edit"));
        }
    }
}
