using Application.Helpers;
using Application.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly SendEmail _sendEmail;
        public AccountService(IAccountRepository repository, SendEmail sendEmail)
        {
            _repository = repository;
            _sendEmail = sendEmail;
        }

        public async Task<IdentityResult> AddAccountantRole(string id)
        {
            if (!await _repository.RoleExistsAsync(AppRole.Accountant))
            {
                await _repository.CreateRoleAsync(AppRole.Accountant);
            }
            var user = await _repository.FindUserByIdAsync(id);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            var result = await _repository.AddToRoleAsync(user, AppRole.Accountant);
            return result;
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
            
            var reuslt = await _repository.AddToRoleAsync(user, AppRole.Manager);
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

        public async Task<object> GetUserWithRoleById(string id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id can not be null");
            }
            try
            {
                var user = await _repository.FindUserByIdAsync(id);
                if (user == null)
                {
                    throw new InvalidOperationException("findUser operation did not return a valid result");
                }
                var roles = await _repository.GetRolesAsync(user);
                var result = new { userInfo = user, roles };
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occurred while get user with roles");
            }
        }

        public async Task<List<IdentityRole>> GetAllRole()
        {
            try
            {
                var result = await _repository.GetAllRole();
                if (result == null)
                {
                    throw new InvalidOperationException("GetAllRole operation did not return a valid result");
                }
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occurred while get all role");
            }
        }

        public async Task<IdentityResult> RemoveFromUserRoleAsync(string id, string role)
        {
            if(id == null || role == null)
            {
                throw new ArgumentNullException("id or role can not be null");
            }
            try
            {
                var user = await _repository.FindUserByIdAsync(id);
                if(user == null)
                {
                    throw new InvalidOperationException("findUserById did not return valid result");
                }
                var result = await _repository.RemoveFromUserRoleAsync(user, role);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occured while remove role");
            }
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(string userId)
        {
            try
            {
                if(userId == null)
                {
                    throw new ArgumentNullException();
                }
                var user = await _repository.FindUserByIdAsync(userId);
                var result = await _repository.GenerateEmailConfirmationTokenAsync(user);
                var token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(result));
                var callbackUrl = $"https://localhost:7261/api/account/confirmEmail?userId={userId}&code={token}";

                await _sendEmail.SendEmailAsync(user.Email, "Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi, vui lòng click vào đoạn link sau để xác thực tài khoản cuản bạn: "+ callbackUrl );
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error while generate token", ex);
            }
        }

        public async Task<bool> ConfirmEmailAsync(string userId, string code)
        {
            try
            {
                if(userId== null && code == null)
                {
                    throw new ArgumentNullException();
                }
                var result = await _repository.ConfirmEmailAsync(userId, code);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error while confirm email", ex);
            }
        }
    }
}
