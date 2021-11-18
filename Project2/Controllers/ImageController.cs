using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Project2.Models;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ImageGallery.Data;
using Microsoft.AspNetCore.Authorization;

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

        /*// POST: ImageController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // GET: ImageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        /*// POST: ImageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        /* // GET: ImageController
         public ActionResult Index()
         {
             return View();
         }

         // GET: ImageController/Details/5
         public ActionResult Details(int id)
         {
             return View();
         }

         // GET: ImageController/Create
         public ActionResult Create()
         {
             return View();
         }

         // POST: ImageController/Create
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create(IFormCollection collection)
         {
             try
             {
                 return RedirectToAction(nameof(Index));
             }
             catch
             {
                 return View();
             }
         }

         // GET: ImageController/Edit/5
         public ActionResult Edit(int id)
         {
             return View();
         }

         // POST: ImageController/Edit/5
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit(int id, IFormCollection collection)
         {
             try
             {
                 return RedirectToAction(nameof(Index));
             }
             catch
             {
                 return View();
             }
         }

         // GET: ImageController/Delete/5
         public ActionResult Delete(int id)
         {
             return View();
         }

         // POST: ImageController/Delete/5
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Delete(int id, IFormCollection collection)
         {
             try
             {
                 return RedirectToAction(nameof(Index));
             }
             catch
             {
                 return View();
             }
         }*/
    }
}
