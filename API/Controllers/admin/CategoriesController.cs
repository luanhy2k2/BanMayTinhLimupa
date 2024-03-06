using Application.Models;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Repository.Interface.Admin;

namespace core_api.Controllers.admin
{
    [Route("api/loaisp")]
    public class CategoriesController : Controller
    {
        private ILoaispRepository _loaispRepository;
        private QuanlybanhangContext db;
        public CategoriesController(ILoaispRepository loaispRepository, QuanlybanhangContext context)
        {
            _loaispRepository = loaispRepository;
            db = context;
        }
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Manager)]
        [Route("create")]
        [HttpPost]
        public async Task<Loaisp> create([FromBody] Loaisp category)
        {
            try
            {
                var x = await _loaispRepository.Create(category);
                return x;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Manager)]
        [HttpPost]
        [Route("update")]
        public async Task<Loaisp> update([FromBody] Loaisp category)
        {
            try
            {
                var data = await _loaispRepository.Update(category);
                return data;

            }
            catch(Exception ex)
            {
                throw new Exception("err", ex);
            }
        }
        
        [HttpGet]
        [Route("getAll/{pageIndex}/{pageSize}")]
        public async Task<ActionResult> getAll(int pageIndex, int pageSize)
        {
            try
            {
                var data = await _loaispRepository.getAll(pageIndex, pageSize);
                return Ok(data);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
     
        [HttpGet]
        [Route("getById/{id}")]
        public async Task<Loaisp> getById(int id)
        {
            try
            {
                var data = await _loaispRepository.getById(id);
                return data;
            }
            catch(Exception ex)
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
                var data = await db.Loaisp.Where(x => x.LoaiName.Contains(name)).Skip(pageIndex*pageSize).Take(pageSize).ToListAsync();
                return Ok(data);
            }
            catch(Exception ex)
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
                var data = await _loaispRepository.Delete(id);
                if (data == null)
                {
                    return NotFound($"category with id {id} not found");
                }
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
