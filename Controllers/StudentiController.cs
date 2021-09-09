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
    public class StudentiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Studenti
        public async Task<IActionResult> Index()
        {
            return View(await _context.Studenti.ToListAsync());
        }

        // GET: Studenti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenti = await _context.Studenti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studenti == null)
            {
                return NotFound();
            }

            return View(studenti);
        }

        // GET: Studenti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Studenti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,Oib,DatumRod,MjestoRod,Adresa")] Studenti studenti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studenti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studenti);
        }

        // GET: Studenti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenti = await _context.Studenti.FindAsync(id);
            if (studenti == null)
            {
                return NotFound();
            }
            return View(studenti);
        }

        // POST: Studenti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,Oib,DatumRod,MjestoRod,Adresa")] Studenti studenti)
        {
            if (id != studenti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studenti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentiExists(studenti.Id))
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
            return View(studenti);
        }

        // GET: Studenti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenti = await _context.Studenti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studenti == null)
            {
                return NotFound();
            }

            return View(studenti);
        }

        // POST: Studenti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studenti = await _context.Studenti.FindAsync(id);
            _context.Studenti.Remove(studenti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentiExists(int id)
        {
            return _context.Studenti.Any(e => e.Id == id);
        }
    }
}
