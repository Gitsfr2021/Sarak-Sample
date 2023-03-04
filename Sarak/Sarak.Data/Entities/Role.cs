using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sarak.Data.Entities
{
    [Table("Roles")]
    public class Role : IdentityRole<string>
    {
        [Display(Name ="عنوان نقش")]
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Display(Name ="توضیحات")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name ="وضعیت فعال")]
        public bool IsActive { get; set; }

        [Display(Name ="وضعیت قفل")]
        public bool? Locked { get; set; }

        /// <summary>
        /// یک آرایه جیسون حاوی اطلاعات افراد جایگزین
        /// </summary>
        [Display(Name ="تغییرات افراد جایگزین")]
        public string AlternativeUsers { get; set; }

        public override string ToString()
        {
            return $"{this.Title} ({Name})";
        }
    }
}
