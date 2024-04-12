using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My_Journal.Models;

namespace My_Journal.Controllers
{
    public class TotalsController : Controller
    {
        private readonly MonimboBautistaRenacerContext _context;

        public TotalsController(MonimboBautistaRenacerContext context)
        {
            _context = context;
        }

        // GET: Totals
        public async Task<IActionResult> Index()
        {
            var monimboBautistaRenacerContext = _context.Totals.Include(t => t.IdTotalEgresosNavigation).Include(t => t.IdTotalIngresosNavigation);
            return View(await monimboBautistaRenacerContext.ToListAsync());
        }

        // GET: Totals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var total = await _context.Totals
                .Include(t => t.IdTotalEgresosNavigation)
                .Include(t => t.IdTotalIngresosNavigation)
                .FirstOrDefaultAsync(m => m.IdTotal == id);
            if (total == null)
            {
                return NotFound();
            }

            return View(total);
        }

        // GET: Totals/Create
        public IActionResult Create()
        {
            ViewData["IdTotalEgresos"] = new SelectList(_context.TotalEgresos, "IdTotalEgresos", "IdTotalEgresos");
            ViewData["IdTotalIngresos"] = new SelectList(_context.TotalIngresos, "IdTotalIngresos", "IdTotalIngresos");
            return View();
        }

        // POST: Totals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTotal,Total1,MesTotal,IdTotalIngresos,IdTotalEgresos")] Total total)
        {
            if (ModelState.IsValid)
            {
                _context.Add(total);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTotalEgresos"] = new SelectList(_context.TotalEgresos, "IdTotalEgresos", "IdTotalEgresos", total.IdTotalEgresos);
            ViewData["IdTotalIngresos"] = new SelectList(_context.TotalIngresos, "IdTotalIngresos", "IdTotalIngresos", total.IdTotalIngresos);
            return View(total);
        }

        // GET: Totals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var total = await _context.Totals.FindAsync(id);
            if (total == null)
            {
                return NotFound();
            }
            ViewData["IdTotalEgresos"] = new SelectList(_context.TotalEgresos, "IdTotalEgresos", "IdTotalEgresos", total.IdTotalEgresos);
            ViewData["IdTotalIngresos"] = new SelectList(_context.TotalIngresos, "IdTotalIngresos", "IdTotalIngresos", total.IdTotalIngresos);
            return View(total);
        }

        // POST: Totals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTotal,Total1,MesTotal,IdTotalIngresos,IdTotalEgresos")] Total total)
        {
            if (id != total.IdTotal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(total);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TotalExists(total.IdTotal))
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
            ViewData["IdTotalEgresos"] = new SelectList(_context.TotalEgresos, "IdTotalEgresos", "IdTotalEgresos", total.IdTotalEgresos);
            ViewData["IdTotalIngresos"] = new SelectList(_context.TotalIngresos, "IdTotalIngresos", "IdTotalIngresos", total.IdTotalIngresos);
            return View(total);
        }

        // GET: Totals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var total = await _context.Totals
                .Include(t => t.IdTotalEgresosNavigation)
                .Include(t => t.IdTotalIngresosNavigation)
                .FirstOrDefaultAsync(m => m.IdTotal == id);
            if (total == null)
            {
                return NotFound();
            }

            return View(total);
        }

        // POST: Totals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var total = await _context.Totals.FindAsync(id);
            if (total != null)
            {
                _context.Totals.Remove(total);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TotalExists(int id)
        {
            return _context.Totals.Any(e => e.IdTotal == id);
        }
    }
}
