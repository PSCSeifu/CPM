using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmLib.Business.Core.Validation
{
    public interface IValidatorBase<T>
    {
        T Item { get; set; }
        ValidationList Validations { get; }
        bool Validate();
    }

    public abstract class ValidatorBase<T> : IValidatorBase<T>
    {
        public T Item { get; set; }
        public ValidationList Validations { get; } = new ValidationList();

        public bool Validate()
        {
            AddValidations();
            RunValidations();
            return Validations.IsValid;
        }

        protected abstract void AddValidations();

        private void RunValidations()
        {
            foreach (var item in Validations.Items)
            {
                item.Validate();
            }
        }
    }
}
