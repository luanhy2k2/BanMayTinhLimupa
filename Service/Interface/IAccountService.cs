using Application.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
namespace Service.Interface
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUp(SignUpModel model);
        public Task<IdentityResult> ResetPassword(string email, string code, string newPassword);
        public Task<string> GenerateEmailConfirmationTokenAsync(string userId);
        public Task<string> GenerateResetPasswordTokenAsync(string email);
        public Task<bool> ConfirmEmailAsync(string userId, string code);
        public Task<Object> SignIn(SignInModel model);
    }
}
