using System.Collections.Generic;
using System.Threading.Tasks;
using HardShop_API.Models;

namespace HardShop_API.Data
{
    public class ShoppingRepository : IShoppingRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetProduct()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAll()
        {
            throw new System.NotImplementedException();
        }
    }
}