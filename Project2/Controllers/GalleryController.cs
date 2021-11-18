using ImageGallery.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using System.Linq;


namespace Project2.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImage _imageService;

        
        public GalleryController(IImage imageService)
        {
            _imageService = imageService;
        }

        //[Authorize]
        public IActionResult Index()
        {
            var imageList = _imageService.GetAll();
            var model = new GalleryIndexModel()
            {                
                Images = imageList,
                SearchQuery = ""
            };
            return View(model);
        }

        
        public IActionResult Detail(int id)
        {
            if (ModelState.IsValid)
            {
                var image = _imageService.GetById(id);

                var model = new GalleryDetailModel()
                {
                    Id = image.Id,
                    Title = image.Title,
                    Geolocation = image.Geolocation,
                    CreatedOn = image.Created,
                    Url = image.Url,
                    Tags = image.Tags.Select(t => t.Description).ToList()

                };

                return View(model);
            }
            return View();
        }
    }
}
