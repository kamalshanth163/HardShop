using System.Threading.Tasks;
using AutoMapper;
using HardShop_API.Data;
using HardShop_API.Dtos;
using HardShop_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HardShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepo;
        private readonly IMapper _mapper;
        public ProductsController(IProductsRepository productsRepo, IMapper mapper)
        {
            _productsRepo = productsRepo;
            _mapper = mapper;
        }

        [HttpPost("category")]
        public async Task<IActionResult> CreateProductCategory(ProductCategoryCreateDto productCategoryCreateDto)
        {
            var productCategoryToCreate = _mapper.Map<ProductCategory>(productCategoryCreateDto);
            var productCategory = await _productsRepo.GetProductGategory(productCategoryCreateDto);
            if (productCategory != null)
                return BadRequest("This Product Category already exists");
            await _productsRepo.CreateProductCategory(productCategoryToCreate);
            return StatusCode(201);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDto productCreateDto)
        {
            var productCategory = await _productsRepo.GetProductGategory(productCreateDto.ProductCategory);
            if (productCategory == null)
                return BadRequest("There is no such product category");
            var product = await _productsRepo.GetProduct(productCreateDto);
            var productToCreate = _mapper.Map<Product>(productCreateDto);
            var productOptionToCreate = _mapper.Map<ProductOption>(productCreateDto.ProductOption);
            if (product == null)
            {
                var createdProduct = await _productsRepo.CreateProduct(productToCreate, productCategory);
                var productOption = await _productsRepo.GetProductOption(productCreateDto.ProductOption, createdProduct.Id);
                if (productOption != null)
                    return BadRequest("There is already a product with similar options");
                await _productsRepo.CreateProductOption(productOptionToCreate, createdProduct);
            }
            if (product != null)
            {
                var productOption = await _productsRepo.GetProductOption(productCreateDto.ProductOption, product.Id);
                if (productOption != null)
                    return BadRequest("There is already a product with similar options");

                await _productsRepo.CreateProductOption(productOptionToCreate, product);
            }
            return StatusCode(201);
        }
    }
}