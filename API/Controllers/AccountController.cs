using Application.Models;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Application.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace API.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
       
        public AccountController(IAccountService service)
        {
            _service = service;
           
        }
        
        [HttpPost("signin")]
        public async Task<ActionResult> SignIn([FromBody] SignInModel model)
        {
            var result = await _service.SignIn(model);

            if (result == null)
            {
                return BadRequest("Invalid credentials");
            }

            return Ok(result);
        }
        [HttpPost("generateConfirmTokenEmail/{userId}")]
        public async Task<ActionResult> GenerateConfirmTokenEmail(string userId)
        {
            var result = await _service.GenerateEmailConfirmationTokenAsync(userId);

            if (result == null)
            {
                return BadRequest("");
            }

            return Ok(result);
        }
        [HttpPost("generateTokenResetpassword/{email}")]
        public async Task<ActionResult> GenerateTokenResetPassword(string email)
        {
            var result = await _service.GenerateResetPasswordTokenAsync(email);

            if (result == null)
            {
                return BadRequest("");
            }

            return Ok(result);
        }

        [HttpGet("confirmEmail")]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            var result = await _service.ConfirmEmailAsync(userId, code);
            if (result == true)
            {
                return Ok("Email confirmed successfully.");
            }
            else
            {
                return BadRequest("Error confirming email.");
            }
        }
        [HttpPost("resetPassword")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPs model)
        {
            var result = await _service.ResetPassword(model.email, model.code,model.newPassword);
            if (result.Succeeded)
            {
                return Ok("Reset password successfully.");
            }
            else
            {
                return BadRequest("Error.");
            }
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp([FromBody] SignUpModel model)
        {
            var result = await _service.SignUp(model);

            if (!result.Succeeded)
            {
                // Handle failed signup
                return StatusCode(500);
            }

            return Ok("User registered successfully");
        }
       
    }
}


