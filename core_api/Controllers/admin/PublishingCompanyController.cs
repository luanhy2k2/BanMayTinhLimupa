//using Microsoft.AspNetCore.Mvc;
//using Model.Models;
//namespace core_api.Controllers.admin
//{
//    [Route("api/publishingCompany")]
//    public class PublishingCompanyController : Controller
//    {
//        private QuanlybanhangContext db = new QuanlybanhangContext();
//        [Route("create")]
//        [HttpPost]
//        public IActionResult create(Nhasx company)
//        {
//            try
//            {
//                var x = db.Nhasxes.Add(company);
//                db.SaveChanges();
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//        [HttpPost]
//        [Route("update")]
//        public IActionResult update(Nhasx company)
//        {
//            try
//            {
//                var data = db.Nhasxes.FirstOrDefault(x => x.NsxId == company.NsxId);
//                if (data == null)
//                {
//                    return NotFound($"category with id {company.NsxId} not found");
//                }
//                data.NsxName = company.NsxName;
//                data.Sdt = company.Sdt;
//                data.Diachi = company.Diachi;
//                db.SaveChanges();
//                return Ok(data);

//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//        [HttpGet]
//        [Route("getAll/{pageIndex}/{pageSize}")]
//        public List<Nhasx> getAll(int pageIndex, int pageSize)
//        {
//            try
//            {
//                var data = db.Nhasxes.Skip(pageIndex * pageSize).Take(pageSize).ToList();
//                return data;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//        [HttpGet]
//        [Route("getById/{id}")]
//        public Nhasx getById(int id)
//        {
//            try
//            {
//                var data = db.Nhasxes.FirstOrDefault(x => x.NsxId == id);
//                return data;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//        [HttpGet]
//        [Route("search/{name}/{pageIndex}/{pageSize}")]
//        public List<Nhasx> search(string name, int pageIndex, int pageSize)
//        {
//            try
//            {
//                var data = db.Nhasxes.Where(x => x.NsxName.Contains(name)).Skip(pageIndex * pageSize).Take(pageSize).ToList();
//                return data;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//    }
//}
