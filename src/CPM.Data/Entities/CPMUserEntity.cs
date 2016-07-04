using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data.Entities
{
    public class CPMUserEntity
    {
        public string Actions { get; set; }
        public bool? AgreedOnTerms { get; set; }
        public bool? CanReadEmails { get; set; }
        public bool? CheckIsUsedBefore { get; set; }
        public int? ClientId { get; set; }
        public DateTime? DateRegistered { get; set; }
        public string Email { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int Id { get; set; }
        public DateTime? LastSawMessage { get; set; }
        public int? LoginAttempts { get; set; }       
        public string Password2 { get; set; }
        [Column("Password")]
        public string PasswordHash { get; set; }

        public int? PasswordStrength { get; set; }
        public string PreviousPasswords { get; set; }       
        public string Surname { get; set; }
        public bool? Suspended { get; set; }
        public string Username { get; set; }
        public int? WebUserType { get; set; }
    }
}
