using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardShop_API.Dtos;
using HardShop_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HardShop_API.Data {
    public class ProductsRepository : IProductsRepository {
        private readonly DataContext _context;
        public ProductsRepository (DataContext context) {
            _context = context;
        }

        // Main Category
        public async Task<IEnumerable<ProductMainCategory>> GetProductMainCategories () {
            var mainCategories = await _context.ProductMainCategories.Include (pmc => pmc.ProductSubCategories).ThenInclude (psc => psc.Products).ThenInclude (p => p.ProductOptions).ToListAsync ();
            return mainCategories;
        }
        public async Task<ProductMainCategory> GetProductMainCategory (string name) {
            var mainCategory = await _context.ProductMainCategories.Include (pmc => pmc.ProductSubCategories).ThenInclude (psc => psc.Products).ThenInclude (p => p.ProductOptions).FirstOrDefaultAsync (pmc => pmc.Name == name);
            return mainCategory;
        }
        public async Task<ProductMainCategory> GetProductMainCategory (int id) {
            var mainCategory = await _context.ProductMainCategories.Include (pmc => pmc.ProductSubCategories).ThenInclude (psc => psc.Products).ThenInclude (p => p.ProductOptions).FirstOrDefaultAsync (pmc => pmc.Id == id);
            return mainCategory;
        }
        public async Task<ProductMainCategory> CreateProductMainCategory (ProductMainCategory productMainCategory) {
            await _context.ProductMainCategories.AddAsync (productMainCategory);
            await _context.SaveChangesAsync ();
            return productMainCategory;
        }

        // Sub Category
        public Task<List<ProductSubCategory>> GetProductSubCategories (int mainCategoryId) {
            var subCategories = _context.ProductSubCategories.Include (psc => psc.Products).ThenInclude (p => p.ProductOptions).Where (psc => psc.MainCategoryId == mainCategoryId).ToListAsync ();
            return subCategories;
        }
        public Task<List<ProductSubCategory>> GetProductSubCategories () {
            var subCategories = _context.ProductSubCategories.Include (psc => psc.Products).ThenInclude (p => p.ProductOptions).ToListAsync ();
            return subCategories;
        }

        public async Task<ProductSubCategory> GetProductSubCategory (string name) {
            var subCategory = await _context.ProductSubCategories.Include (psc => psc.Products).ThenInclude (p => p.ProductOptions).FirstOrDefaultAsync (psc => psc.Name == name);
            return subCategory;
        }
        public async Task<ProductSubCategory> GetProductSubCategory (int id) {
            var subCategory = await _context.ProductSubCategories.Include (psc => psc.Products).ThenInclude (p => p.ProductOptions).FirstOrDefaultAsync (psc => psc.Id == id);
            return subCategory;
        }
        public async Task<ProductSubCategory> CreateProductSubCategory (ProductSubCategory productSubCategory, ProductMainCategory productMainCategory) {
            productSubCategory.MainCategory = productMainCategory;
            await _context.ProductSubCategories.AddAsync (productSubCategory);
            await _context.SaveChangesAsync ();
            return productSubCategory;
        }

        public async Task<Product> CreateProduct (Product product, ProductSubCategory productSubCategory) {
            product.SubCategory = productSubCategory;
            await _context.Products.AddAsync (product);
            await _context.SaveChangesAsync ();
            return product;
        }

        public async Task<ProductOption> CreateProductOption (ProductOption productOption, Product product) {
            productOption.Product = product;
            await _context.ProductOptions.AddAsync (productOption);
            await _context.SaveChangesAsync ();
            return productOption;
        }

        public async Task<Product> GetProduct (string name) {
            var productFromDb = await _context.Products.Include (p => p.ProductOptions).FirstOrDefaultAsync (p =>
                p.Name == name
            );
            return productFromDb;
        }
        public async Task<Product> GetProduct (int id) {
            var productFromDb = await _context.Products.Include (p => p.ProductOptions).FirstOrDefaultAsync (p =>
                p.Id == id
            );
            return productFromDb;
        }
        public Task<List<Product>> GetProducts () {
            var products = _context.Products.Include (p => p.ProductOptions).ToListAsync ();
            return products;
        }
        public Task<List<Product>> GetProducts (int subCategoryId) {
            var products = _context.Products.Include (p => p.ProductOptions).Where (p => p.SubCategoryId == subCategoryId).ToListAsync ();
            return products;
        }

        public async Task<ProductOption> GetProductOption (ProductOption productOption, int productId) {
            var productOptionFromDb = await _context.ProductOptions.FirstOrDefaultAsync (po =>
                po.ProductId == productId &&
                po.Model == productOption.Model &&
                po.Size == productOption.Size &&
                po.Color == productOption.Color
            );
            return productOptionFromDb;
        }
        public async Task<ProductOption> GetProductOption (int id) {
            var productOptionFromDb = await _context.ProductOptions.FirstOrDefaultAsync (po => po.Id == id);
            return productOptionFromDb;
        }

        public async Task<ProductOperation> CreateProductOperation (ProductOperation productOperation) {
            await _context.ProductOperations.AddAsync (productOperation);
            await _context.SaveChangesAsync ();
            return productOperation;
        }

        public async Task<ProductReview> CreateProductReview (ProductReview productReview) {
            await _context.ProductReviews.AddAsync (productReview);
            await _context.SaveChangesAsync ();
            return productReview;
        }

    }
}