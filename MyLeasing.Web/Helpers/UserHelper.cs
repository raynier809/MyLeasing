using Microsoft.AspNetCore.Identity;
using MyLeasing.Web.Data.Entities;
using System.Threading.Tasks;

namespace MyLeasing.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(
                UserManager<User> userManager,
                RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AdduserToRoleAsync(User user, string rolName)
        {
            await _userManager.AddToRoleAsync(user, rolName);
        }

        public async Task CheckRoleAsync(string rolName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(rolName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = rolName
                });
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string rolName)
        {
            return await _userManager.IsInRoleAsync(user, rolName);
        }
    }
}
