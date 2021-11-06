using Microsoft.AspNetCore.Mvc;
using Project2.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    public class PhotoImageController : Controller
    {
        public IActionResult Index()
        {
            var PhotoList = new List<Photo>()
            {
                new Photo()
                {
                    PhotoName = "Hiking",
                    PhotoUrl = "https://www.pexels.com/photo/landscape-nature-summer-countryside-6400680/"
                }

            };

            var model = new Models.PhotoIndexModel()
            {
                Images = PhotoList,
                SearhForImage = ""
            };
            return View(model);
        }
    }
}
