using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NovaMentoria.Data;
using NovaMentoria.Models;

namespace NovaMentoria.Controllers
{
    [Authorize]
    public class HourDaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HourDaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HourDays
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HourDay.Include(h => h.ActualState);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HourDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourDay = await _context.HourDay
                .Include(h => h.ActualState)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hourDay == null)
            {
                return NotFound();
            }

            return View(hourDay);
        }

        // GET: HourDays/Create
        public IActionResult Create()
        {
            ViewData["ActualStateId"] = new SelectList(_context.PlanoResumo, "Id", "Description");
            return View();
        }

        // POST: HourDays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActualStateId,Date,Hours,Delivered")] HourDay hourDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hourDay);
                await _context.SaveChangesAsync();
                var actualState = await _context.ActualStates
                    .Where(x => x.Id == hourDay.ActualStateId)
                    .Include(x => x.Project)
                    .Include(x => x.TypeConsultor)
                    .Include(x => x.HoursDay)
                    .FirstOrDefaultAsync();

                actualState.AttCalculos();
                _context.Update(actualState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            ViewData["ActualStateId"] = new SelectList(_context.PlanoResumo, "Id", "Description", hourDay.ActualStateId);
            return View(hourDay);
        }

        // GET: HourDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourDay = await _context.HourDay.FindAsync(id);
            if (hourDay == null)
            {
                return NotFound();
            }
            ViewData["ActualStateId"] = new SelectList(_context.PlanoResumo, "Id", "Description", hourDay.ActualStateId);
            return View(hourDay);
        }

        // POST: HourDays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActualStateId,Date,Hours,Delivered")] HourDay hourDay)
        {
            if (id != hourDay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hourDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HourDayExists(hourDay.Id))
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
            ViewData["ActualStateId"] = new SelectList(_context.PlanoResumo, "Id", "Description", hourDay.ActualStateId);
            return View(hourDay);
        }

        // GET: HourDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourDay = await _context.HourDay
                .Include(h => h.ActualState)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hourDay == null)
            {
                return NotFound();
            }

            return View(hourDay);
        }

        // POST: HourDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hourDay = await _context.HourDay.FindAsync(id);
            _context.HourDay.Remove(hourDay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HourDayExists(int id)
        {
            return _context.HourDay.Any(e => e.Id == id);
        }
    }
}
