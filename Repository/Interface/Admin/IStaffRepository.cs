using Application.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Admin
{
    public interface IStaffRepository
    {
        public Task<Object> GetAllUser(int pageIndex, int pageSize);
        public Task<ApplicationUser> FindUserByEmailAsync(string id);
        public Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
        public Task<IdentityResult> DeleteUserById(string id);
        public Task<IdentityResult> CreateStaff(SignUpModel model);
        public Task<ApplicationUser> FindUserByIdAsync(string id);
        public Task<IdentityResult> CreateRoleAsync(string roleName);
        public Task<bool> RoleExistsAsync(string roleName);
        public Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
        public Task<IList<string>> GetRolesAsync(ApplicationUser user);
        public Task<IdentityResult> RemoveFromUserRoleAsync(ApplicationUser user, string role);
    }
}
