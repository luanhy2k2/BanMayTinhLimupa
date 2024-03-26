using Application.Models;
using AutoMapper.Configuration;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository.Interface.Admin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Admin
{
    public class StaffRepository:IStaffRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public StaffRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
        public async Task<Object> GetAllUser(int pageIndex, int pageSize)
        {
            try
            {
                var query = await _userManager.Users.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                var count = await _userManager.Users.CountAsync();
                return new { results = query, total = count };
            }
            catch (Exception ex)
            {
                throw new Exception("Error in repository", ex);
            }
        }
        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser entity)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(entity.Email);
                if (user != null)
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
            catch (Exception ex)
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
