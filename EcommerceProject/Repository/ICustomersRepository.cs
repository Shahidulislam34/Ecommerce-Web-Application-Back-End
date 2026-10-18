using EcommerceProject.DTO;
using EcommerceProject.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace EcommerceProject.Repository
{
    public interface ICustomersRepository
    {
        Task<CustomersModel> AddCustomers(CustomersModel cus);
        Task<List<CustomersModel>> GetAllCustomers();
        Task<List<CustomersDto>> GetCustomersByName(string name);
        Task<CustomersDto> GetFirstCustomerByName(string name);
        Task<CustomersModel> UpdateAllCustomersById(int id, CustomersModel obj);
        Task<CustomersModel> UpdateCustomerById(int id, CustomersModel obj);
        Task ReplacePropertiesByIdPatch(int id, JsonPatchDocument obj);
        Task<CustomersModel> RemovePropertiesByIdPatch(int id, JsonPatchDocument obj);
        Task DeleteCustomerById(int id);
    }
}