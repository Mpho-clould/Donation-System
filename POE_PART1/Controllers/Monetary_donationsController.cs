using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POE_PART1.Data;
using POE_PART1.Models;
using POE_PART1.Purchase_calculations;

namespace POE_PART1.Controllers
{
    public class Monetary_donationsController : Controller
    {
        private readonly POE_PART1Context _context;

        private readonly Calculate_purchase _Calculations;

        public Monetary_donationsController(POE_PART1Context context, Calculate_purchase Calculations)
        {
            _context = context;
            _Calculations = Calculations;
        }

        // GET: Monetary_donations
        public async Task<IActionResult> Index()
        {
            var totalAmount = await _Calculations.GetTotalAmount();
            ViewBag.TotalAmount = totalAmount;
              return _context.Monetary_donations != null ? 
                          View(await _context.Monetary_donations.ToListAsync()) :
                          Problem("Entity set 'POE_PART1Context.Monetary_donations'  is null.");
        }

        // GET: Monetary_donations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Monetary_donations == null)
            {
                return NotFound();
            }

            var monetary_donations = await _context.Monetary_donations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monetary_donations == null)
            {
                return NotFound();
            }

            return View(monetary_donations);
        }

        // GET: Monetary_donations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monetary_donations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Anonymous,Name,Amount,Date")] Monetary_donations monetary_donations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monetary_donations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monetary_donations);
        }

        // GET: Monetary_donations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Monetary_donations == null)
            {
                return NotFound();
            }

            var monetary_donations = await _context.Monetary_donations.FindAsync(id);
            if (monetary_donations == null)
            {
                return NotFound();
            }
            return View(monetary_donations);
        }

        // POST: Monetary_donations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Anonymous,Name,Amount,Date")] Monetary_donations monetary_donations)
        {
            if (id != monetary_donations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monetary_donations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Monetary_donationsExists(monetary_donations.Id))
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
            return View(monetary_donations);
        }

        // GET: Monetary_donations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Monetary_donations == null)
            {
                return NotFound();
            }

            var monetary_donations = await _context.Monetary_donations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monetary_donations == null)
            {
                return NotFound();
            }

            return View(monetary_donations);
        }

        // POST: Monetary_donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Monetary_donations == null)
            {
                return Problem("Entity set 'POE_PART1Context.Monetary_donations'  is null.");
            }
            var monetary_donations = await _context.Monetary_donations.FindAsync(id);
            if (monetary_donations != null)
            {
                _context.Monetary_donations.Remove(monetary_donations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Monetary_donationsExists(int id)
        {
          return (_context.Monetary_donations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
