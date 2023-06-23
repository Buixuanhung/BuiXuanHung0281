using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuiXuanHung0281.Models;

namespace BuiXuanHung0281.Controllers
{
    public class BXHstudentController : Controller
    {
        private readonly LTQLDb _context;

        public BXHstudentController(LTQLDb context)
        {
            _context = context;
        }

        // GET: BXHstudent
        public async Task<IActionResult> Index()
        {
              return _context.BXHstudent != null ? 
                          View(await _context.BXHstudent.ToListAsync()) :
                          Problem("Entity set 'LTQLDb.BXHstudent'  is null.");
        }

        // GET: BXHstudent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BXHstudent == null)
            {
                return NotFound();
            }

            var bXHstudent = await _context.BXHstudent
                .FirstOrDefaultAsync(m => m.BXHstudentID == id);
            if (bXHstudent == null)
            {
                return NotFound();
            }

            return View(bXHstudent);
        }

        // GET: BXHstudent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BXHstudent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BXHstudentID,BXHstudentName,BXHstudentSex")] BXHstudent bXHstudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bXHstudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bXHstudent);
        }

        // GET: BXHstudent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BXHstudent == null)
            {
                return NotFound();
            }

            var bXHstudent = await _context.BXHstudent.FindAsync(id);
            if (bXHstudent == null)
            {
                return NotFound();
            }
            return View(bXHstudent);
        }

        // POST: BXHstudent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BXHstudentID,BXHstudentName,BXHstudentSex")] BXHstudent bXHstudent)
        {
            if (id != bXHstudent.BXHstudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bXHstudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BXHstudentExists(bXHstudent.BXHstudentID))
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
            return View(bXHstudent);
        }

        // GET: BXHstudent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BXHstudent == null)
            {
                return NotFound();
            }

            var bXHstudent = await _context.BXHstudent
                .FirstOrDefaultAsync(m => m.BXHstudentID == id);
            if (bXHstudent == null)
            {
                return NotFound();
            }

            return View(bXHstudent);
        }

        // POST: BXHstudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BXHstudent == null)
            {
                return Problem("Entity set 'LTQLDb.BXHstudent'  is null.");
            }
            var bXHstudent = await _context.BXHstudent.FindAsync(id);
            if (bXHstudent != null)
            {
                _context.BXHstudent.Remove(bXHstudent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BXHstudentExists(int id)
        {
          return (_context.BXHstudent?.Any(e => e.BXHstudentID == id)).GetValueOrDefault();
        }
    }
}
