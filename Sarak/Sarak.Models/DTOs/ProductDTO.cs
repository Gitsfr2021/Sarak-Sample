
using Sarak.Data.Entities;
using Sarak.Data.Enums;
using Sarak.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;

namespace Sarak.Models.DTOs
{
    public class ProductDTO  :BaseModel
    {
        #region Properties

        [StringLength(200)]
        [Display(Name = "عنوان")]
        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="کد")]
        public string Code { get; set; }


     
        [StringLength(500)]
        public string AttachedFile { get; set; }


        [Display(Name = "عنوان صفحه")]
        public string PageTitle { get; set; }

        [Required]
        [Display(Name = "عنوان آدرس")]
        public string TitleURL { get; set; }

        [StringLength(200)]
        public string PageDescription { get; set; }

        public string PageDCSubject { get; set; }

      
        [StringLength(500)]
        public string Picture { get; set; }


        [Column(TypeName = "ntext")]
        public string Feature { get; set; }


        [Column(TypeName = "ntext")]
        public string HtmlBody { get; set; }

        [Column(TypeName = "ntext")]
        public string Help { get; set; }

        public int? ShowOrder { get; set; } 

        public byte Status { get; set; } = (byte)AllEnums.Status.Hide;

        public bool ShowInMain { get; set; } = false;

        public bool MenGift { get; set; } = false;
        public bool WomanGift { get; set; } = false;
        public bool CartGift { get; set; } = false;
        public bool BocGift { get; set; } = false;

        [StringLength(5)]
        public string Culture { get; set; } = "fa-IR";

        public DateTime DateX { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;

        public int? Point{ get; set; }

        public long Weight { get; set; } = 0;
        public string Warranty { get; set; }

        public int? Viewcount { set; get; } = 0;

        public int? LikeCount { set; get; } = 0;
        public int? DisLikeCount { set; get; } = 0;

        #endregion

        #region Relations

        [Display(Name = "گروه")]
        public int ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public int? ProductTypeId { set; get; }

        #endregion
    }
}
