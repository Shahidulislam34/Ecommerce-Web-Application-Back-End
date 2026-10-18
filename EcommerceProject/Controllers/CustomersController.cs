using EcommerceProject.Data;
using EcommerceProject.DTO;
using EcommerceProject.Models;
using EcommerceProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepo;
        public CustomersController(ICustomersRepository customersRepo)
        {
            _customersRepo = customersRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var allCus = await _customersRepo.GetAllCustomers();
            return Ok(allCus);
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomersByName([FromQuery] string name)
        {
            var customers = await _customersRepo.GetCustomersByName(name);
            if (customers.Count == 0)
                return NotFound("Customer is Not Found");
            else
                return Ok(customers);
        }
        [HttpGet]
        public async Task<IActionResult> GetFirstCustomerByName([FromQuery] string name)
        {
            var cus = await _customersRepo.GetFirstCustomerByName(name);
            if (cus == null)
                return NotFound("Customer is not found.");
            else
                return Ok(cus);
        }


        [HttpPost]
        public async Task<IActionResult> AddCustomers([FromBody] CustomersModel cus)
        {
            var added = await _customersRepo.AddCustomers(cus);
            //return Ok(cus);
            return CreatedAtAction(
                nameof(GetCustomersByName),
                new { name = added.FullName },
                added
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllCustomersById([FromRoute] int id, [FromBody]CustomersModel cus)
        {
            var updated = await _customersRepo.UpdateAllCustomersById(id, cus);
            if (updated == null)
                return NotFound("Update is not completed.");
            else
                return Ok(updated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerById([FromRoute] int id, [FromBody]CustomersModel cus)
        {
            var updated = await _customersRepo.UpdateCustomerById(id, cus);
            if (updated == null)
                return NotFound("Update is not completed.");
            else
                return Ok(updated);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> ReplacePropertiesByIdPatch([FromRoute]int id, [FromBody]JsonPatchDocument obj)
        {
            await _customersRepo.ReplacePropertiesByIdPatch(id, obj);
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> RemovePropertiesByIdPatch([FromRoute]int id, [FromBody]JsonPatchDocument obj)
        {
            var res = await _customersRepo.RemovePropertiesByIdPatch(id, obj);
            if (res == null)
                return NotFound("Customer is not found");
            else
                return Ok(res);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerById([FromRoute] int id)
        {
            await _customersRepo.DeleteCustomerById(id);
            return Ok("Deletion Successful");
        }



        //[HttpPut("{name}")]
        //public 

        /*
        Without Repository:
        private readonly EcommerceDbContext _dbContext;
        public CustomersController(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult addCustomers(CustomersModel obj)
        {
            obj.CreatedAt = DateTime.Now;
            _dbContext.customerTab.Add(obj);
            _dbContext.SaveChanges();
            return Ok(obj);
        }
        [HttpPost]
        public IActionResult loginCustomers(CustomersModel obj)
        {
            CustomersModel cus = _dbContext.customerTab.FirstOrDefault(c => c.Email == obj.Email);
            if (cus == null) return NotFound(false);
            if (cus.Password == obj.Password) return Ok(true);
            else return NotFound(false);
        }
        [HttpGet]
        public IActionResult getAllCustomers()
        {
            List<CustomersModel> allCus = new List<CustomersModel>();
            allCus = _dbContext.customerTab.ToList();
            //List<CustomersModel> allCus = _dbContext.customerTab.ToList();
            return Ok(allCus);
        }
        [Route("get-all-by-email")]//works this route instead of action method name
        [HttpGet]
        public IActionResult getAllByEmail(string email)
        {
            List<CustomersModel> cus = new List<CustomersModel>();
            cus = _dbContext.customerTab.Where(c => c.Email == email).ToList();
            if (cus == null || cus.Count == 0)
            {
                return NotFound("Data is not found");
            }
            else
            {
                return Ok(cus);
            }
        }*/


    }
}
