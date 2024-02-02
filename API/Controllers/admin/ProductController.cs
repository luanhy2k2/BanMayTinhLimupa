using core_api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Models.entity;
using odel.Models.entity;
using Repository.Interface.Admin;
using Service.Interface.Admin;
using System.Data;

namespace core_api.Controllers.admin
{
    [Route("api/product")]
    public class ProductController : Controller
    {
       
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Manager)]
        [Route("update")]
        [HttpPost]
        public async Task<ActionResult> update([FromBody] ProductDetail sanpham)
        {
            try
            {
                var data = await _productService.UpdateProduct(sanpham);
                return Ok(data);
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Manager)]
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> create([FromBody] ProductDetail sanpham)
        {
            try
            {
                var data = await _productService.CreateProduct(sanpham);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        [HttpGet]
        [Route("getAll/{pageIndex}/{pageSize}")]
        public async Task<ActionResult> getAll(int pageIndex, int pageSize)
        {
            try
            {
                var data = await _productService.getProduct(pageIndex, pageSize);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception("error:", ex);
            }

        }
        [HttpGet]
        [Route("getById/{id}")]
        public async Task<ActionResult> getById(int id)
        {
            try
            {
                var data = await _productService.getProductbyId(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        [Route("search/{name}/{pageIndex}/{pageSize}")]
        public async Task<ActionResult> search(string name, int pageIndex, int pageSize)
        {
            try
            {
                var data = await _productService.searchProduct(name, pageIndex, pageSize);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Manager)]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> delete(int id)
        {
            try
            {
                var data = await _productService.Delete(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
