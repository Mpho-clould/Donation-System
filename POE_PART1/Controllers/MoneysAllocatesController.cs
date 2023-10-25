using System;
using System.Collections.Generic;
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

    public class MoneysAllocatesController : Controller
    {
        private readonly POE_PART1Context _context;

        public MoneysAllocatesController(POE_PART1Context context)
        {
            _context = context;
        }
        [Authorize(Roles ="Admin")]

        // GET: MoneysAllocates
        public async Task<IActionResult> Index()
        {
            var pOE_PART1Context = _context.MoneysAllocate.Include(m => m.disaster);
            return View(await pOE_PART1Context.ToListAsync());
        }

        // GET: MoneysAllocates/Details/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MoneysAllocate == null)
            {
                return NotFound();
            }

            var moneysAllocate = await _context.MoneysAllocate
                .Include(m => m.disaster)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moneysAllocate == null)
            {
                return NotFound();
            }

            return View(moneysAllocate);
        }

        // GET: MoneysAllocates/Create
        public IActionResult Create()
        {
            ViewData["Distaster_Name"] = new SelectList(_context.activeDisaster, "Distaster_Name", "Distaster_Name");
            return View();
        }

        // POST: MoneysAllocates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Distaster_Name,Amount")] MoneysAllocate moneysAllocate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moneysAllocate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Distaster_Name"] = new SelectList(_context.activeDisaster, "Distaster_Name", "Distaster_Name", moneysAllocate.Distaster_Name);
            return View(moneysAllocate);
        }

        // GET: MoneysAllocates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MoneysAllocate == null)
            {
                return NotFound();
            }

            var moneysAllocate = await _context.MoneysAllocate.FindAsync(id);
            if (moneysAllocate == null)
            {
                return NotFound();
            }
            ViewData["Distaster_Name"] = new SelectList(_context.activeDisaster, "Distaster_Name", "Distaster_Name", moneysAllocate.Distaster_Name);
            return View(moneysAllocate);
        }

        // POST: MoneysAllocates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Distaster_Name,Amount")] MoneysAllocate moneysAllocate)
        {
            if (id != moneysAllocate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moneysAllocate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoneysAllocateExists(moneysAllocate.Id))
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
            ViewData["Distaster_Name"] = new SelectList(_context.activeDisaster, "Distaster_Name", "Distaster_Name", moneysAllocate.Distaster_Name);
            return View(moneysAllocate);
        }

        // GET: MoneysAllocates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MoneysAllocate == null)
            {
                return NotFound();
            }

            var moneysAllocate = await _context.MoneysAllocate
                .Include(m => m.disaster)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moneysAllocate == null)
            {
                return NotFound();
            }

            return View(moneysAllocate);
        }

        // POST: MoneysAllocates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MoneysAllocate == null)
            {
                return Problem("Entity set 'POE_PART1Context.MoneysAllocate'  is null.");
            }
            var moneysAllocate = await _context.MoneysAllocate.FindAsync(id);
            if (moneysAllocate != null)
            {
                _context.MoneysAllocate.Remove(moneysAllocate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoneysAllocateExists(int id)
        {
          return (_context.MoneysAllocate?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
