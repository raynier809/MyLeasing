﻿using Microsoft.AspNetCore.Identity;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Models;
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

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<bool> DeleteUserAsync(string email);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<SignInResult> ValidatePasswordAsync(User user, string password);

        Task<User> AddUser(AddUserViewMadel view, string role);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);


    }
}
