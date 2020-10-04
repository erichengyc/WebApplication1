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

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int id)
        {

            if (id == 404)
            {
                return View("StatusCode404");
            }


            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: Home/Register

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(Member user)
        {
            var MemberId = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            // Checks if user is not registered

            if (MemberId == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Member.Add(user);
                    _context.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Message = user.Email + " has successfully registered.";
                }
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Home/Login

        public ActionResult Login()
        {
            var MemberId = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            // Checks if user is not logged in

            if (MemberId == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");

        }

        // POST: Home/Login

        [HttpPost]
        public ActionResult Login(Member user)
        {
            // Checks if user have entered the correct email and password

            var account = _context.Member.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("MemberId", account.MemberId.ToString());
                HttpContext.Session.SetString("Name", account.Name.ToString());
                HttpContext.Session.SetString("Email", account.Email);
                HttpContext.Session.SetString("RoleId", account.RoleId.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Email or password is incorrect.");
            }

            return View();
        }

        // GET: Home/Welcome

        public ActionResult Welcome()
        {
            if (HttpContext.Session.GetString("MemberId") != null)
            {
                ViewBag.Email = HttpContext.Session.GetString("Email");
                ViewBag.MemberId = HttpContext.Session.GetString("MemberId");
                ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            //Logout clears the session
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


    }
}
