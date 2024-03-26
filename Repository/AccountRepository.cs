using Application.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        private readonly IConfiguration _configuration;
        public AccountRepository( UserManager<ApplicationUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        public async Task<Object> SignIn(SignInModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                return "Tài khoản không tồn tại";
            }
            if (user.EmailConfirmed == false)
            {
                return false;
            }
            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (passwordValid == false)
            {
                return "Mật khẩu không đúng";
            }
            var userRole = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            foreach (var role in userRole)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var tokenDes = new JwtSecurityToken(
                expires:DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
            );
            var writeToken = new JwtSecurityTokenHandler().WriteToken(tokenDes);
            return new {token = writeToken, id = user.Id,fullName = user.hoTen };
        }
        public async Task<IdentityResult> ResetPassword(ApplicationUser user, string code, string newPassword)
        {
            var resetPassword = await _userManager.ResetPasswordAsync(user, code, newPassword);
            return resetPassword;
        }
        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return code;

        }
        public async Task<string> GenerateResetPasswordTokenAsync(ApplicationUser user)
        {
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            return code;
        }
        public async Task<ApplicationUser> FindUserByEmailAsync(string id)
        {
            try
            {
                return await _userManager.FindByEmailAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding user by id: {ex.Message}", ex);
            }
        }
        public async Task<bool> ConfirmEmailAsync(string userId, string code)
        {
            var user = await _userManager.FindByEmailAsync(userId);
            if (user == null)
            {
                // User không tồn tại
                return false;
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<IdentityResult> SignUp(SignUpModel model)
        {
            var user = new ApplicationUser
            {
                hoTen = model.hoTen,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
                address = model.address
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if(!await _roleManager.RoleExistsAsync(AppRole.Customer))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.Customer));
                }
                await _userManager.AddToRoleAsync(user, AppRole.Customer);
            }
            return result;
        }
    }
}
