using DNCMVCwithAngular_Wireframe.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNCMVCwithAngular_Wireframe.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            //throw new InvalidProgramException("Bad things happen to good developers..");
            return View();
        }



        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        //same url pattern doesnt matter, it's the http method that the browser will look for
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            {

            }

            return View();

        }

        public IActionResult About()
        {
            ViewBag.Title = "About";

            return View();
        }

    }
}
