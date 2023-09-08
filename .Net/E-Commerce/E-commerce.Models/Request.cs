using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Models
{
    public class Request
    {
        public object? Data { get; set; } = null;

        public RequestType Type { get; set; } = RequestType.GET;

        public string? Url { get; set; } 
    }   

    public enum RequestType
    {
        GET , POST, PUT, DELETE
    }
}
