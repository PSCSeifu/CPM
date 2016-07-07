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
        public async Task<IActionResult> Index()
        {
            var viewModel = new CurrencyListVM();
            viewModel.DefaultFiatCode = "usd"; /*  Get from session or profile settings. */

            var result = _service.GetList();

            if (result != null &&  result.Result == GetResultEnum.Success)
            {
                foreach (var currencyInfo in result.List)
                {
                    currencyInfo.PriceTickerInfo = await _priceService.GetPriceTickerInfoAsync(currencyInfo.Code, viewModel.DefaultFiatCode);                  
                    viewModel.Currencies.Add(Mapper.Map<CurrencyInfoVM>(currencyInfo));
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

        //public async Task<IActionResult> Detail(int id)
        //{
        //    var result = _service.GetItem(id);

        //    if (result != null && result.Result == GetResultEnum.Success)
        //    {
        //        //List<string> fiatList = new List<string>()
        //        //{
        //        //    "usd","gbp","eur","aud","rub","cny","jpy","chf"
                
        //        foreach (var item in result.Item.FiatList)
        //        {
        //            var priceticker = await   _priceService.GetPriceTickerAsync(result.Item.Code, item.Code, "usd", true);
        //            result.Item.Prices.Add(priceticker);
        //        }

        //        return View("Detail", Mapper.Map<CurrencyVM>(result.Item));
        //    }
        //    else
        //    {
        //        return RedirectToAction("Error", "Home", new { Area = "Global" });
        //    }
        //}

        public async Task<IActionResult> Detail(int id)
        {
            var result = _service.GetItem(id);

            if (result != null && result.Result == GetResultEnum.Success)
            {  
                foreach (var item in result.Item.FiatList)
                {
                    var priceticker = await _priceService.GetPriceTickerAsync(result.Item.Code, item.Code, "usd", true);
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
