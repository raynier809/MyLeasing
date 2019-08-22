using Microsoft.AspNetCore.Identity;
using MyLeasing.Web.Data.Entities;
using System.Threading.Tasks;

namespace MyLeasing.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string rolName);

        Task AdduserToRoleAsync(User user, string rolName);

        Task<bool> IsUserInRoleAsync(User user, string rolName);
    }
}
