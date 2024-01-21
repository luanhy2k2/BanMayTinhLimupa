﻿using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Models.entity;
using Service.Client;
using Service.Interface.Client;

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
        [Route("createDonHang")]
        [HttpPost]
        public async Task<ActionResult> CreateDonHang([FromBody] CreateDonHang donhang)
        {
            try
            {
                var result = await _paymentService.AddOrder(donhang.customer, donhang.orderDetails, donhang.total);
                return Ok(donhang);
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