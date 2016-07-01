using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CpmLib.Web.Core.Session;

namespace CPM.Web.Common.Session
{
    public interface ISessionHelper :ISessionConfigBase
    {
        SessionCPMUserVM CPMUser { get; set; }
    }

    public class SessionHelper :SessionConfigBase, ISessionHelper
    {
        public SessionHelper(IHttpContextAccessor httpContextAccessor) :base(httpContextAccessor)
        {
            
        }  
        
        public SessionCPMUserVM CPMUser
        {
            get { return Session.GetObjectFromJson<SessionCPMUserVM>("User"); }
            set { Session.SetObjectAsJson("User", value); }
        }  
               

        public void ClearSession()
        {
            Session.Clear();
        }
    }
}
