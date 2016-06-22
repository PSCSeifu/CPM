using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmLib.Web.Models
{
    public class ErrorVM
    {
        public string ErrorDescription { get; set; }

        public ErrorVM(string errorDescription)
        {
            ErrorDescription = errorDescription;
        }
    }
}
