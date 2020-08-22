using System.Threading.Tasks;
using HardShop_API.Models;

namespace HardShop_API.Data
{
    public interface IAdminsRepository
    {
        Task<Phone> AdminAddPhone (int adminId, Phone phone);
        Task<AdminPhone> CreateAdminPhone(Admin admin, Phone phone);
        Task<Admin> GetAdmin(int id);
        Task<Phone> GetPhone(int id);
        Task<bool> AdminPhoneExists(int adminId, Phone phone);
    }
}