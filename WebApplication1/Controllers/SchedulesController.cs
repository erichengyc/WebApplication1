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
    public class SchedulesController : Controller
    {
        private readonly tennisContext _context;

        public SchedulesController(tennisContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public IActionResult Index()
        {

            var MemberIdString = HttpContext.Session.GetString("MemberId");
            var RoleIdString = HttpContext.Session.GetString("RoleId");

            Int32.TryParse(MemberIdString, out int MemberId);
            Int32.TryParse(RoleIdString, out int RoleId);

            //Only admins can view all scheduled events. Admin have a role id of 1

            if (MemberIdString != null && MemberId == 1)
            {
                var allEvents = _context.Event
                    .Include(member => member.Member)
                    .ToList();

                var eVM2 = new EventSchduleViewModel
                {

                    Events = allEvents.ToList()

                };
                return View(eVM2);
            }

            //Coaches and members can see all their events and schedules

            if (MemberIdString != null)
            {
                // Retrieve all the coache's events

                var coachesEvents = _context.Event
                    .Include(member => member.Member)
                    .Where(e => e.MemberId == MemberId)
                    .ToList();

                // Retrieve all the member's event

                var memberSchedule = _context.Schedule
                    .Where(e => e.MemberId == MemberId)
                    .Include(events => events.Event)
                    .Include(events => events.Event.Member)
                    .ToList();

                // Add retrieve data into the viewmodel

                var eVM2 = new EventSchduleViewModel
                {

                    Events = coachesEvents.ToList(),
                    MemberSchedule = memberSchedule.ToList()

                };

                return View(eVM2);
            }



            return RedirectToAction("Login", "Home");
        }

        // GET: Schedules/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MemberId = HttpContext.Session.GetString("MemberId");
            var RoleIdString = HttpContext.Session.GetString("RoleId");

            Int32.TryParse(RoleIdString, out int RoleId);

            // Coaches and members can see details about thier events. Coaches see all members enrolled in their event
            if (MemberId != null && RoleId == 1 || RoleId == 2)
            {
                var schedule = _context.Schedule.FirstOrDefault(s => s.ScheduleId == id);

                // Retrieve the selected event
                var selectedEvent = _context.Event.FirstOrDefault(e => e.EventId == id);

                // Retrieve all members enrolled in selected event
                var membersInEvent = from m in _context.Member
                                     join s in _context.Schedule on m.MemberId equals s.MemberId
                                     join e in _context.Event on s.EventId equals e.EventId
                                     where e.EventId == selectedEvent.EventId
                                     select m;

                // Add retrieve data into the viewmodel
                var eVM2 = new EventSchduleViewModel
                {
                    Members = membersInEvent.ToList()

                };

                if (schedule == null)
                {
                    return View(eVM2);
                }

                return View(eVM2);
            }

            return RedirectToAction("Login", "Home");


        }

        // GET: Schedules/Create
        public IActionResult Create()
        {

            var MemberId = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            //Only admins can view this page. Admin have a role id of 1
            if (MemberId != null && RoleId == "1")
            {
                return View();
            }


            return NotFound();
        }

        // POST: Schedules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MemberId = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            //Only admins can view this page. Admin have a role id of 1

            if (MemberId != null && RoleId == "1")
            {
                var schedule = await _context.Schedule.FindAsync(id);
                if (schedule == null)
                {
                    return NotFound();
                }
                return View(schedule);
            }


            return NotFound();


        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleId")] Schedule schedule)
        {
            if (id != schedule.ScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ScheduleId))
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
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MemberId = HttpContext.Session.GetString("MemberId");
            var RoleId = HttpContext.Session.GetString("RoleId");

            //Only admins can view this page. Admin have a role id of 1

            if (MemberId != null && RoleId == "1")
            {
                var schedule = await _context.Schedule
                    .FirstOrDefaultAsync(m => m.ScheduleId == id);
                if (schedule == null)
                {
                    return NotFound();
                }

                return View(schedule);
            }


            return NotFound();

        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedule.FindAsync(id);
            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedule.Any(e => e.ScheduleId == id);
        }

    }
}
