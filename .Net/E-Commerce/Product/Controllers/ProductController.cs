using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.DataAccess.IRepository;
using Product.Models;
using Product.Models.DTO;

namespace Product.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly Response response;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            response = new Response();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllProducts()
        {
            try
            {
                string[] includeProperties = { "Category" };
                IEnumerable<Products> products = await unitOfWork.Product.GetAll(includeProperties);
                IEnumerable<ProductDTO> productDtoList = mapper.Map<IEnumerable<ProductDTO>>(products);
                foreach (var productDto in productDtoList)
                {
                    productDto.Category = mapper.Map<CategoryDTO>(productDto.Category);
                }
                response.Res = productDtoList;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        [HttpGet("{ProductId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetProductById(int ProductId)
        {
            try
            {
                string[] includeProperties = { "Category" };
                Products Product = await unitOfWork.Product.GetById(c => c.ProductId == ProductId, includeProperties);
                if (Product == null)
                    return HandleException(null, StatusCodes.Status204NoContent, "There are no records");


                ProductDTO productDto = mapper.Map<ProductDTO>(Product);
                productDto.Category = mapper.Map<CategoryDTO>(productDto.Category);
                response.Res = productDto;
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

        public async Task<ActionResult> CreateProduct(CreateProductDTO entity)
        {
            try
            {
                bool isExit = await unitOfWork.Product.IsExist(p => p.ProductName.ToLower() == entity.ProductName.ToLower());
                if (isExit)
                    return HandleException(null, StatusCodes.Status400BadRequest, "The Product Name already exist");

                Products product = mapper.Map<Products>(entity);
                Products createdProduct = await unitOfWork.Product.Create(product);
                ActionResult getProduct = await GetProductById(createdProduct.ProductId);

                if (getProduct is OkObjectResult okResult && okResult.Value is Response res)
                {
                    res.StatusCode = StatusCodes.Status201Created;
                    return CreatedAtAction(nameof(GetProductById), new { createdProduct.ProductId }, res);
                }
                return HandleException(null, StatusCodes.Status400BadRequest, "Something Wrong");


            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateProduct(UpdateProductDTO entity)
        {
            try
            {
                bool isExit = await unitOfWork.Product.IsExist(p => p.ProductName.ToLower() == entity.ProductName.ToLower() && p.ProductId != entity.ProductId);
                if (isExit)
                    return HandleException(null, StatusCodes.Status400BadRequest, "The Category Name already exist");

                Products product = mapper.Map<Products>(entity);
                Products updatedProduct = await unitOfWork.Product.Update(product);
                ActionResult getProduct = await GetProductById(entity.ProductId);

                return getProduct is OkObjectResult okResult && okResult.Value is Response res ?
                    Ok(res) : HandleException(null, StatusCodes.Status400BadRequest, "Something Wrong");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete("{ProductId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteProduct(int ProductId)
        {
            try
            {
                bool IsDeleted = await unitOfWork.Product.Delete(c => c.ProductId == ProductId);
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

        private ActionResult HandleException(Exception? ex, int statusCode = StatusCodes.Status400BadRequest, object? customMessage = null)
        {
            response.IsSuccess = false;
            response.Message = customMessage ?? customMessage ?? ex.Message.ToString();
            response.StatusCode = statusCode;
            return BadRequest(response);
        }

    }
}
