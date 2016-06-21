using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmLib.Business.Core.Validation
{
    public abstract class ValidationItem
    {
        public string Name { get; protected set; }
        public string Field { get; set; }
        public string Label { get; set; }
        public string Error { get; protected set; }
        public bool IsValid { get { return Error == ""; } }

        public ValidationItem(string name, string field, string label)
        {
            Name = name;
            Field = field;
            Label = label;
            Error = "";
        }

        public abstract void Validate();
    }
}
