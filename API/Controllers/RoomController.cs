using Application.Models;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;
        public RoomController(IRoomService service)
        {
            _service = service;
        }
        [HttpGet("Get/{pageIndex}/{pageSize}")]
        public async Task<ActionResult> Get(int pageIndex,int pageSize)
        {
            try
            {
                var result = await _service.Get(pageIndex,pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _service.getById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpGet("GetRoomByUserId/{id}")]
        public async Task<ActionResult> GetRoomByUserId(string id)
        {
            try
            {
                var result = await _service.GetRomByUser(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<ActionResult> Update([FromBody] RoomModel model)
        {
            try
            {
                var result = await _service.Edit(User.Identity.Name, model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("create/{roomName}")]
        public async Task<ActionResult> Create(string roomName)
        {
            try
            {
                var result = await _service.Create(roomName,User.Identity.Name);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
