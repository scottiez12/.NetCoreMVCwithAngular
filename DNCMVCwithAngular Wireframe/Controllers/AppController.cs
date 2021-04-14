using DNCMVCwithAngular_Wireframe.Data;
using DNCMVCwithAngular_Wireframe.Services;
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
        private readonly IMailService _mailService;
        private readonly DataContext _context;

        public AppController(IMailService mailService, DataContext context)
        {
            _mailService = mailService;
            _context = context;
        }

        public IActionResult Index()
        {
            //throw new InvalidProgramException("Bad things happen to good developers..");
            var results = _context.Products.ToList();
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
                //send the email
                _mailService.SendMessage("scott@ziegler.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            {
                //show the errors
            }

            return View();

        }

        public IActionResult About()
        {
            ViewBag.Title = "About";

            return View();
        }

        public IActionResult Shop()
        {
            var results = _context.Products
                .OrderBy(p => p.Category)
                .ToList();
            return View(results);
        }

    }
}
