using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartDrivingMVC.Models;
using SmartDrivingMVCDAL.Data;
using Activity = System.Diagnostics.Activity;

namespace SmartDrivingMVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private SmartDrivingContext smartDrivingContext;

        public HomeController(SmartDrivingContext smartDrivingContext)
        {
            this.smartDrivingContext = smartDrivingContext;
        }
        public IActionResult Index()
        {
            //ViewData["Message"] = smartDrivingContext.Customer.ToListAsync().Result[0].FirstName;

            return View();
        }

        public IActionResult Booking()
        {

            return View("Index");
        }

        public IActionResult Customer()
        {
            return View("Index");
        }

        public IActionResult About()
        {
           
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
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
