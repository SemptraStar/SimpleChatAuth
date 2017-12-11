using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using SimpleChat.Models;
using SimpleChat.Data;
using SimpleChat.Models.Chat;

namespace SimpleChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            ViewBag.IsUserAuthorized = user != null ? true : false;
            ViewBag.Messages = _dbContext.Messages;           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Message message)
        {
            var user = await _userManager.GetUserAsync(User);

            message.ApplicationUser = user;
            message.Sign = user.Sign;
            message.When = DateTime.Now;

            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();

            ViewBag.Messages = _dbContext.Messages;
            ViewBag.IsUserAuthorized = user != null ? true : false;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
