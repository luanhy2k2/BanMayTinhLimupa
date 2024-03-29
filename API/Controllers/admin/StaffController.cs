﻿using Application.Models;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface.Admin;

namespace API.Controllers.admin
{
    [Route("api/staff")]
    public class StaffController : Controller
    {
        private readonly IStaffService _service;
        public StaffController(IStaffService service)
        {
            _service = service;
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
