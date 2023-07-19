using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemasDeInformacioinMVC;

namespace SistemasDeInformacioinMVC.Controllers
{
    public class NumeroDocumentoesController : Controller
    {
        private readonly ProyectoContext _context;

        public NumeroDocumentoesController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: NumeroDocumentoes
        public async Task<IActionResult> Index()
        {
              return _context.NumeroDocumentos != null ? 
                          View(await _context.NumeroDocumentos.ToListAsync()) :
                          Problem("Entity set 'ProyectoContext.NumeroDocumentos'  is null.");
        }

        // GET: NumeroDocumentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NumeroDocumentos == null)
            {
                return NotFound();
            }

            var numeroDocumento = await _context.NumeroDocumentos
                .FirstOrDefaultAsync(m => m.IdNumeroDocumento == id);
            if (numeroDocumento == null)
            {
                return NotFound();
            }

            return View(numeroDocumento);
        }

        // GET: NumeroDocumentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NumeroDocumentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNumeroDocumento,UltimoNumero,FechaRegistro")] NumeroDocumento numeroDocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(numeroDocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(numeroDocumento);
        }

        // GET: NumeroDocumentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NumeroDocumentos == null)
            {
                return NotFound();
            }

            var numeroDocumento = await _context.NumeroDocumentos.FindAsync(id);
            if (numeroDocumento == null)
            {
                return NotFound();
            }
            return View(numeroDocumento);
        }

        // POST: NumeroDocumentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNumeroDocumento,UltimoNumero,FechaRegistro")] NumeroDocumento numeroDocumento)
        {
            if (id != numeroDocumento.IdNumeroDocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numeroDocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumeroDocumentoExists(numeroDocumento.IdNumeroDocumento))
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
            return View(numeroDocumento);
        }

        // GET: NumeroDocumentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NumeroDocumentos == null)
            {
                return NotFound();
            }

            var numeroDocumento = await _context.NumeroDocumentos
                .FirstOrDefaultAsync(m => m.IdNumeroDocumento == id);
            if (numeroDocumento == null)
            {
                return NotFound();
            }

            return View(numeroDocumento);
        }

        // POST: NumeroDocumentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NumeroDocumentos == null)
            {
                return Problem("Entity set 'ProyectoContext.NumeroDocumentos'  is null.");
            }
            var numeroDocumento = await _context.NumeroDocumentos.FindAsync(id);
            if (numeroDocumento != null)
            {
                _context.NumeroDocumentos.Remove(numeroDocumento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumeroDocumentoExists(int id)
        {
          return (_context.NumeroDocumentos?.Any(e => e.IdNumeroDocumento == id)).GetValueOrDefault();
        }
    }
}
