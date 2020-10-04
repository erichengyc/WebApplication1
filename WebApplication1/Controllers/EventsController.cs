using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class EventsController : Controller
    {

        private readonly tennisContext _context;

        public EventsController(tennisContext context)
        {
            _context = context;

        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var MemberId = HttpContext.Session.GetString("MemberId");

            if (MemberId != null)
            {
                return View(await _context.Event.ToListAsync());
            }

            return RedirectToAction("Login", "Home");
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var MemberId = HttpContext.Session.GetString("MemberId");

            if (id == null)
            {
                return NotFound();
            }

            if (MemberId != null)
            {

                var @event = await _context.Event
                    .FirstOrDefaultAsync(m => m.EventId == id);
                if (@event == null)
                {
                    return NotFound();
                }
                return View(@event);
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, Schedule schedule)
        {
            var events = _context.Event;
            var @event = events.FirstOrDefault(e => e.EventId == id);

            if (ModelState.IsValid)
            {

                var members = _context.Member;
                var schedules = _context.Schedule;

                var MemberIdString = HttpContext.Session.GetString("MemberId");

                Int32.TryParse(MemberIdString, out int MemberId);



                var existingEnroll = await _context.Schedule.SingleOrDefaultAsync(s => s.Member.MemberId == MemberId && s.Event.EventId == id);

                if (existingEnroll != null)
                {
                    ModelState.AddModelError("", "You have already enrolled in this event.");
                }
                else
                {
                    var member = members.FirstOrDefault(m => m.MemberId == MemberId);

                    var eventSchedule = new Schedule()
                    {
                        Member = member,
                        Event = @event

                    };

                    _context.Schedule.Add(eventSchedule);

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Events");
                }


            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            var MemberId = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            if (MemberId != null && RoleId == "1")
            {
                return View();
            }
            return NotFound();

        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,Name,Description,MemberId,Date")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var MemberId = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            if (MemberId != null && RoleId == "1")
            {

                var @event = await _context.Event.FindAsync(id);
                if (@event == null)
                {
                    return NotFound();
                }
                return View(@event);
            }
            return NotFound();

        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Name,Description,MemberId,Date")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
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
            return View(@event);
        }

        // GET: Events/Delete/5
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
                var @event = await _context.Event.FirstOrDefaultAsync(m => m.EventId == id);

                if (@event == null)
                {
                    return NotFound();
                }

                return View(@event);
            }
            return NotFound();
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }
    }
}
