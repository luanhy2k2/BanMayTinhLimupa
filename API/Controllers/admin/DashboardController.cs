using Microsoft.AspNetCore.Mvc;
using Service.Interface.Admin;

namespace API.Controllers.admin
{
    [Route("api/dashboard")]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _service;
        public DashboardController(IDashboardService service)
        {
            _service = service;
        }
        [HttpGet("orderDuringDay")]
        public async Task<ActionResult> OrderDuringDay()
        {
            var result = await _service.OrderDuringDay();
            return Ok(result);
        }
        [HttpGet("orderDuringMonth")]
        public async Task<ActionResult> OrderDuringMonth()
        {
            var result = await _service.OrderDuringMonth();
            return Ok(result);
        }
        [HttpGet("RevenueDuringDay")]
        public async Task<ActionResult> RevenueDuringDay()
        {
            var result = await _service.RevenueDuringDay();
            return Ok(result);
        }
        [HttpGet("RevenueDuringMonth")]
        public async Task<ActionResult> RevenueDuringMonth()
        {
            var result = await _service.RevenueDuringMonth();
            return Ok(result);
        }
        [HttpGet("totalProduct")]
        public async Task<ActionResult> TotalProduct()
        {
            var result = await _service.TotalProduct();
            return Ok(result);
        }
        [HttpGet("totalUser")]
        public async Task<ActionResult> TotalUser()
        {
            var result = await _service.TotalUser();
            return Ok(result);
        }
    }
}
