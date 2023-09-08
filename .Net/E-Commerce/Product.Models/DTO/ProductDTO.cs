using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Models.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Required, StringLength(30), Display(Name = "Product Name")]
        public string ProductName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [Required, Column(TypeName = "decimal(18, 2)")]
        public double Price { get; set; }

        public CategoryDTO? Category { get; set; }
    }
}
