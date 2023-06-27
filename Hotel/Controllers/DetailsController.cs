using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.Controllers
{
    public class DetailsController : Controller
    {
        private readonly ILogger<DetailsController> _logger;

        public DetailsController(ILogger<DetailsController> logger)
        {
            _logger = logger;
        }




        public IActionResult PropDetails() 
        {
            return View();
        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
