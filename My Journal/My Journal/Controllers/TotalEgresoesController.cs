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
    public class TotalEgresoesController : Controller
    {
        private readonly MonimboBautistaRenacerContext _context;

        public TotalEgresoesController(MonimboBautistaRenacerContext context)
        {
            _context = context;
        }

        // GET: TotalEgresoes
        public async Task<IActionResult> Index()
        {
            var monimboBautistaRenacerContext = _context.TotalEgresos.Include(t => t.IdEgresosvariosNavigation).Include(t => t.IdOfrendaPastoralNavigation).Include(t => t.IdPagosNavigation);
            return View(await monimboBautistaRenacerContext.ToListAsync());
        }

        // GET: TotalEgresoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalEgreso = await _context.TotalEgresos
                .Include(t => t.IdEgresosvariosNavigation)
                .Include(t => t.IdOfrendaPastoralNavigation)
                .Include(t => t.IdPagosNavigation)
                .FirstOrDefaultAsync(m => m.IdTotalEgresos == id);
            if (totalEgreso == null)
            {
                return NotFound();
            }

            return View(totalEgreso);
        }

        // GET: TotalEgresoes/Create
        public IActionResult Create()
        {
            ViewData["IdEgresosvarios"] = new SelectList(_context.EgresosVarios, "IdEgresosvarios", "IdEgresosvarios");
            ViewData["IdOfrendaPastoral"] = new SelectList(_context.OfrendaPastorals, "IdOfrendaPastoral", "IdOfrendaPastoral");
            ViewData["IdPagos"] = new SelectList(_context.PagosBasicos, "IdPagos", "IdPagos");
            return View();
        }

        // POST: TotalEgresoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTotalEgresos,TotalEgreso1,MesEgreso,IdOfrendaPastoral,IdEgresosvarios,IdPagos")] TotalEgreso totalEgreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(totalEgreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEgresosvarios"] = new SelectList(_context.EgresosVarios, "IdEgresosvarios", "IdEgresosvarios", totalEgreso.IdEgresosvarios);
            ViewData["IdOfrendaPastoral"] = new SelectList(_context.OfrendaPastorals, "IdOfrendaPastoral", "IdOfrendaPastoral", totalEgreso.IdOfrendaPastoral);
            ViewData["IdPagos"] = new SelectList(_context.PagosBasicos, "IdPagos", "IdPagos", totalEgreso.IdPagos);
            return View(totalEgreso);
        }

        // GET: TotalEgresoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalEgreso = await _context.TotalEgresos.FindAsync(id);
            if (totalEgreso == null)
            {
                return NotFound();
            }
            ViewData["IdEgresosvarios"] = new SelectList(_context.EgresosVarios, "IdEgresosvarios", "IdEgresosvarios", totalEgreso.IdEgresosvarios);
            ViewData["IdOfrendaPastoral"] = new SelectList(_context.OfrendaPastorals, "IdOfrendaPastoral", "IdOfrendaPastoral", totalEgreso.IdOfrendaPastoral);
            ViewData["IdPagos"] = new SelectList(_context.PagosBasicos, "IdPagos", "IdPagos", totalEgreso.IdPagos);
            return View(totalEgreso);
        }

        // POST: TotalEgresoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTotalEgresos,TotalEgreso1,MesEgreso,IdOfrendaPastoral,IdEgresosvarios,IdPagos")] TotalEgreso totalEgreso)
        {
            if (id != totalEgreso.IdTotalEgresos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(totalEgreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TotalEgresoExists(totalEgreso.IdTotalEgresos))
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
            ViewData["IdEgresosvarios"] = new SelectList(_context.EgresosVarios, "IdEgresosvarios", "IdEgresosvarios", totalEgreso.IdEgresosvarios);
            ViewData["IdOfrendaPastoral"] = new SelectList(_context.OfrendaPastorals, "IdOfrendaPastoral", "IdOfrendaPastoral", totalEgreso.IdOfrendaPastoral);
            ViewData["IdPagos"] = new SelectList(_context.PagosBasicos, "IdPagos", "IdPagos", totalEgreso.IdPagos);
            return View(totalEgreso);
        }

        // GET: TotalEgresoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalEgreso = await _context.TotalEgresos
                .Include(t => t.IdEgresosvariosNavigation)
                .Include(t => t.IdOfrendaPastoralNavigation)
                .Include(t => t.IdPagosNavigation)
                .FirstOrDefaultAsync(m => m.IdTotalEgresos == id);
            if (totalEgreso == null)
            {
                return NotFound();
            }

            return View(totalEgreso);
        }

        // POST: TotalEgresoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var totalEgreso = await _context.TotalEgresos.FindAsync(id);
            if (totalEgreso != null)
            {
                _context.TotalEgresos.Remove(totalEgreso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TotalEgresoExists(int id)
        {
            return _context.TotalEgresos.Any(e => e.IdTotalEgresos == id);
        }
    }
}
