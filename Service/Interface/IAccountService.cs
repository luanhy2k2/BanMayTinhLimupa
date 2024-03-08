using Application.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUp(SignUpModel model);
        public Task<IdentityResult> CreateStaff(SignUpModel model);
        public Task<List<IdentityRole>> GetAllRole();
        public Task<Object> GetAllUser(int pageIndex, int pageSize);
        public Task<IdentityResult> ResetPassword(string email, string code, string newPassword);
        public Task<Object> GetUserWithRoleById(string id);
        public Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
        public Task<string> GenerateEmailConfirmationTokenAsync(string userId);
        public Task<string> GenerateResetPasswordTokenAsync(string email);
        public Task<bool> ConfirmEmailAsync(string userId, string code);
        public Task<IdentityResult> DeleteUserById(string id);
        public Task<Object> SignIn(SignInModel model);
        public Task<IdentityResult> AddAdminRole(string id);
        public Task<IdentityResult> RemoveFromUserRoleAsync(string id, string role);
        public Task<IdentityResult> AddHrRole(string id);
        public Task<IdentityResult> AddManagerRole(string id);
        public Task<IdentityResult> AddWareHouseRole(string id);
        public Task<IdentityResult> AddAccountantRole(string id);
    }
}
