using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HardShop_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HardShop_API.Data
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DataContext _context;
        public CustomersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Phone> CustomerAddPhone(int customerId, Phone phone)
        {

            var customerFromRepo = await GetCustomer(customerId);

            var phoneFromDb = await _context.Phones.FirstOrDefaultAsync(p => p.e164Number == phone.e164Number);

            if (phoneFromDb == null)
            {
                await _context.Phones.AddAsync(phone);
                await _context.SaveChangesAsync();

                var phoneFromRepo = await GetPhone(phone.Id);

                var createdCustomerPhone = await CreateCustomerPhone(customerFromRepo, phoneFromRepo);
            }
            else
            {
                var createdCustomerPhone = await CreateCustomerPhone(customerFromRepo, phoneFromDb);
            }

            return phone;
        }

        public async Task<CustomerPhone> CreateCustomerPhone(Customer customer, Phone phone)
        {
            var customerPhoneToCreate = new CustomerPhone
            {
                Customer = customer,
                Phone = phone
            };

            customerPhoneToCreate.Created = DateTime.Now;

            await _context.CustomerPhones.AddAsync(customerPhoneToCreate);
            await _context.SaveChangesAsync();

            return customerPhoneToCreate;

        }

        public async Task<Customer> GetCustomer(int id)
        {
            Customer customer = await _context.Customers.Include(c => c.CustomerPhones).ThenInclude(cp => cp.Phone).FirstOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        public async Task<Phone> GetPhone(int id)
        {
            Phone phone = await _context.Phones.FirstOrDefaultAsync(c => c.Id == id);
            return phone;
        }

        public async Task<bool> CustomerPhoneExists(int customerId, Phone phone)
        {
            var phoneFromDb = await _context.Phones.FirstOrDefaultAsync(p => p.e164Number == phone.e164Number);

            if (phoneFromDb != null)
            {
                var customerPhoneFromDb = await _context.CustomerPhones.FirstOrDefaultAsync(cp => cp.CustomerId == customerId && cp.PhoneId == phoneFromDb.Id);

                if (customerPhoneFromDb != null)
                    return true;
                return false;
            }
            return false;
        }
    }
}