using EcommerceProject.Data;
using EcommerceProject.DTO;
using EcommerceProject.Models;
using Microsoft.AspNetCore.Identity;

namespace EcommerceProject.Repository
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountsRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> SignUp(SignUpModel obj)
        {
            var info = new ApplicationUser()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                PhoneNumber =  obj.PhoneNumber,
                Email = obj.Email
            };
            return await _userManager.CreateAsync(info, obj.Password);
        }
    }
}
