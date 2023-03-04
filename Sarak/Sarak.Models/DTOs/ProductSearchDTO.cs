
using Sarak.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;

namespace Sarak.Models.DTOs
{
    public class ProductSearchDTO 
    {
        public string Title { get; set; }

        public string Code { get; set; }

    }
}
