using Application.Models;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;
        public MessageController(IMessageService service)
        {
            _service = service;
        }
        [HttpGet("Get/{name}/{pageIndex}/{pageSize}")]
        public async Task<IActionResult> Get(int pageIndex, int pageSize, string name)
        {
            try
            {
                var result = await _service.Get(pageIndex, pageSize, name);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] CreateMessage model)
        {
            try
            {
                var result = await _service.Create(User.Identity.Name, model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [HttpGet]
        public ActionResult GetName()
        {
            var rs =  User.Identity.Name;
            return Ok(rs);
        }

    }
}
