using System.Collections.Generic;
using System.Threading.Tasks;
using HardShop_API.Models;

namespace HardShop_API.Data
{
    public interface ICustomersRepository
    {
        Task<Phone> CustomerAddPhone(int customerId, Phone phone);
        Task<CustomerPhone> CreateCustomerPhone(Customer customer, Phone phone);
        Task<Customer> GetCustomer(int id);
        Task<Phone> GetPhone(int id);
        Task<bool> CustomerPhoneExists(int customerId, Phone phone);
    }
}