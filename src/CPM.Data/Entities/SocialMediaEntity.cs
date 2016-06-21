using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CPM.Data.Entities
{
    [Table("SocialMedia")]
    public class SocialMediaEntity
    {
        public int Id { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string SnapChat { get; set; }
        
    }
}
