using System;
using System.Threading.Tasks;
using HardShop_API.Dtos;
using HardShop_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HardShop_API.Data
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _context;
        public ProductsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProduct(Product product, ProductCategory productCategory)
        {
            product.Category = productCategory;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<ProductCategory> CreateProductCategory(ProductCategory productCategory)
        {
            await _context.ProductCategories.AddAsync(productCategory);
            await _context.SaveChangesAsync();
            return productCategory;
        }

        public async Task<ProductOption> CreateProductOption(ProductOption productOption, Product product)
        {
            productOption.Product = product;
            await _context.ProductOptions.AddAsync(productOption);
            await _context.SaveChangesAsync();
            return productOption;
        }

        public async Task<Product> GetProduct(ProductCreateDto productCreateDto)
        {
            var productFromDb = await _context.Products.Include(p => p.ProductOptions).FirstOrDefaultAsync(p =>
                p.Name == productCreateDto.Name
            );
            return productFromDb;
        }

        public async Task<ProductCategory> GetProductGategory(ProductCategoryCreateDto productCategoryCreateDto)
        {
            var productCategoryFromDb = await _context.ProductCategories.Include(pc => pc.Products).FirstOrDefaultAsync(pc =>
              pc.MainCategory == productCategoryCreateDto.MainCategory &&
              pc.SubCategory1 == productCategoryCreateDto.SubCategory1 &&
              pc.SubCategory2 == productCategoryCreateDto.SubCategory2
            );
            return productCategoryFromDb;
        }

        public async Task<ProductOption> GetProductOption(ProductOptionCreateDto productOptionCreateDto, int productId)
        {
            var productOptionFromDb = await _context.ProductOptions.FirstOrDefaultAsync(po =>
                po.ProductId == productId &&
                po.Brand == productOptionCreateDto.Brand &&
                po.Model == productOptionCreateDto.Model &&
                po.Size == productOptionCreateDto.Size &&
                po.Color == productOptionCreateDto.Color
            );
            return productOptionFromDb;
        }
    }
}