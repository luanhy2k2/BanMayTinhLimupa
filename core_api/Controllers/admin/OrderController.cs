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
                var data = await _orderService.GetAllOrder(pageIndex, pageSize);
                return Ok(data);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("updateDelivery/{id}/{delivery}")]
        [HttpPost]
        public async Task<ActionResult> UpdateDelivery(int id, string delivery)
        {
            try
            {
                var result = await _orderService.UpdateDelivery(id, delivery);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("updatePaymentStatus/{id}/{status}")]
        [HttpPost]
        public async Task<ActionResult> UpdatePaymentStatus(int id, string status)
        {
            try
            {
                var result = await _orderService.UpdatePaymentStatus(id, status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("confirmOrder/{id}")]
        [HttpPost]
        public async Task<ActionResult> ConfirmOrder(int id)
        {
            try
            {
                var result = await _orderService.ConfirmOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("getOrder/{phone}/{pageIndex}/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult> getOrder(string phone, int pageIndex, int pageSize)
        {
            try
            {
                var data = await _orderService.GetOrder(phone, pageIndex, pageSize);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("getOrderById/{id}")]
        [HttpGet]
        public async Task<ActionResult> getOrderById(int id)
        {
            try
            {
                var data = await _orderService.GetOrderById(id);
                return Ok(data);
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        [Route("getOrderDetailById/{id}")]
        [HttpGet]
        public async Task<ActionResult> getOrderDetailById(int id)
        {
            try
            {
                var data = await _orderService.GetOrderDetailById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
    }
}
