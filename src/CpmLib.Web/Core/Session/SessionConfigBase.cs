using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CpmLib.Web.Core.Session
{
    public interface ISessionConfigBase
    {

    }

    public class SessionConfigBase
    {
        IHttpContextAccessor _HttpContextAccessor;

        public SessionConfigBase(IHttpContextAccessor httpContextAccessor)
        {
            _HttpContextAccessor = httpContextAccessor;
        }    

        protected  ISession  Session
        {
            get
            {
                return _HttpContextAccessor.HttpContext.Session;
            }
        }
    }
}
