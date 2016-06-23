using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPM.Business.Currency;
using CPM.Web.Areas.Currency.Models;
using CpmLib.Business.Core.Service;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Web.Areas.Currency.Controllers
{
    [Area("Currency")]
    public class CurrencyController : Controller
    {
        private ICurrencySerivce _service;

        public CurrencyController(ICurrencySerivce service )
        {
            _service = service;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var viewModel = new CurrencyListVM();
            var result = _service.GetList(1,"");
            ModelMappings.Configure();

            if (result.Result == GetResultEnum.Success)
            {
                var vmList = AutoMapper.Mapper.Map<List<CurrencyInfoVM>>(result.List);
                viewModel.Currencies = vmList;
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Error", "Home", new { Area = "Global" });
            }
            

        }
    }
}
