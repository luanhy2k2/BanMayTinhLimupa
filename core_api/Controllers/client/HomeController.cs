using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Model.Models.entity;
using Service.Interface.Client;

namespace core_api.Controllers.client
{
    [Route("api/Home")]
    public class HomeController : Controller
    {
        private readonly IHomePageService _homePageService;
        public HomeController(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }
        [HttpGet]
        [Route("banChay/{index}/{quantity}")]
        public async Task<ActionResult> SellingProduct(int index,int quantity)
        {
            try
            {
                var data = await _homePageService.SellingProduct(index, quantity);
                return Ok(data);
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
            
        }
        [HttpGet]
        [Route("sanPhamMoi/{index}/{quantity}")]
        public async Task<ActionResult> NewProduct(int index,int quantity)
        {
            try
            {
                var data = await _homePageService.NewProduct(index, quantity);
                return Ok(data);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        [Route("getProductByCategory/{id}/{index}/{quantity}")]
        public async Task<ActionResult> GetProductByCategory(int id,int index, int quantity)
        {
            try
            {
                var data = await _homePageService.GetProductByCategory(id, index, quantity);
                return Ok(data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet]
        [Route("getProductByCompany/{id}/{index}/{quantity}")]
        public async Task<ActionResult> GetProductByCompany(int id, int index, int quantity)
        {
            try
            {
                var data =  await _homePageService.GetProductByCompany(id, index, quantity);
                return Ok(data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
