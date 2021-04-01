using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignupUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SigninModel signInModel);
    }
}