using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using odel.Models.entity;
using Service.Interface.Admin;

namespace core_api.Controllers.admin
{
    [Route("api/exportInvoice")]
    public class ExportInvoiceController : Controller
    {
        private IExportInvoiceDetailService _exportInvoiceDetailService;
        private IExportInvoiceService _exportInvoiceService;
        public ExportInvoiceController( IExportInvoiceDetailService exportInvoiceDetailService, IExportInvoiceService exportInvoiceService)
        {
            _exportInvoiceDetailService = exportInvoiceDetailService;
            _exportInvoiceService = exportInvoiceService;

        }
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Accountant)]
        [Route("createInvoice")]
        [HttpPost]
        public async Task<ActionResult> CreateInvoice([FromBody] HoaDonBan model)
        {
            try
            {
                var result = await _exportInvoiceService.Create(model);
                return Ok(model);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Accountant)]
        [Route("createInvoiceDetail")]
        [HttpPost]
        public async Task<ActionResult> CreateInvoiceDetail([FromBody] ChiTietHoaDonBan model)
        {
            try
            {
                var result = await _exportInvoiceDetailService.Create(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
