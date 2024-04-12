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
    public class PagosBasicoesController : Controller
    {
        private readonly MonimboBautistaRenacerContext _context;

        public PagosBasicoesController(MonimboBautistaRenacerContext context)
        {
            _context = context;
        }

        // GET: PagosBasicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PagosBasicos.ToListAsync());
        }

        // GET: PagosBasicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagosBasico = await _context.PagosBasicos
                .FirstOrDefaultAsync(m => m.IdPagos == id);
            if (pagosBasico == null)
            {
                return NotFound();
            }

            return View(pagosBasico);
        }

        // GET: PagosBasicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PagosBasicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPagos,Cantidad,FechaPago")] PagosBasico pagosBasico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagosBasico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagosBasico);
        }

        // GET: PagosBasicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagosBasico = await _context.PagosBasicos.FindAsync(id);
            if (pagosBasico == null)
            {
                return NotFound();
            }
            return View(pagosBasico);
        }

        // POST: PagosBasicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPagos,Cantidad,FechaPago")] PagosBasico pagosBasico)
        {
            if (id != pagosBasico.IdPagos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagosBasico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagosBasicoExists(pagosBasico.IdPagos))
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
            return View(pagosBasico);
        }

        // GET: PagosBasicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagosBasico = await _context.PagosBasicos
                .FirstOrDefaultAsync(m => m.IdPagos == id);
            if (pagosBasico == null)
            {
                return NotFound();
            }

            return View(pagosBasico);
        }

        // POST: PagosBasicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagosBasico = await _context.PagosBasicos.FindAsync(id);
            if (pagosBasico != null)
            {
                _context.PagosBasicos.Remove(pagosBasico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagosBasicoExists(int id)
        {
            return _context.PagosBasicos.Any(e => e.IdPagos == id);
        }
    }
}
