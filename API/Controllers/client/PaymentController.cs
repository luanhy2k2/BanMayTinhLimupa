using Microsoft.AspNetCore.Mvc;
using Service.Interface.Client;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Application.Models;

namespace core_api.Controllers.client
{
    [Route("api/donhang")]
    public class PaymentController : Controller
    {
        private IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [Authorize]
        [Route("createDonHang")]
        [HttpPost]
        public async Task<ActionResult> CreateDonHang([FromBody] CreateDonHang donhang)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    // Các tùy chọn khác nếu cần
                };

                var result = await _paymentService.AddOrder(donhang.customer, donhang.orderDetails, donhang.total);
                var jsonResult = JsonSerializer.Serialize(donhang, options);
                return Ok(jsonResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Route("getOrderByCustomerPhone/{phone}/{index}/{quantity}")]
        [HttpPost]
        public async Task<ActionResult> GetOrderByCustomerPhone(string phone, int index, int quantity)
        {
            try
            {
                var result = await _paymentService.GetOrderByCustomerPhone(phone, index, quantity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
