using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POE_PART1.Data;
using POE_PART1.Models;

namespace POE_PART1.Controllers
{
    [Authorize(Roles = "Admin,Donar")]

    public class activeDisastersController : Controller
    {
        private readonly POE_PART1Context _context;

        public activeDisastersController(POE_PART1Context context)
        {
            _context = context;
        }

        // GET: activeDisasters
        public async Task<IActionResult> Index()
        {
              return _context.activeDisaster != null ? 
                          View(await _context.activeDisaster.ToListAsync()) :
                          Problem("Entity set 'POE_PART1Context.activeDisaster'  is null.");
        }

        // GET: activeDisasters/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.activeDisaster == null)
            {
                return NotFound();
            }

            var activeDisaster = await _context.activeDisaster
                .FirstOrDefaultAsync(m => m.Distaster_Name == id);
            if (activeDisaster == null)
            {
                return NotFound();
            }

            return View(activeDisaster);
        }

        // GET: activeDisasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: activeDisasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Distaster_Name,Start_Date,End_Date,Location,Aid_Types")] activeDisaster activeDisaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activeDisaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activeDisaster);
        }

        // GET: activeDisasters/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.activeDisaster == null)
            {
                return NotFound();
            }

            var activeDisaster = await _context.activeDisaster.FindAsync(id);
            if (activeDisaster == null)
            {
                return NotFound();
            }
            return View(activeDisaster);
        }

        // POST: activeDisasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Distaster_Name,Start_Date,End_Date,Location,Aid_Types")] activeDisaster activeDisaster)
        {
            if (id != activeDisaster.Distaster_Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activeDisaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!activeDisasterExists(activeDisaster.Distaster_Name))
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
            return View(activeDisaster);
        }

        // GET: activeDisasters/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.activeDisaster == null)
            {
                return NotFound();
            }

            var activeDisaster = await _context.activeDisaster
                .FirstOrDefaultAsync(m => m.Distaster_Name == id);
            if (activeDisaster == null)
            {
                return NotFound();
            }

            return View(activeDisaster);
        }

        // POST: activeDisasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.activeDisaster == null)
            {
                return Problem("Entity set 'POE_PART1Context.activeDisaster'  is null.");
            }
            var activeDisaster = await _context.activeDisaster.FindAsync(id);
            if (activeDisaster != null)
            {
                _context.activeDisaster.Remove(activeDisaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool activeDisasterExists(string id)
        {
          return (_context.activeDisaster?.Any(e => e.Distaster_Name == id)).GetValueOrDefault();
        }
    }
}
