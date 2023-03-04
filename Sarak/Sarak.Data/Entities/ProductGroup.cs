using Sarak.Data.Base;
using Sarak.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sarak.Data.Entities
{
    [Table("ProductGroup")]
    public class ProductGroup:BaseEntity
    {
        #region Properties

        [Display(Name = "عنوان")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "عنوان آدرس")]
        [Required]
        public string TitleURL { get; set; }

        [Display(Name = "عنوان صفحه")]
        [Required]
        public string PageTitle { get; set; }

        public string PageDescription { get; set; }
        public string PageDCSubject { get; set; }

        [Display(Name = "تصویر")]
        public string Picture { get; set; }

        [Display(Name = "تصویر")]
        public string Picture1 { get; set; }

        [Display(Name = "تصویر")]
        public string offerPic { get; set; }

        [Display(Name = "آیکن")]
        public string Icon { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        public string Color { get; set; }
        public bool IsDeleted { get; set; } = false;

        public bool isOffer { get; set; } = false;

        public int ShowOrder { get; set; }
        public byte Status { get; set; } = (byte)AllEnums.Status.Hide;
        public string Culture { get; set; } = "fa-IR";
        public bool HasColor { get; set; } = false;
        public bool HasSize { get; set; } = false;

        #endregion

        #region Relations

        public int? ParentId { get; set; }
        public virtual ProductGroup Parent { get; set; }
        public virtual ICollection<ProductGroup> Childs { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        #endregion
    }
}
