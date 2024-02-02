using Microsoft.AspNetCore.Mvc;
using Service.Interface.Admin;

namespace core_api.Controllers.admin
{
    [Route("api/warehouse")]
    public class WarehouseController : Controller
    {
        private IWarehouseService _service;
        public WarehouseController(IWarehouseService service)
        {
            _service = service;
        }
        [Route("getAll/{pageIndex}/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult> GetAll(int pageIndex, int pageSize)
        {
            try
            {
                var result = await _service.GetWarehouse(pageIndex, pageSize);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
