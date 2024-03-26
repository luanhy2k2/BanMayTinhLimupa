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
        private readonly IRoomService _roomService;
        public AccountService(IAccountRepository repository, IRoomService roomService, SendEmail sendEmail)
        {
            _repository = repository;
            _roomService = roomService;
            _sendEmail = sendEmail;
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
                var room = await _roomService.Create(model.hoTen, model.Email);
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
        public async Task<string> GenerateEmailConfirmationTokenAsync(string userId)
        {
            try
            {
                if(userId == null)
                {
                    throw new ArgumentNullException();
                }
                var user = await _repository.FindUserByEmailAsync(userId);
                var result = await _repository.GenerateEmailConfirmationTokenAsync(user);
                var token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(result));
                var callbackUrl = $"https://localhost:7261/api/account/confirmEmail?userId={userId}&code={token}";

                await _sendEmail.SendEmailAsync(user.Email, "Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi, vui lòng click vào đoạn link sau để xác thực tài khoản cuản bạn: "+ callbackUrl );
                return token;
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
                var decodedCodeBytes = WebEncoders.Base64UrlDecode(code);
                var decodedCode = Encoding.UTF8.GetString(decodedCodeBytes);
                var result = await _repository.ConfirmEmailAsync(userId, decodedCode);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error while confirm email", ex);
            }
        }

        public async Task<IdentityResult> ResetPassword(string email, string code, string newPassword)
        {
            try
            {
                if(email == null || code == null || newPassword == null)
                {
                    throw new ArgumentNullException();
                }
                var user = await _repository.FindUserByEmailAsync(email);
                if (user == null)
                {
                    return null;
                }
                var decodedCodeBytes = WebEncoders.Base64UrlDecode(code);
                var decodedCode = Encoding.UTF8.GetString(decodedCodeBytes);
                var result = await _repository.ResetPassword(user, decodedCode,newPassword);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while reset password", ex);
            }
        }
        public async Task<string> GenerateResetPasswordTokenAsync(string email)
        {
            try
            {
                if (email == null)
                {
                    throw new ArgumentNullException();
                }
                var user = await _repository.FindUserByEmailAsync(email);
                if (user == null)
                {
                    return null;
                }
                var result = await _repository.GenerateResetPasswordTokenAsync(user);
                var token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(result));
                var callbackUrl = $"http://localhost:4200/client/resetPassword/{email}/{token}";

                await _sendEmail.SendEmailAsync(user.Email, "Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi, vui lòng click vào đoạn link sau để đổi mật khẩu bạn: " + callbackUrl);
                return token;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while generate token", ex);
            }
        }
    }
}
