using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Models.DTO
{
    public class CreateProductDTO
    {
        [Required, StringLength(30)]
        public string ProductName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [Required, Column(TypeName = "decimal(18, 2)")]
        [Range(1.00, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
