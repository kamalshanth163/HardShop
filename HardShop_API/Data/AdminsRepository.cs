using System;
using System.Threading.Tasks;
using HardShop_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HardShop_API.Data
{
    public class AdminsRepository : IAdminsRepository
    {
        private readonly DataContext _context;
        public AdminsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Phone> AdminAddPhone(int adminId, Phone phone)
        {
            var adminFromRepo = await GetAdmin(adminId);

            var phoneFromDb = await _context.Phones.FirstOrDefaultAsync(p => p.e164Number == phone.e164Number);

            if(phoneFromDb == null)
            {
                await _context.Phones.AddAsync(phone);
                await _context.SaveChangesAsync();

                var phoneFromRepo = await GetPhone(phone.Id);

                var createdAdminPhone = await CreateAdminPhone(adminFromRepo, phoneFromRepo);
            }
            else{
                var createdAdminPhone = await CreateAdminPhone(adminFromRepo, phoneFromDb);
            }

            return phone;
        }

        public async Task<bool> AdminPhoneExists(int adminId, Phone phone)
        {
            var phoneFromDb = await _context.Phones.FirstOrDefaultAsync(p => p.e164Number == phone.e164Number);

            if (phoneFromDb != null)
            {
                var adminPhoneFromDb = await _context.AdminPhones.FirstOrDefaultAsync(cp => cp.AdminId == adminId && cp.PhoneId == phoneFromDb.Id);

                if (adminPhoneFromDb != null)
                    return true;
                return false;
            }
            return false;
        }

        public async Task<AdminPhone> CreateAdminPhone(Admin admin, Phone phone)
        {
            var adminPhoneToCreate = new AdminPhone
            {
                Admin = admin,
                Phone = phone,
            };

            adminPhoneToCreate.Created = DateTime.Now;

            await _context.AdminPhones.AddAsync(adminPhoneToCreate);
            await _context.SaveChangesAsync();

            return adminPhoneToCreate;
        }

        public async Task<Admin> GetAdmin(int id)
        {
            Admin admin = await _context.Admins.Include(c => c.AdminPhones).ThenInclude(cp => cp.Phone).FirstOrDefaultAsync(c => c.Id == id);
            return admin;
        }

        public async Task<Phone> GetPhone(int id)
        {
            Phone phone = await _context.Phones.FirstOrDefaultAsync(c => c.Id == id);
            return phone;
        }
    }
}