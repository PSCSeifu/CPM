using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPM.Business.Wallet;
using CPM.Web.Areas.Wallet.Models;
using CpmLib.Business.Core.Service;
using AutoMapper;

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
            var viewModel = new WalletListVM();
            var result = _service.GetListById(2);

            if (result.Result == GetResultEnum.Success)
            {
                ModelMappings.Configure();
                viewModel.Wallets = Mapper.Map<List<WalletInfoVM>>(result.List);
                return View(viewModel);
                //return View(result.List);
            }
            else
            {
                return RedirectToAction("Error", "Home", new { Area = "Global" });
            }
        }




        public IActionResult Detail(int id)
        {
            var viewModel = new WalletInfoVM();
            var result = _service.GetWalletById(id);
            
            if(result.Result == GetResultEnum.Success)
            {
                ModelMappings.Configure();
                return View("Detail",Mapper.Map<WalletInfoVM>(result.Item) );
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

            if(result.Result == GetResultEnum.Success)
            {
                ModelMappings.Configure();
                viewModel.Wallets = Mapper.Map<List<WalletInfoVM>>(result.List);
                return View("Filter",viewModel);
            }
            else
            {
                return RedirectToAction("Error", "Home", new { Area = "Global" });
            }
        }
                
    }
}
