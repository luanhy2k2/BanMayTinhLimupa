using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
using Data;

namespace core_api.Controllers.client
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private QuanlybanhangContext db = new QuanlybanhangContext();
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;
        
        public UserController(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _appSettings = appSettings.Value;
            _configuration = configuration;
          
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
