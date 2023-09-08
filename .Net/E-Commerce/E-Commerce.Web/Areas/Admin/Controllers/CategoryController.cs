using E_commerce.Models;
using E_Commerce.DataServices.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ILogger<CategoryController> logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            this.categoryService = categoryService;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                Response response = await categoryService.GetAllCategory();
                if (response.IsSuccess)
                {
                    string jsonResponse = response.Res.ToString();
                    IEnumerable<CategoryDTO> categoryDTO = JsonConvert.DeserializeObject<IEnumerable<CategoryDTO>>(jsonResponse);
                    return View(categoryDTO);
                }
                logger.LogError(response.Message.ToString());
                return View(Enumerable.Empty<CategoryDTO>());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message.ToString());
                return View(Enumerable.Empty<CategoryDTO>());
            }
        }
    }
}
