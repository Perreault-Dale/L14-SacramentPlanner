﻿using System;
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
    public class PrayersController : Controller
    {
        private readonly SacramentContext _context;

        public PrayersController(SacramentContext context)
        {
            _context = context;
        }

        // GET: Prayers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prayers.ToListAsync());
        }

        // GET: Prayers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayer = await _context.Prayers
                .SingleOrDefaultAsync(m => m.id == id);
            if (prayer == null)
            {
                return NotFound();
            }

            return View(prayer);
        }

        // GET: Prayers/Create
        public IActionResult Create(int id)
        {
            return View(new Prayer { MeetingProgramID=id});
        }

        // POST: Prayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingProgramID,speaker,location")] Prayer prayer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prayer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prayer);
        }

        // GET: Prayers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayer = await _context.Prayers.SingleOrDefaultAsync(m => m.id == id);
            if (prayer == null)
            {
                return NotFound();
            }
            return View(prayer);
        }

        // POST: Prayers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,MeetingProgramID,speaker,location")] Prayer prayer)
        {
            if (id != prayer.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prayer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrayerExists(prayer.id))
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
            return View(prayer);
        }

        // GET: Prayers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayer = await _context.Prayers
                .SingleOrDefaultAsync(m => m.id == id);
            if (prayer == null)
            {
                return NotFound();
            }

            return View(prayer);
        }

        // POST: Prayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prayer = await _context.Prayers.SingleOrDefaultAsync(m => m.id == id);
            _context.Prayers.Remove(prayer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrayerExists(int id)
        {
            return _context.Prayers.Any(e => e.id == id);
        }
    }
}
