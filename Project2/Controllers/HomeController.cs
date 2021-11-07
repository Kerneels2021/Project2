using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Project2.Data;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _config1;
        private IConfiguration _config2;
        private string CONNECTION { get; }
        private string AZURECONNECTION { get; }
        private readonly ILogger<HomeController> _logger;

       

        public HomeController(ILogger<HomeController> logger,Database_Resource db, IConfiguration config1, IConfiguration config2)
        {
            _logger = logger;
            _config1 = config1;
            CONNECTION = _config1["DataBaseConnectionString"];
            AZURECONNECTION = config2["StorageConnectionString"];
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

      /*  [HttpPost]
        public IActionResult UploadImage()
        {
            var container = _imageService.GetBlobContainer(AZURECONNECTION, "photoimages");
            return View();
        }
      */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
