using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Controllers
{
    public class ProducatorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProducatorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Producators
        public async Task<IActionResult> Index()
        {
              return View(await _context.Producatori.ToListAsync());
        }

        // GET: Producators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Producatori == null)
            {
                return NotFound();
            }

            var producator = await _context.Producatori
                .FirstOrDefaultAsync(m => m.ID == id);
            if (producator == null)
            {
                return NotFound();
            }

            return View(producator);
        }

        // GET: Producators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nume_Firma,Descriere,Locatie,An_Aparitie")] Producator producator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producator);
        }

        // GET: Producators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Producatori == null)
            {
                return NotFound();
            }

            var producator = await _context.Producatori.FindAsync(id);
            if (producator == null)
            {
                return NotFound();
            }
            return View(producator);
        }

        // POST: Producators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nume_Firma,Descriere,Locatie,An_Aparitie")] Producator producator)
        {
            if (id != producator.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducatorExists(producator.ID))
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
            return View(producator);
        }

        // GET: Producators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Producatori == null)
            {
                return NotFound();
            }

            var producator = await _context.Producatori
                .FirstOrDefaultAsync(m => m.ID == id);
            if (producator == null)
            {
                return NotFound();
            }

            return View(producator);
        }

        // POST: Producators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Producatori == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Producator'  is null.");
            }
            var producator = await _context.Producatori.FindAsync(id);
            if (producator != null)
            {
                _context.Producatori.Remove(producator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducatorExists(int id)
        {
          return _context.Producatori.Any(e => e.ID == id);
        }
    }
}
