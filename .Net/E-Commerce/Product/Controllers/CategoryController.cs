using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.DataAccess.IRepository;
using Product.Models;
using Product.Models.DTO;

namespace Product.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly Response response;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            response = new Response();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllCategory()
        {
            try
            {
                IEnumerable<Category> categories = await unitOfWork.Category.GetAll();
                IEnumerable<CategoryDTO> categoryDtoList = mapper.Map<IEnumerable<CategoryDTO>>(categories);
                response.Res = categoryDtoList;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        [HttpGet("{CategoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetCategoryById(int CategoryId)
        {
            try
            {
                Category category = await unitOfWork.Category.GetById(c => c.CategoryId == CategoryId);
                if (category == null)
                    return HandleException(null, StatusCodes.Status204NoContent, "There are no records");


                CategoryDTO categoryDto = mapper.Map<CategoryDTO>(category);
                response.Res = categoryDto;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateCategory(CreateCategoryDTO entity)
        {
            try
            {
                bool isExit = await unitOfWork.Category.IsExist(c => c.CategoryName.ToLower() == entity.CategoryName.ToLower());
                if (isExit)
                    return HandleException(null, StatusCodes.Status400BadRequest, "The Category Name already exist");

                Category category = mapper.Map<Category>(entity);
                Category createdCategory = await unitOfWork.Category.Create(category);
                CategoryDTO categoryDto = mapper.Map<CategoryDTO>(createdCategory);
                response.Res = categoryDto;
                return CreatedAtAction(nameof(GetCategoryById), new { categoryDto.CategoryId }, response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateCategory(CategoryDTO entity)
        {
            try
            {
                bool isExit = await unitOfWork.Category.IsExist(c => c.CategoryName.ToLower() == entity.CategoryName.ToLower() && c.CategoryId != entity.CategoryId);
                if (isExit)
                    return HandleException(null, StatusCodes.Status400BadRequest, "The Category Name already exist");

                Category category = mapper.Map<Category>(entity);
                Category updatedCategory = await unitOfWork.Category.Update(category);
                CategoryDTO categoryDto = mapper.Map<CategoryDTO>(updatedCategory);
                response.Res = categoryDto;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete("{CategoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteCategory(int CategoryId)
        {
            try
            {
                bool IsDeleted = await unitOfWork.Category.Delete(c => c.CategoryId == CategoryId);
                if (IsDeleted)
                {
                    response.Message = "Deleted Successfully";
                    return Ok(response);
                }
                return HandleException(null, StatusCodes.Status204NoContent, "No Record found");

            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        private ActionResult HandleException(Exception? ex, int statusCode = StatusCodes.Status400BadRequest, string customMessage = null)
        {
            response.IsSuccess = false;
            response.Message = customMessage ?? customMessage ?? ex.Message.ToString();
            response.StatusCode = statusCode;
            return BadRequest(response);
        }

    }
}
