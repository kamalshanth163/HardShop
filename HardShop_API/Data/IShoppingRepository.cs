using System.Collections.Generic;
using System.Threading.Tasks;
using HardShop_API.Models;

namespace HardShop_API.Data
{
    public interface IShoppingRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Product>> GetProducts();
         Task<Product> GetProduct();
    }
}