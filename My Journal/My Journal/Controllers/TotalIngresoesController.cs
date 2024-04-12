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
    public class TotalIngresoesController : Controller
    {
        private readonly MonimboBautistaRenacerContext _context;

        public TotalIngresoesController(MonimboBautistaRenacerContext context)
        {
            _context = context;
        }

        // GET: TotalIngresoes
        public async Task<IActionResult> Index()
        {
            var monimboBautistaRenacerContext = _context.TotalIngresos.Include(t => t.IdDiezmoNavigation).Include(t => t.IdOfrendasNavigation).Include(t => t.IdVariosNavigation);
            return View(await monimboBautistaRenacerContext.ToListAsync());
        }

        // GET: TotalIngresoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalIngreso = await _context.TotalIngresos
                .Include(t => t.IdDiezmoNavigation)
                .Include(t => t.IdOfrendasNavigation)
                .Include(t => t.IdVariosNavigation)
                .FirstOrDefaultAsync(m => m.IdTotalIngresos == id);
            if (totalIngreso == null)
            {
                return NotFound();
            }

            return View(totalIngreso);
        }

        // GET: TotalIngresoes/Create
        public IActionResult Create()
        {
            ViewData["IdDiezmo"] = new SelectList(_context.Diezmos, "IdDiezmo", "IdDiezmo");
            ViewData["IdOfrendas"] = new SelectList(_context.Ofrendas, "IdOfrendas", "IdOfrendas");
            ViewData["IdVarios"] = new SelectList(_context.IngresosVarios, "IdVarios", "IdVarios");
            return View();
        }

        // POST: TotalIngresoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTotalIngresos,TotalIngreso1,MesIngresos,IdOfrendas,IdDiezmo,IdVarios")] TotalIngreso totalIngreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(totalIngreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDiezmo"] = new SelectList(_context.Diezmos, "IdDiezmo", "IdDiezmo", totalIngreso.IdDiezmo);
            ViewData["IdOfrendas"] = new SelectList(_context.Ofrendas, "IdOfrendas", "IdOfrendas", totalIngreso.IdOfrendas);
            ViewData["IdVarios"] = new SelectList(_context.IngresosVarios, "IdVarios", "IdVarios", totalIngreso.IdVarios);
            return View(totalIngreso);
        }

        // GET: TotalIngresoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalIngreso = await _context.TotalIngresos.FindAsync(id);
            if (totalIngreso == null)
            {
                return NotFound();
            }
            ViewData["IdDiezmo"] = new SelectList(_context.Diezmos, "IdDiezmo", "IdDiezmo", totalIngreso.IdDiezmo);
            ViewData["IdOfrendas"] = new SelectList(_context.Ofrendas, "IdOfrendas", "IdOfrendas", totalIngreso.IdOfrendas);
            ViewData["IdVarios"] = new SelectList(_context.IngresosVarios, "IdVarios", "IdVarios", totalIngreso.IdVarios);
            return View(totalIngreso);
        }

        // POST: TotalIngresoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTotalIngresos,TotalIngreso1,MesIngresos,IdOfrendas,IdDiezmo,IdVarios")] TotalIngreso totalIngreso)
        {
            if (id != totalIngreso.IdTotalIngresos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(totalIngreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TotalIngresoExists(totalIngreso.IdTotalIngresos))
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
            ViewData["IdDiezmo"] = new SelectList(_context.Diezmos, "IdDiezmo", "IdDiezmo", totalIngreso.IdDiezmo);
            ViewData["IdOfrendas"] = new SelectList(_context.Ofrendas, "IdOfrendas", "IdOfrendas", totalIngreso.IdOfrendas);
            ViewData["IdVarios"] = new SelectList(_context.IngresosVarios, "IdVarios", "IdVarios", totalIngreso.IdVarios);
            return View(totalIngreso);
        }

        // GET: TotalIngresoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalIngreso = await _context.TotalIngresos
                .Include(t => t.IdDiezmoNavigation)
                .Include(t => t.IdOfrendasNavigation)
                .Include(t => t.IdVariosNavigation)
                .FirstOrDefaultAsync(m => m.IdTotalIngresos == id);
            if (totalIngreso == null)
            {
                return NotFound();
            }

            return View(totalIngreso);
        }

        // POST: TotalIngresoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var totalIngreso = await _context.TotalIngresos.FindAsync(id);
            if (totalIngreso != null)
            {
                _context.TotalIngresos.Remove(totalIngreso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TotalIngresoExists(int id)
        {
            return _context.TotalIngresos.Any(e => e.IdTotalIngresos == id);
        }
    }
}
