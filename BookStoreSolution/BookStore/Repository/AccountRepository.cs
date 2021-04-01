using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignupUserModel userModel)
        {
            var user = new ApplicationUser()                //for Default Identity table Use IdentityUser
            {
                FirstName=userModel.FirstName,
                lastName=userModel.lastName,
                Email = userModel.Email,
                UserName = userModel.Email
            };
            var result=await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

    }
}
