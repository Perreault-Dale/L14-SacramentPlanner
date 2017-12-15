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
    public class HymnsController : Controller
    {
        private readonly SacramentContext _context;

        public HymnsController(SacramentContext context)
        {
            _context = context;
        }

        // GET: Hymns
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";
            var hymns = from h in _context.Hymns
                        orderby h.location
                        select h;
            switch (sortOrder)
            {
                case "date_desc":
                    hymns = hymns.OrderByDescending(p => p.location);
                    break;
                case "Date":
                    hymns = hymns.OrderBy(p => p.location);
                    break;
                default:
                    hymns = hymns.OrderBy(p => p.location);
                    break;
            }
            return View(await _context.Hymns.ToListAsync());
        }

        // GET: Hymns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hymn = await _context.Hymns
                .SingleOrDefaultAsync(m => m.id == id);
            if (hymn == null)
            {
                return NotFound();
            }

            return View(hymn);
        }

        // GET: Hymns/Create
        public IActionResult Create(int id)
        {
            return View(new Hymn { MeetingProgramID = id });
        }

        // POST: Hymns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingProgramID,hymnNumber,name,location")] Hymn hymn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hymn);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "MeetingPrograms");
            }
            return View(hymn);
        }

        // GET: Hymns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hymn = await _context.Hymns.SingleOrDefaultAsync(m => m.id == id);
            if (hymn == null)
            {
                return NotFound();
            }
            return View(hymn);
        }

        // POST: Hymns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,MeetingProgramID,hymnNumber,name,location")] Hymn hymn)
        {
            if (id != hymn.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hymn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HymnExists(hymn.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "MeetingPrograms");
            }
            return View(hymn);
        }

        // GET: Hymns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hymn = await _context.Hymns
                .SingleOrDefaultAsync(m => m.id == id);
            if (hymn == null)
            {
                return NotFound();
            }

            return View(hymn);
        }

        // POST: Hymns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hymn = await _context.Hymns.SingleOrDefaultAsync(m => m.id == id);
            _context.Hymns.Remove(hymn);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "MeetingPrograms");
        }

        private bool HymnExists(int id)
        {
            return _context.Hymns.Any(e => e.id == id);
        }
    }
}
