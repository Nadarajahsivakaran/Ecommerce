using E_commerce.Models;
using E_Commerce.DataServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataServices.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseService service;

        public ProductService(IBaseService service) {
            this.service = service;
        }

        public async Task<Response> GetAllProduct()
        {
            return await service.SendAsync(new Request
            {
                Url= "7001/api/Product"
            });
        }
    }
}
