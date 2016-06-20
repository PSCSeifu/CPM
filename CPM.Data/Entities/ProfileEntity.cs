using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Entities
{
    [Table("Profile")]
    public class ProfileEntity
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        //Profile type - Indivdual, organisation

        #region Common
        public string Email { get; set; }
        #endregion

        #region Individual
        public string Title { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime? DateOfBirth { get; set; } 
        public string Gender { get; set; } = "";
        public string Occupation { get; set; } = "";
        public int ImageId { get; set; } = 0;
        #endregion

        #region Companywwwwwwwww
        public string CompanyName { get; set; } = "";
        public DateTime? DateEstablished { get; set; }
        public int? IncorporationType { get; set; } //Ltd, Private
        public int? BusinessCategory { get; set; }
        public int? BusinessSector { get; set; } //needs own table
        public int? EmployeeSize { get; set; }
        public int? BusinessLocations { get; set; }
        public int? RevenueLevel { get; set; }
        #endregion
    }
}
