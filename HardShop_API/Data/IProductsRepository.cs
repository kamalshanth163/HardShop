using System.Collections.Generic;
using System.Threading.Tasks;
using HardShop_API.Dtos;
using HardShop_API.Models;

namespace HardShop_API.Data
{
    public interface IProductsRepository
    {
        //  Task<List<Product>> GetProducts();
        Task<Product> GetProduct(ProductCreateDto productCreateDto);
        Task<ProductCategory> GetProductGategory(ProductCategoryCreateDto productCategoryCreateDto);
        Task<ProductOption> GetProductOption(ProductOptionCreateDto productOptionCreateDto, int productId);

        Task<Product> CreateProduct(Product product, ProductCategory productCategory);
        Task<ProductCategory> CreateProductCategory(ProductCategory productCategory);
        Task<ProductOption> CreateProductOption(ProductOption productOption, Product product);

        // Task<bool> ProductExists (ProductCreateDto productCreateDto);
        // Task<bool> ProductCategoryExists(ProductCategoryCreateDto productCategoryCreateDto);
        // Task<bool> ProductOptionExists(ProductOptionCreateDto productOptionCreateDto);

        //  Task<Product> UpdateProduct();

    }
}