using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CPM.Business.Wallet;
using CPM.Web.Areas.Wallet.Models;
using CpmLib.Business.Core.Service;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Web.Areas.Wallet.Controllers
{
    [Area("Wallet")]
    [Authorize]
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
            var viewModel = new WalletListVM();
            var result = _service.GetList(1,"");
            //ModelMappings.Configure();

            if (result.Result == GetResultEnum.Success)
            {                
                var vmList = Mapper.Map<List<WalletInfoVM>>(result.List);
                viewModel.Wallets = vmList;
                return View(viewModel);                
            }
            else
            {
                return RedirectToAction("Error", "Home", new { Area = "Global" });
            }
        }
        
        public IActionResult Grid_Read([DataSourceRequest] DataSourceRequest request, string searchTerm = "")
        {
            GetListResult<WalletInfoBM> result;

            if (string.IsNullOrEmpty(searchTerm))
            {
                result = _service.GetList(1, searchTerm);
            }
            else
            {
                result = _service.GetList(2, searchTerm);
            }

            if(result.Result == GetResultEnum.Success)
            {             
                var viewModel = Mapper.Map<List<WalletInfoVM>>(result.List);
                return Json(viewModel.ToDataSourceResult(request));                 
            }
            else
            {
                return RedirectToAction("Error", "Home", new { Area = "Global" });
            }
        }

        public IActionResult Filter(int clientId, string searchTerm)
        {
            if (String.IsNullOrWhiteSpace(searchTerm))
            {
                return RedirectToAction("Index");
            }

            clientId = 2;
            var viewModel = new WalletListVM();

            var result = _service.GetListBySearchTerm(clientId, searchTerm);
            viewModel.SearchTerm = searchTerm;

            if (result.Result == GetResultEnum.Success)
            {
                //ModelMappings.Configure();
                viewModel.Wallets = Mapper.Map<List<WalletInfoVM>>(result.List);
                return View("Filter", viewModel);
            }
            else
            {
                return RedirectToAction("Error", "Home", new { Area = "Global" });
            }
        }

        public IActionResult Detail(int id)
        {           
            var result = _service.GetItem(id);
         

            if (result != null && result.Result == GetResultEnum.Success)
            {               
                //var vm = Mapper.Map<WalletVM>(result.Item);
                //viewModel = vm;
                return View("Detail", Mapper.Map<WalletVM>(result.Item));
            }
            else
            {
                return RedirectToAction("Error", "Home", new { Area = "Global" });
            }
        }
       
        public IActionResult Create(WalletVM walletVM)
        {
            var viewModel = new WalletVM();
            viewModel.Type = new WalletTypeVM(); 
            //viewModel.Type = _service.get //get list of wallet types
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = Mapper.Map<WalletVM>(_service.GetItem(id));
            viewModel.IsNew = false;
            return View(viewModel);
        }

    }
}
