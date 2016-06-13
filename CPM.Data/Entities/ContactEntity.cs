using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Entities
{
    [Table("Contact")]
    public class ContactEntity
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public bool? IsPrimary { get; set; }

        public string AlternativeEmail { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }

        public string Extension { get; set; }
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }

    }
}
