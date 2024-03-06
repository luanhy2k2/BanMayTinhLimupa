using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface.Client;

namespace core_api.Controllers.client
{
    [Route("api/productDetail")]
    public class ProductDetailController : Controller
    {
        private IProductDetailService _productDetailService;
        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }
        [Route("getProductById/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetProductById(int id)
        {
            try
            {
                var result = await _productDetailService.GetProductById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("getComment/{id}/{index}/{quantity}")]
        public async Task<ActionResult> GetCommmet(int id, int index, int quantity)
        {
            try
            {
                var result = await _productDetailService.GetAllComment(id, index, quantity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        [Route("addComment")]
        public Task<ProductComment> addComment([FromBody] ProductComment comment)
        {
            try
            {
                var result = _productDetailService.AddComment(comment);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
