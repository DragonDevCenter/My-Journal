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
    public class OfrendasController : Controller
    {
        private readonly MonimboBautistaRenacerContext _context;

        public OfrendasController(MonimboBautistaRenacerContext context)
        {
            _context = context;
        }

        // GET: Ofrendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ofrendas.ToListAsync());
        }

        // GET: Ofrendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofrenda = await _context.Ofrendas
                .FirstOrDefaultAsync(m => m.IdOfrendas == id);
            if (ofrenda == null)
            {
                return NotFound();
            }

            return View(ofrenda);
        }

        // GET: Ofrendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ofrendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOfrendas,Cantidad,FechaOfrenda")] Ofrenda ofrenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ofrenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ofrenda);
        }

        // GET: Ofrendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofrenda = await _context.Ofrendas.FindAsync(id);
            if (ofrenda == null)
            {
                return NotFound();
            }
            return View(ofrenda);
        }

        // POST: Ofrendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOfrendas,Cantidad,FechaOfrenda")] Ofrenda ofrenda)
        {
            if (id != ofrenda.IdOfrendas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ofrenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfrendaExists(ofrenda.IdOfrendas))
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
            return View(ofrenda);
        }

        // GET: Ofrendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofrenda = await _context.Ofrendas
                .FirstOrDefaultAsync(m => m.IdOfrendas == id);
            if (ofrenda == null)
            {
                return NotFound();
            }

            return View(ofrenda);
        }

        // POST: Ofrendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ofrenda = await _context.Ofrendas.FindAsync(id);
            if (ofrenda != null)
            {
                _context.Ofrendas.Remove(ofrenda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfrendaExists(int id)
        {
            return _context.Ofrendas.Any(e => e.IdOfrendas == id);
        }
    }
}
