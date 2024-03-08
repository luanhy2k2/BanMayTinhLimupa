
using Application.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Repository.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<object> SignIn(SignInModel model)
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
            return new {token = writeToken, hoTen = user.hoTen, role = userRole,
                id = user.Id, phone = user.PhoneNumber, address = user.address, email = user.Email  };


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
                // Xác nhận email thành công
                return true;
            }
            else
            {
                // Xác nhận email thất bại
                return false;
            }
        }
        public async Task<IdentityResult> CreateStaff(SignUpModel model)
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
                if (!await _roleManager.RoleExistsAsync(AppRole.Staff))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.Staff));
                }
                await _userManager.AddToRoleAsync(user, AppRole.Staff);
            }
            return result;
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
        public async Task<ApplicationUser> FindUserByIdAsync(string id)
        {
            try
            {
                return await _userManager.FindByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding user by id: {ex.Message}", ex);
            }
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
        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            try
            {
                return await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating role: {ex.Message}", ex);
            }
        }

        public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
        {
            try
            {
                return await _userManager.AddToRoleAsync(user, role);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding user to role: {ex.Message}", ex);
            }
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            try
            {
                return await _userManager.GetRolesAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting roles for user: {ex.Message}", ex);
            }
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            try
            {
                return await _roleManager.RoleExistsAsync(roleName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking if role exists: {ex.Message}", ex);
            }
        }
        public async Task<List<IdentityRole>> GetAllRole()
        {
            try
            {
                var result = await _roleManager.Roles.ToListAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("error while getting role in database");
            }
        }
        public async Task<Object> GetAllUser(int pageIndex, int pageSize)
        {
            try
            {
                var query = await _userManager.Users.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                var count = await _userManager.Users.CountAsync();
                return new { results = query, total = count };
            }
            catch(Exception ex)
            {
                throw new Exception("Error in repository", ex);
            }
        }
        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser entity)
        {
            try
            {
                var user = await FindUserByIdAsync(entity.Id);
                if(user != null)
                {
                    user.Email = entity.Email;
                    user.hoTen = entity.hoTen;
                    user.address = entity.address;
                    user.UserName = entity.UserName;
                    user.PhoneNumber = entity.PhoneNumber;
                }
                var result = await _userManager.UpdateAsync(user);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error in repository", ex);
            }
            
        }
        public async Task<IdentityResult> DeleteUserById(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user == null)
                {
                    
                    return IdentityResult.Failed(new IdentityError { Description = "User not found" });
                }
                var result = await _userManager.DeleteAsync(user);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in repository", ex);
            }
        }

        public async Task<IdentityResult> RemoveFromUserRoleAsync(ApplicationUser user, string role)
        {
            try
            {
                return await _userManager.RemoveFromRoleAsync(user, role);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error removing user from role: {ex.Message}", ex);
            }
        }
    }
}
