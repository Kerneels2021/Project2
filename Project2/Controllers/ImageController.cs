using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            var model = new PhotoIndexModel()
            {

            };
            return View(model);
        }
    }
}
