using CpmLib.Business.Core.Service;
using CpmLib.Business.Core.Validation;
using CpmLib.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CpmLib.Web.Core.Controller
{
    public abstract class CurdControllerBase :ControllerBase
    {
        protected void AddModelStateValidations(ValidationList validations)
        {
            foreach (var item in validations.GetInvalidItems())
            {
                ModelState.AddModelError(item.Field, item.Error);
            }
        }

        protected IActionResult SaveActionResult<T>(ProcessResult result, T model,
                                                     string viewName = "Modal")
        {
            switch (result.Result)
            {
                case ProcessResultEnum.Success:
                    return Ok();

                case ProcessResultEnum.Validation:
                    AddModelStateValidations(result.Validations);
                    SetBadRequestResponse();
                    return PartialView(viewName, model);

                case ProcessResultEnum.Error:
                    SetInternalErrorResponse();
                    return PartialView("_Error", new ErrorVM(result.ErrorDescription));

                default:
                    return Ok();
            }
        }

        protected IActionResult DeleteActionResult(ProcessResult result)
        {
            switch (result.Result)
            {
                case ProcessResultEnum.Success:
                    return Ok();

                case ProcessResultEnum.Validation:
                    SetBadRequestResponse();
                    return PartialView("_Validation",
                        new ValidationVM(result.Validations.GetInvalidList()));

                case ProcessResultEnum.Error:
                    SetInternalErrorResponse();
                    return PartialView("_Error", new ErrorVM(result.ErrorDescription));

                default:
                    return Ok();
            }
        }
    }
}
