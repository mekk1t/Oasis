using Microsoft.AspNetCore.Identity;
using OasisWebApp.DTOs;
using OasisWebApp.Models;
using System.Threading.Tasks;

namespace OasisWebApp.Services.AccountService
{
    public class AccountService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountService(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public async Task<UserModel> CheckUserAsync(UserDto userDto)
        {
            bool passwordIsCorrect = false;
            var userResult = await userManager.FindByNameAsync(userDto.Username);
            if (userResult != null)
            {
                passwordIsCorrect = await userManager.CheckPasswordAsync(userResult, userDto.Password);
            }
            if (userResult != null && passwordIsCorrect)
            {
                return new UserModel()
                {
                    User = userResult,
                    HasCorrectPassword = passwordIsCorrect
                };
            }
            return new UserModel()
            {
                User = userResult,
                HasCorrectPassword = passwordIsCorrect
            };
        }

        public async Task<bool> Login(UserDto userDto)
        {
            var user = await CheckUserAsync(userDto);
            if (user.HasCorrectPassword && user.User != null)
            {
               await signInManager.SignInAsync(user.User, false);
               return true;
            }
            return false;
        }

        public async Task SignOutUser()
        {
            await signInManager.SignOutAsync();
        }
    }
}
