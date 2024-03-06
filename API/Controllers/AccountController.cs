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
       
        public AccountController(IAccountService service, SendEmail sendEmail)
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
     
        [HttpGet("confirmEmail")]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("userId and code are required.");
            }

            var decodedCodeBytes = WebEncoders.Base64UrlDecode(code);
            var decodedCode = Encoding.UTF8.GetString(decodedCodeBytes);

            var result = await _service.ConfirmEmailAsync(userId, decodedCode);
            if (result == true)
            {
                return Ok("Email confirmed successfully.");
            }
            else
            {
                return BadRequest("Error confirming email.");
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
        [Authorize(Roles = AppRole.Admin + "," + AppRole.HR)]
        [HttpPost("createStaff")]
        public async Task<ActionResult> CreateStaff([FromBody] SignUpModel model)
        {
            var result = await _service.CreateStaff(model);

            if (!result.Succeeded)
            {
                // Handle failed signup
                return StatusCode(500);
            }

            return Ok("User registered successfully");
        }
        [Authorize(Roles = AppRole.Admin)]
        [HttpPost("addAdminRole/{id}")]
        public async Task<ActionResult> AddAdminRole(string id)
        {
            var result = await _service.AddAdminRole(id);

            if (!result.Succeeded)
            {
                // Handle failed signup
                return StatusCode(500);
            }

            return Ok(result);
        }
        [Authorize(Roles = AppRole.Admin)]
        [HttpPost("addHrRole/{id}")]
        public async Task<ActionResult> AddHrRole(string id)
        {
            var result = await _service.AddHrRole(id);

            if (!result.Succeeded)
            {
                // Handle failed signup
                return StatusCode(500);
            }

            return Ok(result);
        }
        [Authorize(Roles = AppRole.Admin)]
        [HttpPost("addManagerRole/{id}")]
        public async Task<ActionResult> AddManagerRole(string id)
        {
            var result = await _service.AddManagerRole(id);

            if (!result.Succeeded)
            {
                // Handle failed signup
                return StatusCode(500);
            }

            return Ok(result);
        }
        [Authorize(Roles = AppRole.Admin)]
        [HttpPost("addAccountantRole/{id}")]
        public async Task<ActionResult> AddAccountantRole(string id)
        {
            var result = await _service.AddAccountantRole(id);

            if (!result.Succeeded)
            {
                // Handle failed signup
                return StatusCode(500);
            }

            return Ok(result);
        }
        [Authorize(Roles = AppRole.Admin)]
        [HttpPost("addWareHouseRole/{id}")]
        public async Task<ActionResult> AddWareHouseRole(string id)
        {
            var result = await _service.AddWareHouseRole(id);

            if (!result.Succeeded)
            {
                // Handle failed signup
                return StatusCode(500);
            }

            return Ok(result);
        }
        [Authorize(Roles = AppRole.Admin)]
        [HttpDelete("removeUserRole/{id}/{role}")]
        public async Task<ActionResult> RemoveUserRole(string id, string role)
        {
            var result = await _service.RemoveFromUserRoleAsync(id, role);

            if (!result.Succeeded)
            {
                // Handle failed signup
                return StatusCode(500);
            }

            return Ok(result);
        }
        [HttpGet("getAll/{pageIndex}/{pageSize}")]
        public async Task<ActionResult> GetAllUser(int pageIndex, int pageSize)
        {
            try
            {
                var result = await _service.GetAllUser(pageIndex, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }


        }
        [HttpGet("getById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            try
            {
                var result = await _service.GetUserWithRoleById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }


        }
        [HttpGet("getAllRole")]
        public async Task<ActionResult> GetAllRole()
        {
            try
            {
                var result = await _service.GetAllRole();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }


        }
        [Authorize(Roles = AppRole.Admin + "," + AppRole.HR + "," + AppRole.Manager)]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteUserbyId(string id)
        {
            try
            {
                var result = await _service.DeleteUserById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [Authorize(Roles = AppRole.Admin + "," + AppRole.HR + "," + AppRole.Manager)]
        [HttpPost("updateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] ApplicationUser user)
        {
            try
            {
                var result = await _service.UpdateUserAsync(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}


