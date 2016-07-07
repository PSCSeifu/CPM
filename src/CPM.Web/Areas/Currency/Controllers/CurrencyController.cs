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
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Web.Areas.Currency.Controllers
{
    [Area("Currency")]
    
    public class CurrencyController : Controller
    {
        private ICurrencySerivce _service;
        private IPriceTickerService _priceService;

        public CurrencyController(ICurrencySerivce service, IPriceTickerService priceService)
        {
            _service = service;
            _priceService = priceService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var viewModel = new CurrencyListVM();
            string defaultFiatCode = "usd"; // Get from session or profile settings.

            var result = _service.GetList();

            if (result != null &&  result.Result == GetResultEnum.Success)
            {
                foreach (var currencyInfo in result.List)
                {
                    var priceTickerInfo = _priceService.GetPriceTickerInfoSync(currencyInfo.Code, "", defaultFiatCode);                                     

                    currencyInfo.PriceTicker= priceTickerInfo;
                    var vm = Mapper.Map<CurrencyInfoVM>(currencyInfo);
                    vm.PriceTickerInfo = Mapper.Map<PriceTickerInfoVM>(priceTickerInfo);

                    viewModel.Currencies.Add(vm);
                }
                
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
                var viewmodel = Mapper.Map<List<CurrencyInfoVM>>(result.List);
                return Json(viewmodel.ToDataSourceResult(request));
            }
            else
            {
                return RedirectToAction("Error", "Home", new { Area = "Global" });
            }
        }

        public  IActionResult Detail(int id)
        {
            var result = _service.GetItem(id);

            if (result != null && result.Result == GetResultEnum.Success)
            {
                List<string> fiatList = new List<string>()
                {
                    "usd","gbp","eur","aud","rub","cny","jpy","chf"
                };
                foreach (var item in fiatList)
                {
                    var priceticker = _priceService.GetPriceTickerSync(result.Item.Code, item, "usd", true);
                    result.Item.Prices.Add(priceticker);
                }
                
                return View("Detail", Mapper.Map<CurrencyVM>(result.Item));
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
