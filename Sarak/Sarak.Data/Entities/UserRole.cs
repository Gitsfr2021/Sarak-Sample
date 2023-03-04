using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sarak.Data.Entities
{
    [Table("UserRoles")]
    public class UserRole : IdentityUserRole<string>
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string AlternativeUsers { get; set; }
    }
}
