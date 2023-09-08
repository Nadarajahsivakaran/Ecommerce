using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataServices.IServices
{
    public interface ICategoryService
    {
        Task<Response> GetAllCategory();
    }
}
