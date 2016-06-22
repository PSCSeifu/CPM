using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmLib.Web.Core.Controller
{
    public abstract class ControllerBase :Microsoft.AspNetCore.Mvc.Controller
    {
        protected void SetBadRequestResponse()
        {
            Response.StatusCode = 400; //Bad request
        }

        protected void SetInternalErrorResponse()
        {
            Response.StatusCode = 500; //Internal Error
        }
    }
}
