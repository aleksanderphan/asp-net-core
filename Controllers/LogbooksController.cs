using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppMobil.Data;
using WebAppMobil.Models;

namespace WebAppMobil.Controllers
{
    public class LogbooksController : Controller
    {
        private readonly WebAppMobilContext _context;

        public LogbooksController(WebAppMobilContext context)
        {
            _context = context;
        }

        // GET: Logbooks
        public async Task<IActionResult> Index()
        {
            var webAppMobilContext = _context.Logbook.Include(l => l.Car);
            return View(await webAppMobilContext.ToListAsync());
        }

        // GET: Logbooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logbook = await _context.Logbook
                .Include(l => l.Car)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (logbook == null)
            {
                return NotFound();
            }

            return View(logbook);
        }

        // GET: Logbooks/Create
        public IActionResult Create()
        {
            ViewData["CarID"] = new SelectList(_context.Car, "ID", "ID");
            return View();
        }

        // POST: Logbooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Arrival,Departure,CarID,DriverName,LicensePlate,Destination,PermitNo")] Logbook logbook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logbook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarID"] = new SelectList(_context.Car, "ID", "ID", logbook.CarID);
            return View(logbook);
        }

        // GET: Logbooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logbook = await _context.Logbook.FindAsync(id);
            if (logbook == null)
            {
                return NotFound();
            }
            ViewData["CarID"] = new SelectList(_context.Car, "ID", "ID", logbook.CarID);
            return View(logbook);
        }

        // POST: Logbooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Arrival,Departure,CarID,DriverName,LicensePlate,Destination,PermitNo")] Logbook logbook)
        {
            if (id != logbook.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logbook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogbookExists(logbook.ID))
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
            ViewData["CarID"] = new SelectList(_context.Car, "ID", "ID", logbook.CarID);
            return View(logbook);
        }

        // GET: Logbooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logbook = await _context.Logbook
                .Include(l => l.Car)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (logbook == null)
            {
                return NotFound();
            }

            return View(logbook);
        }

        // POST: Logbooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logbook = await _context.Logbook.FindAsync(id);
            if (logbook != null)
            {
                _context.Logbook.Remove(logbook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogbookExists(int id)
        {
            return _context.Logbook.Any(e => e.ID == id);
        }
    }
}
