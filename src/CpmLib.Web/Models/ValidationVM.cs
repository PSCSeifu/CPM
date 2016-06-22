using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmLib.Web.Models
{
    public class ValidationVM
    {
        public List<string> Validations { get; set; }

        public ValidationVM(List<string> validations)
        {
            Validations = validations;
        }
    }
}
