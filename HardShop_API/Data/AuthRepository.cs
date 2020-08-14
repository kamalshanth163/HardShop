using System;
using System.Threading.Tasks;
using HardShop_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HardShop_API.Data {
    public class AuthRepository : IAuthRepository {
        private readonly DataContext _context;
        public AuthRepository (DataContext context) {
            _context = context;
        }

        public async Task<Customer> Register (Customer customer, string password) {

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash (password, out passwordHash, out passwordSalt);

            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;

            await _context.Customers.AddAsync (customer);
            await _context.SaveChangesAsync ();

            return customer;

        }

        private void CreatePasswordHash (string password, out byte[] passwordHash, out byte[] passwordSalt) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512 ()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (password));
            }
        }

        public async Task<Customer> Login (string email, string password) {
            var customer = await _context.Customers.FirstOrDefaultAsync (x => x.Email == email);
            if (customer == null)
                return null;
            if (!VerifyPasswordHash (password, customer.PasswordHash, customer.PasswordSalt))
                return null;

            return customer;
        }

        private bool VerifyPasswordHash (string password, byte[] passwordHash, byte[] passwordSalt) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512 (passwordSalt)) {
                var computedHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (password));
                for (int i = 0; i < computedHash.Length; i++) {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<bool> CustomerExists (string email) {
            if (await _context.Customers.AnyAsync (x => x.Email == email))
                return true;
            return false;
        }

        public async Task<bool> AdminExists (string email) {
            if (await _context.Admins.AnyAsync (x => x.Email == email))
                return true;
            return false;
        }

        public async Task<Admin> AdminLogin(string email, string password)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(x => x.Email == email);

            if(admin == null)
                return null;
            if(!VerifyPasswordHash(password, admin.PasswordHash, admin.PasswordSalt))
                return null;
            
            return admin;

        }

        public async Task<Admin> AdminRegister(Admin admin, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash (password, out passwordHash, out passwordSalt);

            admin.PasswordHash = passwordHash;
            admin.PasswordSalt = passwordSalt;

            await _context.Admins.AddAsync (admin);
            await _context.SaveChangesAsync ();

            return admin;
        }
    }
}