using Application.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Admin
{
    public interface IStaffService
    {
        public Task<IdentityResult> CreateStaff(SignUpModel model);
        public Task<Object> GetAllUser(int pageIndex, int pageSize);
        public Task<Object> GetUserWithRoleById(string id);
        public Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
        public Task<IdentityResult> DeleteUserById(string id);
        public Task<IdentityResult> AddAdminRole(string id);
        public Task<IdentityResult> RemoveFromUserRoleAsync(string id, string role);
        public Task<IdentityResult> AddHrRole(string id);
        public Task<IdentityResult> AddManagerRole(string id);
        public Task<IdentityResult> AddWareHouseRole(string id);
        public Task<IdentityResult> AddAccountantRole(string id);
    }
}
