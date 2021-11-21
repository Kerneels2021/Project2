using ImageGallery.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Project2.Models;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Project2.Controllers
{


    public class ImageController : Controller
    {
        
        private IConfiguration _config;
        private string AzureConnectionString { get; }

        private IImage _imageService;
       

        public ImageController(IConfiguration config, IImage imageService  )
        {
            _config = config;
            _imageService = imageService;
            AzureConnectionString = _config["AzureStorageConnectionString"];

        }

       
        // Upload
        public ActionResult Upload()
        {
            var model = new UploadImageModel();
            return View();
        }

        [HttpPost]      
        public async Task<IActionResult> UploadNewImage(IFormFile file, string tags, string title, string geo)
        {
            if (ModelState.IsValid)
            {
                var container = _imageService.GetBlobContainer(AzureConnectionString, "photoimages");
                var content = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                var fileName = content.FileName.Trim('"', ' ');

                //Get a reference to the Block Blob
                var blockBlob = container.GetBlockBlobReference(fileName);
                await blockBlob.UploadFromStreamAsync(file.OpenReadStream());
                await _imageService.SetImage(title,geo, tags, blockBlob.Uri);


                return RedirectToAction("Index", "Gallery");
            }
            return View();
        }

        // GET: ImageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

       

        // GET: ImageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        
    }
}
