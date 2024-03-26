using Application.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Repository.Interface
{
    public interface IAccountRepository
    {
        public Task<string> GenerateResetPasswordTokenAsync(ApplicationUser user);
        public Task<ApplicationUser> FindUserByEmailAsync(string id);
        public Task<IdentityResult> ResetPassword(ApplicationUser user, string code, string newPassword);
        public Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        public Task<bool> ConfirmEmailAsync(string userId, string code);
        public Task<IdentityResult> SignUp(SignUpModel model);
        public Task<Object> SignIn(SignInModel model);
    }
}
