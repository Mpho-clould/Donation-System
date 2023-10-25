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
    public class disastersController : Controller
    {
        private readonly POE_PART1Context _context;

        public disastersController(POE_PART1Context context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin,Donar")]


        // GET: disasters
        public async Task<IActionResult> Index()
        {
              return _context.disaster != null ? 
                          View(await _context.disaster.ToListAsync()) :
                          Problem("Entity set 'POE_PART1Context.disaster'  is null.");
        }

        // GET: disasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.disaster == null)
            {
                return NotFound();
            }

            var disaster = await _context.disaster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disaster == null)
            {
                return NotFound();
            }

            return View(disaster);
        }

        // GET: disasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: disasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Anonymous,Start_Date,End_Date,Location,Distaster_Name,Aid_Types")] disaster disaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disaster);
        }

        // GET: disasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.disaster == null)
            {
                return NotFound();
            }

            var disaster = await _context.disaster.FindAsync(id);
            if (disaster == null)
            {
                return NotFound();
            }
            return View(disaster);
        }

        // POST: disasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Anonymous,Start_Date,End_Date,Location,Distaster_Name,Aid_Types")] disaster disaster)
        {
            if (id != disaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!disasterExists(disaster.Id))
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
            return View(disaster);
        }

        // GET: disasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.disaster == null)
            {
                return NotFound();
            }

            var disaster = await _context.disaster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disaster == null)
            {
                return NotFound();
            }

            return View(disaster);
        }

        // POST: disasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.disaster == null)
            {
                return Problem("Entity set 'POE_PART1Context.disaster'  is null.");
            }
            var disaster = await _context.disaster.FindAsync(id);
            if (disaster != null)
            {
                _context.disaster.Remove(disaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool disasterExists(int id)
        {
          return (_context.disaster?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
