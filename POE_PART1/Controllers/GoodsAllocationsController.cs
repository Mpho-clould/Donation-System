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
    public class GoodsAllocationsController : Controller
    {
        private readonly POE_PART1Context _context;

        public GoodsAllocationsController(POE_PART1Context context)
        {
            _context = context;
        }

        // GET: GoodsAllocations
        public async Task<IActionResult> Index()
        {
            var pOE_PART1Context = _context.GoodsAllocation.Include(g => g.Category).Include(g => g.disaster);
            return View(await pOE_PART1Context.ToListAsync());
        }

        // GET: GoodsAllocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GoodsAllocation == null)
            {
                return NotFound();
            }

            var goodsAllocation = await _context.GoodsAllocation
                .Include(g => g.Category)
                .Include(g => g.disaster)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsAllocation == null)
            {
                return NotFound();
            }

            return View(goodsAllocation);
        }

        // GET: GoodsAllocations/Create
        public IActionResult Create()
        {
            ViewData["CategoryName"] = new SelectList(_context.Category, "CategoryName", "CategoryName");
            ViewData["Distaster_Name"] = new SelectList(_context.activeDisaster, "Distaster_Name", "Distaster_Name");
            return View();
        }

        // POST: GoodsAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Distaster_Name,CategoryName,Number_of_Iteams")] GoodsAllocation goodsAllocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsAllocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryName"] = new SelectList(_context.Category, "CategoryName", "CategoryName", goodsAllocation.CategoryName);
            ViewData["Distaster_Name"] = new SelectList(_context.activeDisaster, "Distaster_Name", "Distaster_Name", goodsAllocation.Distaster_Name);
            return View(goodsAllocation);
        }

        // GET: GoodsAllocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GoodsAllocation == null)
            {
                return NotFound();
            }

            var goodsAllocation = await _context.GoodsAllocation.FindAsync(id);
            if (goodsAllocation == null)
            {
                return NotFound();
            }
            ViewData["CategoryName"] = new SelectList(_context.Category, "CategoryName", "CategoryName", goodsAllocation.CategoryName);
            ViewData["Distaster_Name"] = new SelectList(_context.activeDisaster, "Distaster_Name", "Distaster_Name", goodsAllocation.Distaster_Name);
            return View(goodsAllocation);
        }

        // POST: GoodsAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Distaster_Name,CategoryName,Number_of_Iteams")] GoodsAllocation goodsAllocation)
        {
            if (id != goodsAllocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsAllocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsAllocationExists(goodsAllocation.Id))
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
            ViewData["CategoryName"] = new SelectList(_context.Category, "CategoryName", "CategoryName", goodsAllocation.CategoryName);
            ViewData["Distaster_Name"] = new SelectList(_context.activeDisaster, "Distaster_Name", "Distaster_Name", goodsAllocation.Distaster_Name);
            return View(goodsAllocation);
        }

        // GET: GoodsAllocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GoodsAllocation == null)
            {
                return NotFound();
            }

            var goodsAllocation = await _context.GoodsAllocation
                .Include(g => g.Category)
                .Include(g => g.disaster)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsAllocation == null)
            {
                return NotFound();
            }

            return View(goodsAllocation);
        }

        // POST: GoodsAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GoodsAllocation == null)
            {
                return Problem("Entity set 'POE_PART1Context.GoodsAllocation'  is null.");
            }
            var goodsAllocation = await _context.GoodsAllocation.FindAsync(id);
            if (goodsAllocation != null)
            {
                _context.GoodsAllocation.Remove(goodsAllocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsAllocationExists(int id)
        {
          return (_context.GoodsAllocation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
