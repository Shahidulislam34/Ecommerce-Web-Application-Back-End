using AutoMapper;
using AutoMapper.QueryableExtensions;
using EcommerceProject.Data;
using EcommerceProject.DTO;
using EcommerceProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;

        public CustomersRepository(EcommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CustomersModel>> GetAllCustomers()
        {
            var allCus = await _context.customersTab.ToListAsync();
            return allCus;
        }
        public async Task<CustomersModel> AddCustomers(CustomersModel cus)
        {
            await _context.customersTab.AddAsync(cus);
            await _context.SaveChangesAsync();
            return cus;
        }
        public async Task<List<CustomersDto>> GetCustomersByName(string name)
        {
            //var customers = await _context.customersTab
            //    .Where(e => e.FullName == name)
            //    .Select(e => new CustomersDto
            //    {
            //        FullName = e.FullName,
            //        Email = e.Email,
            //        PhoneNumber = e.PhoneNumber,
            //        Address = e.Address
            //    }).ToListAsync();
            //return customers;


            //Using Auto Mappers:
            //var customers = await _context.customersTab
            //    .Where(e => e.FullName == name)
            //    .ProjectTo<CustomersDto>(_mapper.ConfigurationProvider)
            //    .ToListAsync();
            //return _mapper.Map<List<CustomersDto>>(customers);


            //Or 
            var customers = await _context.customersTab
                .Where(e => e.FullName == name)
                .ToListAsync();
            return _mapper.Map<List<CustomersDto>>(customers);
        }
        public async Task<CustomersDto> GetFirstCustomerByName(string name)
        {
            var cus = await _context.customersTab
                .Where(e => e.FullName == name)
                .Select(e => new CustomersDto
                {
                    FullName = e.FullName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    Address = e.Address
                })
                .FirstOrDefaultAsync();
            return cus;
        }
        public async Task<CustomersModel> UpdateAllCustomersById(int id, CustomersModel obj)
        {
            //Unoptimal way:Hit database two times
            List<CustomersModel> cus = await _context.customersTab
                .Where(e => e.Id == id)
                .ToListAsync();

            if (cus.Count > 0)
            {
                foreach (var x in cus)
                {
                    x.Id = id;
                    x.PhoneNumber = obj.PhoneNumber;
                    x.FullName = obj.FullName;
                    x.Email = obj.Email;
                    x.ConfirmPassword = obj.ConfirmPassword;
                    x.Address = obj.Address;
                }
                await _context.SaveChangesAsync();
                return obj;
            }
            return null;
        }
        public async Task<CustomersModel> UpdateCustomerById(int id, CustomersModel obj)
        {
            //Easy and optimum way: When exist a primary key, Hit database one times
            //var customer = new CustomersModel()
            //{
            //    Id = id,
            //    PhoneNumber = obj.PhoneNumber,
            //    FullName = obj.FullName,
            //    Email = obj.Email,
            //    ConfirmPassword = obj.ConfirmPassword,
            //    Address = obj.Address,
            //    CustomerID = obj.CustomerID
            //};

            var customer = _mapper.Map<CustomersModel>(obj);
            customer.Id = id;

            _context.customersTab.Update(customer);
            int save = await _context.SaveChangesAsync();
            if (save > 0)
                return obj;
            else
                return null;
        }
        public async Task ReplacePropertiesByIdPatch(int id, JsonPatchDocument obj)
        {
            var customer = await _context.customersTab.FindAsync(id);
            if (customer != null)
            {
                obj.ApplyTo(customer);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<CustomersModel> RemovePropertiesByIdPatch(int id, JsonPatchDocument obj)
        {
            var customer = await _context.customersTab.FindAsync(id);
            if (customer == null)
                return null;
            else
            {
                obj.ApplyTo(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
        }
        public async Task DeleteCustomerById(int id)
        {
            var customer = new CustomersModel()
            {
                Id = id
            };
            _context.customersTab.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
