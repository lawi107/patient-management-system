using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Data;
using PatientManagement.Models;

namespace PatientManagement.Controllers
{
    public class ConditionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConditionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conditions
        public async Task<IActionResult> Index()
        {
              return _context.condition != null ? 
                          View(await _context.condition.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.condition'  is null.");
        }

        // GET: Conditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.condition == null)
            {
                return NotFound();
            }

            var condition = await _context.condition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condition == null)
            {
                return NotFound();
            }

            return View(condition);
        }

        // GET: Conditions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Condition condition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condition);
        }

        // GET: Conditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.condition == null)
            {
                return NotFound();
            }

            var condition = await _context.condition.FindAsync(id);
            if (condition == null)
            {
                return NotFound();
            }
            return View(condition);
        }

        // POST: Conditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Condition condition)
        {
            if (id != condition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConditionExists(condition.Id))
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
            return View(condition);
        }

        // GET: Conditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.condition == null)
            {
                return NotFound();
            }

            var condition = await _context.condition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condition == null)
            {
                return NotFound();
            }

            return View(condition);
        }

        // POST: Conditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.condition == null)
            {
                return Problem("Entity set 'ApplicationDbContext.condition'  is null.");
            }
            var condition = await _context.condition.FindAsync(id);
            if (condition != null)
            {
                _context.condition.Remove(condition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConditionExists(int id)
        {
          return (_context.condition?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
