using System;
using System.Threading.Tasks;
using AutoMapper;
using HardShop_API.Data;
using HardShop_API.Dtos;
using HardShop_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HardShop_API.Controllers {
    [Route ("api/admins/{adminId}/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase {
        private readonly IProductsRepository _productsRepo;
        private readonly IMapper _mapper;
        public ProductsController (IProductsRepository productsRepo, IMapper mapper) {
            _productsRepo = productsRepo;
            _mapper = mapper;
        }

        [HttpPost ("categories/main")]
        public async Task<IActionResult> CreateProductMainCategory (ProductMainCategoryCreateDto productMainCategoryCreateDto) {
            var productMainCategoryToCreate = _mapper.Map<ProductMainCategory> (productMainCategoryCreateDto);
            var productMainCategory = await _productsRepo.GetProductMainCategory (productMainCategoryCreateDto.Name);
            if (productMainCategory != null)
                return BadRequest ("This product main category already exists");
            await _productsRepo.CreateProductMainCategory (productMainCategoryToCreate);
            return StatusCode (201);
        }

        [HttpGet ("categories/main")]
        public async Task<IActionResult> GetProductMainCategories () {
            var mainCategories = await _productsRepo.GetProductMainCategories ();
            return Ok (mainCategories);
        }

        [HttpGet ("categories/main/name/{mainName}")]
        public async Task<IActionResult> GetProductMainCategory (string mainName) {
            var mainCategory = await _productsRepo.GetProductMainCategory(mainName);
            return Ok (mainCategory);
        }

        [HttpGet ("categories/main/{mainId}")]
        public async Task<IActionResult> GetProductMainCategory (int mainId) {
            var mainCategory = await _productsRepo.GetProductMainCategory (mainId);
            return Ok (mainCategory);
        }

        [HttpGet ("categories/main/{mainId}/sub")]
        public async Task<IActionResult> GetProductSubCategories (int mainId) {
            var subCategories = await _productsRepo.GetProductSubCategories (mainId);
            return Ok (subCategories);
        }

        [HttpPost ("categories/sub")]
        public async Task<IActionResult> CreateProductSubCategory (ProductSubCategoryCreateDetailDto productSubCategoryCreateDetailDto) {
            var mainCategoryName = productSubCategoryCreateDetailDto.MainCategory;
            var mainCategoryFromRepo = await _productsRepo.GetProductMainCategory (mainCategoryName);

            var productSubCategoryCreateDto = _mapper.Map<ProductSubCategoryCreateDto>(productSubCategoryCreateDetailDto);

            if (mainCategoryFromRepo == null)
                return BadRequest ("The main category doesn't exist");
            var subCategoryFromRepo = await _productsRepo.GetProductSubCategory (productSubCategoryCreateDto.Name);
            if (subCategoryFromRepo != null) {
                if (subCategoryFromRepo.MainCategoryId == mainCategoryFromRepo.Id)
                    return BadRequest ("The sub category already exists under this main category");
                return BadRequest ("This sub category already exists");
            }

            var productSubCategoryToCreate = _mapper.Map<ProductSubCategory> (productSubCategoryCreateDto);
            await _productsRepo.CreateProductSubCategory (productSubCategoryToCreate, mainCategoryFromRepo);
            return StatusCode (201);
        }

        [HttpGet ("categories/sub")]
        public async Task<IActionResult> GetProductSubCategories () {
            var subCategories = await _productsRepo.GetProductSubCategories ();
            return Ok (subCategories);
        }

        [HttpGet ("categories/sub/{subId}")]
        public async Task<IActionResult> GetProductSubCategory (int subId) {
            var subCategory = await _productsRepo.GetProductSubCategory (subId);
            return Ok (subCategory);
        }

        [HttpGet ("categories/sub/{subId}/products")]
        public async Task<IActionResult> GetProducts (int subId) {
            var products = await _productsRepo.GetProducts (subId);
            return Ok (products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct (int adminid, ProductCreateDetailDto productCreateDetailDto) {
            var subCategoryName = productCreateDetailDto.SubCategory;
            var subCategoryFromRepo = await _productsRepo.GetProductSubCategory (subCategoryName);

            var productCreateDto = _mapper.Map<ProductCreateDto>(productCreateDetailDto);

            if (subCategoryFromRepo == null)
                return BadRequest ("The sub category doesn't exist");
            var productFromRepo = await _productsRepo.GetProduct (productCreateDto.Name);
            var productToCreate = _mapper.Map<Product> (productCreateDto);
            var productOptionToCreate = _mapper.Map<ProductOption> (productCreateDto);
            if (productFromRepo == null) {
                var createdProduct = await _productsRepo.CreateProduct (productToCreate, subCategoryFromRepo);
                var productOption = await _productsRepo.GetProductOption (productOptionToCreate, createdProduct.Id);
                if (productOption != null)
                    return BadRequest ("There is already a product with similar options");
                await _productsRepo.CreateProductOption (productOptionToCreate, createdProduct);
            }
            if (productFromRepo != null) {
                if (productFromRepo.SubCategoryId != subCategoryFromRepo.Id)
                    return BadRequest ("This product already exists in another sub category");
                var productOption = await _productsRepo.GetProductOption (productOptionToCreate, productFromRepo.Id);
                if (productOption != null)
                    return BadRequest ("There is already a product with similar options");
                await _productsRepo.CreateProductOption (productOptionToCreate, productFromRepo);
            }
            var productOperation = new ProductOperation {
                Name = "CREATE",
                Description = "Product is created",
                Created = DateTime.Now,
                MemberId = adminid,
                MemberRole = "admin",
                ProductOption = productOptionToCreate
            };
            await _productsRepo.CreateProductOperation (productOperation);
            return StatusCode (201);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts () {
            var products = await _productsRepo.GetProducts ();
            return Ok (products);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetProduct (int id) {
            var product = await _productsRepo.GetProduct (id);
            return Ok (product);
        }

    }
}