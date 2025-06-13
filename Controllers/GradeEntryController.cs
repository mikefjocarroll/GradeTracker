using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gradeTracker.Data;
using gradeTracker.Models;

namespace gradeTracker.Controllers
{
    public class GradeEntryController : Controller
    {
        private readonly GradeEntryContext _context;

        public GradeEntryController(GradeEntryContext context)
        {
            _context = context;
        }

        // GET: GradeEntry
        public async Task<IActionResult> Index()
        {
            return View(await _context.GradeEntries.ToListAsync());
        }

        // GET: GradeEntry/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradeEntry = await _context.GradeEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gradeEntry == null)
            {
                return NotFound();
            }

            return View(gradeEntry);
        }

        // GET: GradeEntry/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GradeEntry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentName,AssignmentName,Score,TotalPossible")] GradeEntry gradeEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gradeEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gradeEntry);
        }

        // GET: GradeEntry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradeEntry = await _context.GradeEntries.FindAsync(id);
            if (gradeEntry == null)
            {
                return NotFound();
            }
            return View(gradeEntry);
        }

        // POST: GradeEntry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentName,AssignmentName,Score,TotalPossible")] GradeEntry gradeEntry)
        {
            if (id != gradeEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gradeEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradeEntryExists(gradeEntry.Id))
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
            return View(gradeEntry);
        }

        // GET: GradeEntry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradeEntry = await _context.GradeEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gradeEntry == null)
            {
                return NotFound();
            }

            return View(gradeEntry);
        }

        // POST: GradeEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gradeEntry = await _context.GradeEntries.FindAsync(id);
            if (gradeEntry != null)
            {
                _context.GradeEntries.Remove(gradeEntry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

		public async Task<IActionResult> Summary()
		{
			var grades = await _context.GradeEntries.ToListAsync();

			var summary = new
			{
				AveragePercentage = grades.Count > 0 ? grades.Average(c => c.Percentage) : 0
			};

			ViewBag.Average = Math.Round(summary.AveragePercentage, 2);

            return View();
        }
        
        private bool GradeEntryExists(int id)
        {
            return _context.GradeEntries.Any(e => e.Id == id);
        }
    }
}
