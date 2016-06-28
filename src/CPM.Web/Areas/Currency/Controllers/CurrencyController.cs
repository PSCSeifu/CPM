using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPM.Business.Currency;
using CPM.Web.Areas.Currency.Models;
using CpmLib.Business.Core.Service;
using Kendo.Mvc.UI;
using AutoMapper;
using Kendo.Mvc.Extensions;

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
            var result = _service.GetList();
            //ModelMappings.Configure();

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

        public IActionResult Grid_Read([DataSourceRequest] DataSourceRequest request)
        {
            GetListResult<CurrencyInfoBM> result;

            result = _service.GetList();

            if(result.Result == GetResultEnum.Success)
            {
                //ModelMappings.Configure(); 
                var viewmodel = Mapper.Map<List<CurrencyInfoVM>>(result.List);
                return Json(viewmodel.ToDataSourceResult(request));
            }
            else
            {
                return RedirectToAction("Error", "Home", new { Area = "Global" });
            }
        }

        public IActionResult Grid()
        {
            return View();
        }
    }
}
