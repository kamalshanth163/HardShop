using System.Collections.Generic;
using System.Threading.Tasks;
using HardShop_API.Dtos;
using HardShop_API.Models;

namespace HardShop_API.Data {
    public interface IProductsRepository {
        // Main Category
        Task<ProductMainCategory> GetProductMainCategory (string name);
        Task<ProductMainCategory> GetProductMainCategory (int id);
        Task<IEnumerable<ProductMainCategory>> GetProductMainCategories ();
        Task<ProductMainCategory> CreateProductMainCategory (ProductMainCategory productMainCategory);

        // Sub Category
        Task<ProductSubCategory> GetProductSubCategory (string name);
        Task<ProductSubCategory> GetProductSubCategory (int id);
        Task<List<ProductSubCategory>> GetProductSubCategories ();
        Task<List<ProductSubCategory>> GetProductSubCategories (int mainCategoryId);
        Task<ProductSubCategory> CreateProductSubCategory (ProductSubCategory productSubCategory, ProductMainCategory productMainCategory);

        // Product
        Task<Product> GetProduct (string name);
        Task<Product> GetProduct (int id);
        Task<List<Product>> GetProducts ();
        Task<List<Product>> GetProducts (int subCategoryId);
        Task<Product> CreateProduct (Product product, ProductSubCategory productSubCategory);

        // Product Option
        Task<ProductOption> GetProductOption (ProductOption productOption, int productId);
        Task<ProductOption> GetProductOption (int id);
        Task<ProductOption> CreateProductOption (ProductOption productOption, Product product);

        // Operation
        Task<ProductOperation> CreateProductOperation (ProductOperation productOperation);

        // Review
        Task<ProductReview> CreateProductReview (ProductReview productReview);

    }
}