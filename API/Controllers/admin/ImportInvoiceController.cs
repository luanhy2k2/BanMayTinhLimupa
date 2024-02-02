using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using odel.Models.entity;
using Service.Interface.Admin;

namespace core_api.Controllers.admin
{
    [Route("api/importInvoice")]
    public class ImportInvoiceController : Controller
    {
        private IImportInvoiceService _service;
        public ImportInvoiceController(IImportInvoiceService service)
        {
            _service = service;
        }
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Accountant)]
        [Route("createInvoice")]
        [HttpPost]
        public async Task<ActionResult> CreateInvoice([FromBody] HoaDonNhap model)
        {
            try
            {
                var data = await _service.createInvoice(model);
                return Ok(data);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Accountant)]
        [Route("createInvoiceDetail")]
        [HttpPost]
        public async Task<ActionResult> CreateInvoiceDetail([FromBody] ChiTietHoaDonNhap model)
        {
            try
            {
                var data = await _service.createInvoiceDetail(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("getAll/{pageIndex}/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult> GetAll(int pageIndex, int pageSize)
        {
            try
            {
                var data = await _service.getAllInvoice(pageIndex, pageSize);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("getInvoiceById/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetInvoiceById(int id)
        {
            try
            {
                var data = await _service.getInvoiceById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("getInvoiceDetailById/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetInvoiceDetailByid(int id)
        {
            try
            {
                var data = await _service.getInvoiceDetailById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
