using Microsoft.AspNetCore.Identity;
using Model.Models.entity;
using odel.Models.entity;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public Task<IdentityResult> AddAccountantRole(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> AddAdminRole(string id)
        {
            if (!await _repository.RoleExistsAsync(AppRole.Admin))
            {
                await _repository.CreateRoleAsync(AppRole.Admin);
            }

            var user = await _repository.FindUserByIdAsync(id);

            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            var existingRoles = await _repository.GetRolesAsync(user);

            if (existingRoles != null)
            {
                foreach (var role in existingRoles)
                {
                    await _repository.RemoveFromUserRoleAsync(user, role);
                }
            }

            var result = await _repository.AddToRoleAsync(user, AppRole.Admin);

            return result;
        }

        public async Task<IdentityResult> AddHrRole(string id)
        {
            
            if (!await _repository.RoleExistsAsync(AppRole.HR))
            {
                await _repository.CreateRoleAsync(AppRole.HR);
            }
            var user = await _repository.FindUserByIdAsync(id);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found"});
            }
            var existingRoles = await _repository.GetRolesAsync(user);
            if(existingRoles != null)
            {
                foreach(var role in existingRoles)
                {
                    await _repository.RemoveFromUserRoleAsync(user,role);
                }
            }
            var result = await _repository.AddToRoleAsync(user, AppRole.HR);
            return result;

        }

        public async Task<IdentityResult> AddManagerRole(string id)
        {
            if(!await _repository.RoleExistsAsync(AppRole.Manager))
            {
                await _repository.CreateRoleAsync(AppRole.Manager);
            }
            var user = await _repository.FindUserByIdAsync(id);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }
            var existingRoles = await _repository.GetRolesAsync(user);
            if(existingRoles != null)
            {
                foreach(var role in existingRoles)
                {
                    await _repository.RemoveFromUserRoleAsync(user,role);
                }
            }
            var reuslt = await _repository.AddToRoleAsync(user, AppRole.HR);
            return reuslt;
        }

        public async Task<IdentityResult> AddWareHouseRole(string id)
        {
            if (!await _repository.RoleExistsAsync(AppRole.Warehouse))
            {
                await _repository.CreateRoleAsync(AppRole.Warehouse);
            }
            var user = await _repository.FindUserByIdAsync(id);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }
            var existingRoles = await _repository.GetRolesAsync(user);
            if (existingRoles != null)
            {
                foreach (var role in existingRoles)
                {
                    await _repository.RemoveFromUserRoleAsync(user, role);
                }
            }
            var reuslt = await _repository.AddToRoleAsync(user, AppRole.Warehouse);
            return reuslt;
        }

        public async Task<IdentityResult> DeleteUserById(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                var result = await _repository.DeleteUserById(id);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error in service", ex);
            }
        }

        public async Task<object> GetAllUser(int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive integer");
            }
            try
            {
                var result = await _repository.GetAllUser(pageIndex, pageSize);
                if (result == null)
                {
                    throw new InvalidOperationException("GetAll operation did not return a valid result");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while get all entities", ex);
            }
        }

        
        public async Task<Object> SignIn(SignInModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Entity cannot be null.");
            }
            try
            {
                var result = await _repository.SignIn(model);
                if (result == null)
                {
                    throw new InvalidOperationException("operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred.", ex);
            }
        }

        public async Task<IdentityResult> SignUp(SignUpModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Entity cannot be null.");
            }
            try
            {
                var result = await _repository.SignUp(model);
                if (result == null)
                {
                    throw new InvalidOperationException("operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred.", ex);
            }
        }
        public async Task<IdentityResult> CreateStaff(SignUpModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Entity cannot be null.");
            }
            try
            {
                var result = await _repository.CreateStaff(model);
                if (result == null)
                {
                    throw new InvalidOperationException("operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred.", ex);
            }
        }

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "user cannot be null.");
            }
            try
            {
                var result = await _repository.UpdateUserAsync(user);
                if (result == null)
                {
                    throw new InvalidOperationException("Update operation did not return a valid result.");
                }
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred while updating the entity.", ex);
            }
        }
    }
}
