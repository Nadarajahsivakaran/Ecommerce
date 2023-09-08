using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Models
{
    [Table("Products")]
    public class Products : Base
    {
        [Key]
        public int ProductId { get; set; }

        [Required,StringLength(30),Display(Name ="Product Name")]
        public string ProductName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [Required, Column(TypeName = "decimal(18, 2)")]
        [Range(1.00, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
    }
}
