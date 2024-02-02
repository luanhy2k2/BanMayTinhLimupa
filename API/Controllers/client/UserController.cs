using core_api.tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Model.Models;
using core_api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

namespace core_api.Controllers.client
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private QuanlybanhangContext db = new QuanlybanhangContext();
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;
        private ITools _tools;
        public UserController(IOptions<AppSettings> appSettings, ITools tools, IConfiguration configuration)
        {
            _appSettings = appSettings.Value;
            _configuration = configuration;
            _tools = tools;
        }
        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string fileName = $"{file.FileName}";
                    string filePath = $"product/{fileName.Replace("-", "_").Replace("%", "")}";
                    var fullPath = _tools.CreatePathFile(filePath);

                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    return Ok(new { fileName });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Không thể upload tệp");
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] TaiKhoan model)
        {
            var Taikhoan = model.TaiKhoan1;
            var Matkhau = model.MatKhau;
            var query = from n in db.NguoiDung
                        join t in db.TaiKhoan on n.MaNguoiDung equals t.MaNguoiDung
                        select new
                        {
                            MaNguoiDung = n.MaNguoiDung,
                            HoTen = n.HoTen,
                           
                            Sdt = n.Sdt,
                            TaiKhoan = t.TaiKhoan1,
                            LoaiQuyen = t.LoaiQuyen,
                            MatKhau = t.MatKhau
                        };

            var user = query.SingleOrDefault(x => x.TaiKhoan == Taikhoan && x.MatKhau == Matkhau);
            // return null if user not found
            if (user == null)
                return Ok(new { message = "Tài khoản hoặc mật khẩu không đúng" });
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.HoTen.ToString()),
                    new Claim(ClaimTypes.Role, user.LoaiQuyen),
                    new Claim(ClaimTypes.DenyOnlyWindowsDeviceGroup, user.MatKhau)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tmp = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tmp);

            return Ok(new { MaNguoiDung = user.MaNguoiDung, Sdt = user.Sdt, loaiQuyen = user.LoaiQuyen, HoTen = user.HoTen, Token = token });
        }


        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
           
            if (file == null || file.Length == 0)
                return BadRequest("File not selected.");
            string fileName = $"{file.FileName}";
            var connectionString = _configuration.GetConnectionString("AzureBlobStorage");
            var containerName = "fileupload";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            if (await container.CreateIfNotExistsAsync())
            {
                await container.SetPermissionsAsync(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            }

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.FileName);
            using (var stream = file.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(stream);
            }

            return Ok(new { fileName });
        }

    }
}
