using Model.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Admin;
using Service.Interface.Admin;

namespace core_api.Controllers.client
{
    [Route("api/order")]
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [Route("getall/{pageIndex}/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult> getAll(int pageIndex, int pageSize)
        {
            try
            {
                var data = await _orderService.getAll(pageIndex, pageSize);
                return Ok(data);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("getOrder/{id}/{pageIndex}/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult> getOrder(int id, int pageIndex, int pageSize)
        {
            try
            {
                var data = await _orderService.GetOrder(id,pageIndex, pageSize);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("getOrderById/{id}")]
        [HttpGet]
        public async Task<DonHang> getOrderById(int id)
        {
            try
            {
                var data = await _orderService.getById(id);
                return data;
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        //[Route("getOrderDetailById/{id}")]
        //[HttpGet]
        //public IActionResult getOrderDetailById(int id)
        //{
        //    var data = from o in db.ChiTietDonHangs
        //               join s in db.Sanphams on o.SanpId equals s.SanpId
        //               select new
        //               {
        //                   o.SanpId,
        //                   s.SanpName,
        //                   o.SoLuong,
        //                   o.GiaMua,
        //                   o.MaDonHang
        //               };
        //    return Ok(data.Where(x => x.MaDonHang == id).OrderByDescending(x => x.MaDonHang).ToList());
        //}
    }
}
