using E_commerce.Models;
using E_Commerce.DataServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataServices.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseService service;

        public CategoryService(IBaseService service) {
            this.service = service;
        }

        public async Task<Response> GetAllCategory()
        {
            return await service.SendAsync(new Request
            {
                Url = "7001/api/Category"
            });
        }
    }
}
