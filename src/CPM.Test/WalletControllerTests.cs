using CPM.Business;
using CPM.Business.Wallet;
using CPM.Data;
using CPM.Web;
using CPM.Web.Areas.Wallet.Controllers;
using CPM.Web.Areas.Wallet.Models;
using CpmLib.Business.Core.Service;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
//using NUnit.Framework;

namespace CPM.Test
{
   
    public class WalletControllerTests
    {        
        private  Mock<IWalletService> _service;

        public WalletControllerTests()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.AddProfile<BusinessModelMappings>();
                config.AddProfile<DataModelMappings>();
                config.AddProfile<WebModelMappings>();

            });

            _service = new Mock<IWalletService>();
        }        
      
        public GetItemResult<WalletBM> SetupFakeService( bool success)
        {            
            GetItemResult<WalletBM> bm = new GetItemResult<WalletBM>();
            if (success)
            {
                bm.Result = GetResultEnum.Success;
                bm.Item = new WalletBM();
            }
            else
            {
                bm.Result = GetResultEnum.Error;
                bm.Error = new System.Exception();
            }

            return bm;
        }


        #region "  Detail "
        
        [Fact]
        [Trait("Category", "Controller")]
        public void Detail_ShouldReturnCorrectType_OnValidId()
        {
            //Arrange
            var bm = SetupFakeService(true);            
            _service.Setup(w => w.GetItem(1)).Returns(bm);

            //Act
            var sut = new WalletController(_service.Object);
            var result = sut.Detail(1) as ViewResult;

            //Assert
            Assert.IsType<WalletVM>(result.Model);
        }


        [Fact]
        [Trait("Category", "Controller")]
        public void Detail_ShouldRedirectToError_OnInvalidId()
        {
            //Arrange
            var bm = SetupFakeService(false);
            _service.Setup(w => w.GetItem(1)).Returns(bm);

            //Act
            var sut = new WalletController(_service.Object);
            var result = sut.Detail(0) as RedirectToActionResult;

            //Assert
            Assert.Equal(result.ActionName, "Error");
        }

        [Fact]
        [Trait("Category", "Controller")]
        public void Detail_ShouldrenderDetailView_OnCorrectId()
        {
            //Arrange
            var bm = SetupFakeService(true);
            _service.Setup(w => w.GetItem(1)).Returns(bm);

            //Act
            var sut = new WalletController(_service.Object);
            var result = sut.Detail(1) as ViewResult;

            //Assert
            Assert.Equal(result.ViewName, "Detail");
        }

        [Fact]
        [Trait("Category", "Controller")]
        public void Detail_ShouldCreateWalletVM_OnCorrectId()
        {
            //Arrange
            var bm = SetupFakeService(true);
            _service.Setup(w => w.GetItem(1)).Returns(bm);

            //Act
            var sut = new WalletController(_service.Object);
            var result = sut.Detail(1) as ViewResult;

            //Assert
            Assert.IsType<WalletVM>(result.Model);
        }

        #endregion
    }
}
