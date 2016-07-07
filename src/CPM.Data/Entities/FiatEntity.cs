using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Entities
{
    public class FiatEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Code { get; set; }       
        public string Description { get; set; }
        public string Symbol { get; set; }       
        public int? ImageId { get; set; }
        public int? FlagId { get; set; }
    }
}
