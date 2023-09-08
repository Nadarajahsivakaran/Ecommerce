using E_commerce.Models;
using E_Commerce.DataServices.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            this.productService = productService;
            this.logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                Response response = await productService.GetAllProduct();
                if (response.IsSuccess)
                {
                    string JsonString = response.Res.ToString();
                    IEnumerable<ProductDTO> Products = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(JsonString);
                    return View(Products);
                }
                logger.LogError(response.Message.ToString());
                return View(Enumerable.Empty<ProductDTO>);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message.ToString());
                return View(Enumerable.Empty<ProductDTO>);
            }


        }
    }
}
