using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sarak.Data.Entities
{
    [Table("Users")]
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        public string Mobile { get; set; }

        public DateTime? LastLoginDate { get; set; }
        public DateTime CreateDate { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName} ({UserName})";
        }

    }
}
