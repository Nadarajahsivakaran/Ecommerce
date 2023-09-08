﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Models.DTO
{
    public class CreateCategoryDTO
    {
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; } = string.Empty;
    }
}
