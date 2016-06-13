using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Entities
{
    [Table("Address")]
    public class AddressEntity
    {
        public int Id { get; set; }
        public string AddressName { get; set; } //user provided
        public bool? IsPrimary { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string MailCode { get; set; }

    }
}
