using EcommerceProject.DTO;
using EcommerceProject.Models;
using EcommerceProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountsRepository _accountsRepository;

        public AccountsController(AccountsRepository accountsRepository) 
        {
            _accountsRepository = accountsRepository;
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody]SignUpModel obj)
        {
            var result = await _accountsRepository.SignUp(obj);
            if (!result.Succeeded)
            {
                return Unauthorized(result.Errors);
            }
            else
                return Ok();
        }
    }
}
