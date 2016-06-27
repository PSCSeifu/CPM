using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPM.Business.Offer;
using CPM.Web.Areas.Offer.Models;
using CpmLib.Business.Core.Service;
using AutoMapper;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Web.Areas.Offer.Controllers
{
    [Area("Offer")]
    public class OfferController : Controller
    {
        private  IOfferService _service;

        public OfferController(IOfferService service)
        {
            _service = service;
        }
        // GET: /<controller>/
        public  IActionResult Index()
        {
            var viewModel = new OfferListVM();
            var result = _service.GetList(2);

            if (result.Result == GetResultEnum.Success)
            {
                ModelMappings.Configure();
                viewModel.Offers = Mapper.Map<List<OfferInfoVM>>(result.List);
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Error", "Home", new { Area = "Global" });
            }
            
        }

        public IActionResult Filter()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
