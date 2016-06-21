using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmLib.Business.Core.Validation
{
    public class ValidationList
    {

        public List<ValidationItem> Items { get; set; } = new List<ValidationItem>();

        public bool IsValid
        {
            get
            {
                return Items.Where(i => !i.IsValid).ToList().Count == 0;
            }
        }

        public void AddItem(ValidationItem item)
        {
            Items.Add(item);
        }

        public bool HasItems(string field)
        {
            return GetItems(field).Count > 0;
        }

        public bool HasItems(string field, string name)
        {
            return GetItems(field, name).Count > 0;
        }

        public List<ValidationItem> GetInvalidItems()
        {
            return Items.Where(i => !i.IsValid).ToList();
        }

        public List<string> GetInvalidList()
        {
            return Items.Where(i => !i.IsValid).Select(i => i.Error).ToList();
        }

        public List<ValidationItem> GetItems(string field)
        {
            return Items.Where(i => i.Field.ToLower() == field.ToLower()).ToList();
        }

        public List<ValidationItem> GetItems(string field, string name)
        {
            return Items.Where(i => i.Field.ToLower() == field.ToLower()
                                 && i.Name.ToLower() == name.ToLower())
                                    .ToList();
        }

        public void Merge(ValidationList validationsToMerge)
        {
            Items.AddRange(validationsToMerge.Items);
        }
    }
}
