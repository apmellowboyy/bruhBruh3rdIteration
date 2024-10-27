using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bruhBruh.Data;
using bruhBruh.Models;

namespace bruhBruh.Controllers
{
    public class veggiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public veggiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: veggies
        public async Task<IActionResult> Index()
        {
              return _context.veggies != null ? 
                          View(await _context.veggies.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.veggies'  is null.");
        }

        // GET: veggies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.veggies == null)
            {
                return NotFound();
            }

            var veggies = await _context.veggies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veggies == null)
            {
                return NotFound();
            }

            return View(veggies);
        }

        // GET: veggies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: veggies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Weight,Size,Value")] veggies veggies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veggies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veggies);
        }

        // GET: veggies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.veggies == null)
            {
                return NotFound();
            }

            var veggies = await _context.veggies.FindAsync(id);
            if (veggies == null)
            {
                return NotFound();
            }
            return View(veggies);
        }

        // POST: veggies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Weight,Size,Value")] veggies veggies)
        {
            if (id != veggies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veggies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!veggiesExists(veggies.Id))
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
            return View(veggies);
        }

        // GET: veggies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.veggies == null)
            {
                return NotFound();
            }

            var veggies = await _context.veggies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veggies == null)
            {
                return NotFound();
            }

            return View(veggies);
        }

        // POST: veggies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.veggies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.veggies'  is null.");
            }
            var veggies = await _context.veggies.FindAsync(id);
            if (veggies != null)
            {
                _context.veggies.Remove(veggies);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool veggiesExists(int id)
        {
          return (_context.veggies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
