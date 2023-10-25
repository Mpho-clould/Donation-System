using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POE_PART1.Data;
using POE_PART1.Models;

namespace POE_PART1.Controllers
{
    public class GoodsDonationsController : Controller
    {
        private readonly POE_PART1Context _context;

        public GoodsDonationsController(POE_PART1Context context)
        {
            _context = context;
        }

        // GET: GoodsDonations
        public async Task<IActionResult> Index()
        {
            var pOE_PART1Context = _context.GoodsDonation.Include(g => g.Category);
            return View(await pOE_PART1Context.ToListAsync());
        }

        // GET: GoodsDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GoodsDonation == null)
            {
                return NotFound();
            }

            var goodsDonation = await _context.GoodsDonation
                .Include(g => g.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsDonation == null)
            {
                return NotFound();
            }

            return View(goodsDonation);
        }

        // GET: GoodsDonations/Create
        public IActionResult Create()
        {
            ViewData["CategoryName"] = new SelectList(_context.Category, "CategoryName", "CategoryName");
            return View();
        }

        // POST: GoodsDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Anonymous,Name,CategoryName,Number_of_Iteams,Description,Date")] GoodsDonation goodsDonation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsDonation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryName"] = new SelectList(_context.Category, "CategoryName", "CategoryName", goodsDonation.CategoryName);
            return View(goodsDonation);
        }

        // GET: GoodsDonations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GoodsDonation == null)
            {
                return NotFound();
            }

            var goodsDonation = await _context.GoodsDonation.FindAsync(id);
            if (goodsDonation == null)
            {
                return NotFound();
            }
            ViewData["CategoryName"] = new SelectList(_context.Category, "CategoryName", "CategoryName", goodsDonation.CategoryName);
            return View(goodsDonation);
        }

        // POST: GoodsDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Anonymous,Name,CategoryName,Number_of_Iteams,Description,Date")] GoodsDonation goodsDonation)
        {
            if (id != goodsDonation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsDonation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsDonationExists(goodsDonation.Id))
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
            ViewData["CategoryName"] = new SelectList(_context.Category, "CategoryName", "CategoryName", goodsDonation.CategoryName);
            return View(goodsDonation);
        }

        // GET: GoodsDonations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GoodsDonation == null)
            {
                return NotFound();
            }

            var goodsDonation = await _context.GoodsDonation
                .Include(g => g.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsDonation == null)
            {
                return NotFound();
            }

            return View(goodsDonation);
        }

        // POST: GoodsDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GoodsDonation == null)
            {
                return Problem("Entity set 'POE_PART1Context.GoodsDonation'  is null.");
            }
            var goodsDonation = await _context.GoodsDonation.FindAsync(id);
            if (goodsDonation != null)
            {
                _context.GoodsDonation.Remove(goodsDonation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsDonationExists(int id)
        {
          return (_context.GoodsDonation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
