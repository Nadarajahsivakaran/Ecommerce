using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Models.DTO
{
    public class Response
    {
        public bool IsSuccess { get; set; } = true;

        public int StatusCode { get; set; } = 200;

        public object? Message { get; set; } = null;

        public object? Res { get; set; } = null;
    }
}
