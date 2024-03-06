using Application.Models;
using core_api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Admin;
using Service.Interface.Admin;
using System.Data;
using System.Text.RegularExpressions;

namespace core_api.Controllers.admin
{
    [Route("api/product")]
    public class ProductController : Controller
    {
       
        private IProductService _productService;
        private readonly IWebHostEnvironment _environment;
        public ProductController(IProductService productService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _environment = environment;
        }
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Manager)]
        [Route("update")]
        [HttpPost]
        public async Task<ActionResult> update([FromBody] ProductDetailModel sanpham)
        {
            try
            {
                var data = await _productService.UpdateProduct(sanpham);
                return Ok();
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Manager)]
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> create([FromBody] ProductDetailModel sanpham)
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
        [HttpPost("uploadFile")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Manager)]
        public async Task<string> UploadMessage([FromForm] IFormFile file)
        {
            var folderPath = Path.Combine(_environment.WebRootPath, "uploads");
            var filePath = Path.Combine(folderPath, file.FileName);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return file.FileName.ToString();
        }
    }
}
