using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPM.Business.Wallet;
using CPM.Web.Areas.Wallet.Models;
using AutoMapper;
using CpmLib.Business.Core.Service;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Web.Areas.Wallet.Controllers
{
    [Area("Wallet")]
    public class WalletController : Controller
    {
        private IWalletService _service;

        public WalletController(IWalletService service)
        {
            _service = service;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //Mapper.Initialize(config =>
            //{
            //    #region " Wallets "
            //    config.CreateMap<WalletBM, WalletInfoVM>();
            //    config.CreateMap<List<WalletBM>, List<WalletInfoVM>>();
            //    #endregion
            //});

            var viewModel = new WalletListVM();

            var result = _service.GetListById("abc");

            if (result.Result == GetResultEnum.Success)
            {
                //viewModel.Wallets = Mapper.Map<List<WalletInfoVM>>(result.List);
                //return View(viewModel);
                return View(result.List);
            }
            else
            {
                return RedirectToAction("Error", "Home", new { Area = "Global" });
            }          
        }
    }
}
