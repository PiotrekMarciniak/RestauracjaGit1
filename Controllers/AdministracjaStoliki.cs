using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restauracja.Data;
using Restauracja.Models;

namespace Restauracja.Controllers
{
    public class AdministracjaStoliki : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdministracjaStoliki(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdministracjaStoliki
        public async Task<IActionResult> Index()
        {
              return _context.StolikiVM != null ? 
                          View(await _context.StolikiVM.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StolikiVM'  is null.");
        }

        // GET: AdministracjaStoliki/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StolikiVM == null)
            {
                return NotFound();
            }

            var stolikiVM = await _context.StolikiVM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stolikiVM == null)
            {
                return NotFound();
            }

            return View(stolikiVM);
        }

        // GET: AdministracjaStoliki/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdministracjaStoliki/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ilosc,Ilosc_miejsc,Dostepnosc")] StolikiVM stolikiVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stolikiVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stolikiVM);
        }

        // GET: AdministracjaStoliki/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StolikiVM == null)
            {
                return NotFound();
            }

            var stolikiVM = await _context.StolikiVM.FindAsync(id);
            if (stolikiVM == null)
            {
                return NotFound();
            }
            return View(stolikiVM);
        }

        // POST: AdministracjaStoliki/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ilosc,Ilosc_miejsc,Dostepnosc")] StolikiVM stolikiVM)
        {
            if (id != stolikiVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stolikiVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StolikiVMExists(stolikiVM.Id))
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
            return View(stolikiVM);
        }

        // GET: AdministracjaStoliki/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StolikiVM == null)
            {
                return NotFound();
            }

            var stolikiVM = await _context.StolikiVM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stolikiVM == null)
            {
                return NotFound();
            }

            return View(stolikiVM);
        }

        // POST: AdministracjaStoliki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StolikiVM == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StolikiVM'  is null.");
            }
            var stolikiVM = await _context.StolikiVM.FindAsync(id);
            if (stolikiVM != null)
            {
                _context.StolikiVM.Remove(stolikiVM);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StolikiVMExists(int id)
        {
          return (_context.StolikiVM?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
