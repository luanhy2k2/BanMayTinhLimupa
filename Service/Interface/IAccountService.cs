using Microsoft.AspNetCore.Identity;
using Model.Models.entity;
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
        public Task<Object> GetUserWithRoleById(string id);
        public Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
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
