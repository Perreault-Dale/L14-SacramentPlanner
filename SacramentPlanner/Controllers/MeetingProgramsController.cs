using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Data;
using SacramentPlanner.Models;

namespace SacramentPlanner.Controllers
{
    public class MeetingProgramsController : Controller
    {
        private readonly SacramentContext _context;

        public MeetingProgramsController(SacramentContext context)
        {
            _context = context;
        }

        // GET: MeetingPrograms
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";
            var programs = from p in _context.Programs
                           select p;
            switch (sortOrder)
            {
                case "date_desc":
                    programs = programs.OrderByDescending(p => p.programDate);
                    break;
                case "Date":
                    programs = programs.OrderBy(p => p.programDate);
                    break;
                default:
                    programs = programs.OrderByDescending(p => p.programDate);
                    break;
            }
            return View(await _context.Programs.ToListAsync());
        }

        // GET: MeetingPrograms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingProgram = await _context.Programs
                .Include(m => m.Prayers)
                .Include(m => m.Talks)
                .Include(m => m.Hymns)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.id == id);
            if (meetingProgram == null)
            {
                return NotFound();
            }

            return View(meetingProgram);
        }

        // GET: MeetingPrograms/Print/5
        public async Task<IActionResult> Print(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingProgram = await _context.Programs
                .Include(m => m.Prayers)
                .Include(m => m.Talks)
                .Include(m => m.Hymns)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.id == id);
            if (meetingProgram == null)
            {
                return NotFound();
            }

            return View(meetingProgram);
        }

        // GET: MeetingPrograms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeetingPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,programDate,Conduct,Preside,Sacrament")] MeetingProgram meetingProgram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetingProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meetingProgram);
        }

        // GET: MeetingPrograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingProgram = await _context.Programs.SingleOrDefaultAsync(m => m.id == id);
            if (meetingProgram == null)
            {
                return NotFound();
            }
            return View(meetingProgram);
        }

        // POST: MeetingPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,programDate,Conduct,Preside,Sacrament")] MeetingProgram meetingProgram)
        {
            if (id != meetingProgram.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetingProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingProgramExists(meetingProgram.id))
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
            return View(meetingProgram);
        }

        // GET: MeetingPrograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingProgram = await _context.Programs
                .SingleOrDefaultAsync(m => m.id == id);
            if (meetingProgram == null)
            {
                return NotFound();
            }

            return View(meetingProgram);
        }

        // POST: MeetingPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetingProgram = await _context.Programs.SingleOrDefaultAsync(m => m.id == id);
            _context.Programs.Remove(meetingProgram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingProgramExists(int id)
        {
            return _context.Programs.Any(e => e.id == id);
        }
    }
}
