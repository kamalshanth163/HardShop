using System.Threading.Tasks;
using HardShop_API.Models;

namespace HardShop_API.Data
{
    public interface IAuthRepository
    {
        Task<Customer> CustomerRegister(Customer customer, string password);
        Task<Customer> CustomerLogin(string username, string password);
        Task<bool> CustomerExists(string username);
        Task<Admin> AdminRegister(Admin admin, string password);
        Task<Admin> AdminLogin(string username, string password);
        Task<bool> AdminExists(string username);

    }
}