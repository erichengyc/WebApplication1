﻿using System;
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
    public class MembersController : Controller
    {
        private readonly tennisContext _context;

        public MembersController(tennisContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {

            var MemberIdString = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            Int32.TryParse(MemberIdString, out int MemberId);

            if (MemberIdString != null && RoleId == "1")
            {
                return View(await _context.Member.Include(roles => roles.Role).ToListAsync());
            }

            return RedirectToAction("Login", "Home");

        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MemberIdString = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            Int32.TryParse(MemberIdString, out int MemberId);

            if (MemberIdString != null && RoleId == "1")
            {
                var member = await _context.Member.FirstOrDefaultAsync(m => m.MemberId == id);
                if (member == null)
                {
                    return NotFound();
                }

                return View(member);
            }
            else if (MemberIdString != null && RoleId == "2" || RoleId == "3")
            {
                var member = await _context.Member.FirstOrDefaultAsync(m => m.MemberId == MemberId);
                if (member == null)
                {
                    return NotFound();
                }

                return View(member);
            }

            return RedirectToAction("Login", "Home");


        }

        // GET: Members/Create
        public IActionResult Create()
        {

            var MemberId = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            if (MemberId != null && RoleId == "1")
            {
                return View();
            }


            return RedirectToAction("Login", "Home");
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberId,Name,Nickname,Email,Password,Dob,Gender,Biography,RoleId")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MemberIdString = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            Int32.TryParse(MemberIdString, out int MemberId);

            if (MemberIdString != null && RoleId == "1")
            {
                var member = await _context.Member.FindAsync(id);
                if (member == null)
                {
                    return NotFound();
                }
                return View(member);
            }

            else if (MemberIdString != null && RoleId == "2")
            {
                var member = await _context.Member.FindAsync(MemberId);
                if (member == null)
                {
                    return NotFound();
                }
                return View(member);
            }

            return RedirectToAction("Login", "Home");

        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,Name,Nickname,Email,Password,Dob,Gender,Biography,RoleId")] Member member)
        {
            if (id != member.MemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.MemberId))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MemberId = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            if (MemberId != null && RoleId == "1")
            {
                var member = await _context.Member
                    .FirstOrDefaultAsync(m => m.MemberId == id);
                if (member == null)
                {
                    return NotFound();
                }

                return View(member);
            }
            return RedirectToAction("Login", "Home");
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Member.FindAsync(id);
            _context.Member.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.MemberId == id);
        }
    }
}
