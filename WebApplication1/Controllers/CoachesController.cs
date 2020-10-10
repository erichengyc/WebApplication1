using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Controllers
{
    public class CoachesController : Controller
    {
        private readonly tennisContext _context;

        public CoachesController(tennisContext context)
        {
            _context = context;
        }

        // GET: All Coaches. Coaches a members with a role id of 2
        public async Task<IActionResult> Index()
        {
            var MemberId = HttpContext.Session.GetString("MemberId");

            if (MemberId != null)
            {
                return View(await _context.Member.Include(roles => roles.Role).Where(c => c.RoleId == 2).ToListAsync());
            }

            return RedirectToAction("Login", "Home");

        }

        // GET: Coaches/Details/5 
        public async Task<IActionResult> Details(int? id)
        {
            var MemberId = HttpContext.Session.GetString("MemberId");

            if (id == null)
            {
                return NotFound();
            }

            if (MemberId != null)
            {
                var coach = await _context.Member.FirstOrDefaultAsync(m => m.MemberId == id);

                if (coach == null)
                {
                    return NotFound();
                }

                return View(coach);
            }

            return RedirectToAction("Login", "Home");

        }

        // GET: Coaches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var MemberId = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            if (id == null)
            {
                return NotFound();
            }

            //Only admins can view this page. Admins have a role id of 1
            if (MemberId != null && RoleId == "1")
            {
                var coach = await _context.Member.FindAsync(id);
                if (coach == null)
                {
                    return NotFound();
                }
                return View(coach);
            }

            return RedirectToAction("Login", "Home");
        }

        // POST: Coaches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,Name,Nickname,Email,Password,Dob,Gender,Biography,RoleId")] Member coach)
        {
            if (id != coach.MemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachExists(coach.MemberId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(coach);
        }

        // GET: Coaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            var MemberId = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            if (id == null)
            {
                return NotFound();
            }

            //Only admins can view this page. Admins have a role id of 1
            if (MemberId != null && RoleId == "1")
            {

                var coach = await _context.Member
                    .FirstOrDefaultAsync(m => m.MemberId == id);
                if (coach == null)
                {
                    return NotFound();
                }

                return View(coach);
            }

            return NotFound();
        }

        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coach = await _context.Member.FindAsync(id);
            _context.Member.Remove(coach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoachExists(int id)
        {
            return _context.Member.Any(e => e.MemberId == id);
        }
    }
}
