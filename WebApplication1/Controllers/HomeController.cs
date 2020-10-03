using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private tennisContext _context;

        public HomeController(tennisContext context)
        {
            _context = context;

        }


        public IActionResult Index()
        {
            return View(_context.Member.ToList());
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(Member user)
        {
            if (ModelState.IsValid)
            {
                _context.Member.Add(user);
                _context.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = user.Email + " has successfully registered.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Member user)
        {
            var account = _context.Member.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("MemberId", account.MemberId.ToString());
                HttpContext.Session.SetString("Email", account.Email);
                return RedirectToAction("Welcome");
            }
            else
            {
                ModelState.AddModelError("", "Email or password is incorrect.");
            }

            return View();
        }

        public ActionResult Welcome()
        {
            if (HttpContext.Session.GetString("MemberId") != null)
            {
                ViewBag.Email = HttpContext.Session.GetString("Email");
                ViewBag.MemberId = HttpContext.Session.GetString("MemberId");

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


    }
}
