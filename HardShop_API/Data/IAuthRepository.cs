using System.Threading.Tasks;
using HardShop_API.Models;

namespace HardShop_API.Data {
    public interface IAuthRepository {
        Task<Customer> Register (Customer customer, string password);
        Task<Customer> Login (string username, string password);
        Task<bool> CustomerExists (string username);
        Task<Admin> AdminLogin (string username, string password);
        Task<Admin> AdminRegister (Admin admin, string password);
        Task<bool> AdminExists (string username);
    }
}