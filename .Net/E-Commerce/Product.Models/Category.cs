using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Models
{
    [Table("Categories")]
    public class Category : Base
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, StringLength(30), Display(Name = "Category Name")]
        public string CategoryName { get; set; } = string.Empty;
    }
}