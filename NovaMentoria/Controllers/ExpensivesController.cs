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
    public class ExpensivesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpensivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expensives
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Expensive.Include(e => e.BankAccount).Include(e => e.Capture).Include(e => e.Disbursement).Include(e => e.Person);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Expensives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expensive = await _context.Expensive
                .Include(e => e.BankAccount)
                .Include(e => e.Capture)
                .Include(e => e.Disbursement)
                .Include(e => e.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expensive == null)
            {
                return NotFound();
            }

            return View(expensive);
        }

        // GET: Expensives/Create
        public IActionResult Create()
        {
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "Id", "Id");
            ViewData["CaptureId"] = new SelectList(_context.Capture, "Id", "Id");
            ViewData["DisbursementId"] = new SelectList(_context.CostCenter, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            return View();
        }

        // POST: Expensives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,RegisterDate,CashDate,MonthDate,CompDate,DisbursementId,CaptureId,PersonId,BankAccountId,TargetBill,Description,Value,Plan,Balance")] Expensive expensive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expensive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "Id", "Id", expensive.BankAccountId);
            ViewData["CaptureId"] = new SelectList(_context.Capture, "Id", "Id", expensive.CaptureId);
            ViewData["DisbursementId"] = new SelectList(_context.CostCenter, "Id", "Id", expensive.DisbursementId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", expensive.PersonId);
            return View(expensive);
        }

        // GET: Expensives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expensive = await _context.Expensive.FindAsync(id);
            if (expensive == null)
            {
                return NotFound();
            }
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "Id", "Id", expensive.BankAccountId);
            ViewData["CaptureId"] = new SelectList(_context.Capture, "Id", "Id", expensive.CaptureId);
            ViewData["DisbursementId"] = new SelectList(_context.CostCenter, "Id", "Id", expensive.DisbursementId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", expensive.PersonId);
            return View(expensive);
        }

        // POST: Expensives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,RegisterDate,CashDate,MonthDate,CompDate,DisbursementId,CaptureId,PersonId,BankAccountId,TargetBill,Description,Value,Plan,Balance")] Expensive expensive)
        {
            if (id != expensive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expensive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpensiveExists(expensive.Id))
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
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "Id", "Id", expensive.BankAccountId);
            ViewData["CaptureId"] = new SelectList(_context.Capture, "Id", "Id", expensive.CaptureId);
            ViewData["DisbursementId"] = new SelectList(_context.CostCenter, "Id", "Id", expensive.DisbursementId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", expensive.PersonId);
            return View(expensive);
        }

        // GET: Expensives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expensive = await _context.Expensive
                .Include(e => e.BankAccount)
                .Include(e => e.Capture)
                .Include(e => e.Disbursement)
                .Include(e => e.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expensive == null)
            {
                return NotFound();
            }

            return View(expensive);
        }

        // POST: Expensives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expensive = await _context.Expensive.FindAsync(id);
            _context.Expensive.Remove(expensive);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpensiveExists(int id)
        {
            return _context.Expensive.Any(e => e.Id == id);
        }
    }
}
