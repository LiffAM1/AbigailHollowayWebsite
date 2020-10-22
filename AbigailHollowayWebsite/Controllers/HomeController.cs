using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AbigailHollowayWebsite.Models;

namespace AbigailHollowayWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger,IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Blog")]
        public IActionResult Blog()
        {
            return View("Blog");
        }

        [Route("About")]
        public IActionResult About()
        {
            return View("About");
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("SubmitContactForm")]
        public IActionResult SubmitContactForm(ContactFormModel model)
        {
            if (!ModelState.IsValid)
                return View("Contact",model);
            else {
                var result = _emailService.Send(model);
                if (result)
                    TempData["Message"] ="Your contact request was submitted successfully!";
                else
                    TempData["Message"] = "There was an error with your contact request. Please email me directly at abigailliff@gmail.com. Thanks!";
                ModelState.Clear();
                return RedirectToAction("Contact");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
