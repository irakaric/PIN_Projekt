using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIN_Projekt.Data;
using PIN_Projekt.Models;

namespace PIN_Projekt.Controllers
{
    public class PredmetiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PredmetiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Predmeti
        public async Task<IActionResult> Index()
        {
            return View(await _context.Predmeti.ToListAsync());
        }

        // GET: Predmeti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmeti = await _context.Predmeti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (predmeti == null)
            {
                return NotFound();
            }

            return View(predmeti);
        }

        // GET: Predmeti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Predmeti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Opis")] Predmeti predmeti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(predmeti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(predmeti);
        }

        // GET: Predmeti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmeti = await _context.Predmeti.FindAsync(id);
            if (predmeti == null)
            {
                return NotFound();
            }
            return View(predmeti);
        }

        // POST: Predmeti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Opis")] Predmeti predmeti)
        {
            if (id != predmeti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(predmeti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PredmetiExists(predmeti.Id))
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
            return View(predmeti);
        }

        // GET: Predmeti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmeti = await _context.Predmeti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (predmeti == null)
            {
                return NotFound();
            }

            return View(predmeti);
        }

        // POST: Predmeti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var predmeti = await _context.Predmeti.FindAsync(id);
            _context.Predmeti.Remove(predmeti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PredmetiExists(int id)
        {
            return _context.Predmeti.Any(e => e.Id == id);
        }
    }
}
