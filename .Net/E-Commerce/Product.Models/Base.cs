using System.ComponentModel.DataAnnotations;

namespace Product.Models
{
    public class Base
    {
        public int? IsDelete { get; set; } = 0;

        [DataType(DataType.Date)] 
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }

}
