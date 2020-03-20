using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HalloWeb.Data;
using HalloWeb.Models;

namespace HalloWeb.Controllers
{
    public class KloController : Controller
    {
        private readonly HalloWebContext _context;

        public KloController(HalloWebContext context)
        {
            _context = context;
        }

        // GET: Klo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klopapier.ToListAsync());
        }

        // GET: Klo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klopapier = await _context.Klopapier
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klopapier == null)
            {
                return NotFound();
            }

            return View(klopapier);
        }

        // GET: Klo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnzahlBlatt,Hersteller,Produkt,Langen,Duft")] Klopapier klopapier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klopapier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klopapier);
        }

        // GET: Klo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klopapier = await _context.Klopapier.FindAsync(id);
            if (klopapier == null)
            {
                return NotFound();
            }
            return View(klopapier);
        }

        // POST: Klo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnzahlBlatt,Hersteller,Produkt,Langen,Duft")] Klopapier klopapier)
        {
            if (id != klopapier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klopapier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlopapierExists(klopapier.Id))
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
            return View(klopapier);
        }

        // GET: Klo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klopapier = await _context.Klopapier
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klopapier == null)
            {
                return NotFound();
            }

            return View(klopapier);
        }

        // POST: Klo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klopapier = await _context.Klopapier.FindAsync(id);
            _context.Klopapier.Remove(klopapier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlopapierExists(int id)
        {
            return _context.Klopapier.Any(e => e.Id == id);
        }
    }
}
