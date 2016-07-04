using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPM.Business.Offer;
using CPM.Web.Areas.Offer.Models;
using CpmLib.Business.Core.Service;
using AutoMapper;
using Kendo.Mvc.UI;
using CPM.Web.Common.Session;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Web.Areas.Offer.Controllers
{
    [Area("Offer")]
    [Authorize]
    public class OfferController : Controller
    {
        private  IOfferService _service;
        private ISessionHelper _sessionHelper;

        public OfferController(IOfferService service,ISessionHelper sessionHelper)
        {
            _service = service;
            _sessionHelper = sessionHelper;
        }
        // GET: /<controller>/
        public  IActionResult Index()
        {
            var viewModel = new OfferListVM();
            //var result = _service.GetList(_sessionHelper.CPMUser.ClientId);
            var result = _service.GetList(1);

            if (result.Result == GetResultEnum.Success)
            {
                //ModelMappings.Configure();
                viewModel.Offers = Mapper.Map<List<OfferInfoVM>>(result.List);
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Error", "Home", new { Area = "Global" });
            }            
        }

        public IActionResult Grid_Read([DataSourceRequest] DataSourceRequest request, string searchTerm = "")
        {
            GetListResult<OfferInfoBM> result;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                result = _service.GetList(1, searchTerm);
            }

            result = _service.GetList(1, "");

            if (result.Result == GetResultEnum.Success)
            {
               return View(Mapper.Map<List<OfferInfoVM>>(result.List));
            }

            return RedirectToAction("Error", "Home", new { Area = "Global" });
        }


        public IActionResult Filter()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var result = _service.GetItem(6);

            if(result.Result == GetResultEnum.Success)
            {
                return View(Mapper.Map<OfferVM>(result.Item));
            }
            else
            {
                return RedirectToAction("Error", "Home", new { Area = "Global" });
            }
        }


        public IActionResult Create()
        {
            var viewModel = new OfferVM();
            viewModel.Id = 0;
            //viewModel.ClientId = _sessionHelper.CPMUser.ClientId;
            viewModel.ClientId = 2;
            viewModel.IsNew = true;
            //viewModel.WebUserType = (int)_sessionHelper.CPMUser.WebUserType;
            viewModel.WebUserType = (int)Business.Common.Enums.WebUserType.Customer;

            return View("Create", viewModel);
        }
    }
}
