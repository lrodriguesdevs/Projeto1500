using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NovaMentoria.Data;
using NovaMentoria.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace NovaMentoria.Controllers
{
    [Authorize]
    public class ActualStatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActualStatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActualStates
        public async Task<IActionResult> Index(int pageNumber = 1, int
            pageSize = 3)
        {
            
                var data = await _context.ActualStates.ToListAsync();
                
                int totalCount = data.Count();
                int excludeRecords = (pageNumber - 1) * pageSize;
                data = await _context.ActualStates
                     .Skip(excludeRecords)//0
                     .Take(pageSize)
                     .Include(a => a.Circle)
                     .Include(a => a.Person)
                     .Include(a => a.Project)
                     .Include(a => a.TypeConsultor)
                     .ToListAsync(); //0 - 1000 <- (10 -20) <- 10 unidades páginadas

                var viewModel = new PaginationViewModel<ActualState>
                {
                    Items = data,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount

                };


                return View(viewModel);
        }

        // GET: ActualStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualState = await _context.ActualStates
                .Include(a => a.Circle)
                .Include(a => a.Person)
                .Include(a => a.Project)
                .Include(a => a.TypeConsultor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actualState == null)
            {
                return NotFound();
            }

            return View(actualState);
        }

        // GET: ActualStates/Create
        public IActionResult Create()
        {
            ViewData["CircleId"] = new SelectList(_context.Circle, "Id", "Name");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Name");
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name");
            ViewData["TypeConsultorId"] = new SelectList(_context.TypeConsultor, "Id", "Name");
            return View();
        }

        // POST: ActualStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CircleId,ProjectId,TypeObject,TypeConsultorId,Description,TimePlanned,PersonId,RealTime,Delivered,DateTime")] ActualState actualState)
        {
            if (ModelState.IsValid)
            {
                var projeto = await _context.Project
                    .Where(x => x.Id == actualState.ProjectId)
                    .FirstOrDefaultAsync();

                var consultor = await _context.TypeConsultor
                    .Where(x => x.Id == actualState.TypeConsultorId)
                    .FirstOrDefaultAsync();

                actualState.TypeConsultor = consultor;
                actualState.Project = projeto;

                actualState.AttCalculos();



                _context.Add(actualState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CircleId"] = new SelectList(_context.Circle, "Id", "Name", actualState.CircleId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Name", actualState.PersonId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name", actualState.ProjectId);
            ViewData["TypeConsultorId"] = new SelectList(_context.TypeConsultor, "Id", "Name", actualState.TypeConsultorId);
            return View(actualState);
        }

        // GET: ActualStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualState = await _context.ActualStates.FindAsync(id);
            if (actualState == null)
            {
                return NotFound();
            }
            ViewData["CircleId"] = new SelectList(_context.Circle, "Id", "Name", actualState.CircleId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Name", actualState.PersonId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name", actualState.ProjectId);
            ViewData["TypeConsultorId"] = new SelectList(_context.TypeConsultor, "Id", "Name", actualState.TypeConsultorId);
            return View(actualState);
        }

        // POST: ActualStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CircleId,ProjectId,TypeObject,TypeConsultorId,Description,TimePlanned,Value,PersonId,RealTime,Delivered,Productivity,DateTime,FinalValue")] ActualState actualState)
        {
            if (id != actualState.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var projeto = await _context.Project
                    .Where(x => x.Id == actualState.ProjectId)
                    .FirstOrDefaultAsync();

                    var consultor = await _context.TypeConsultor
                    .Where(x => x.Id == actualState.TypeConsultorId)
                    .FirstOrDefaultAsync();

                    actualState.TypeConsultor = consultor;
                    actualState.Project = projeto;

                    actualState.AttCalculos();

                    _context.Update(actualState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActualStateExists(actualState.Id))
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
            ViewData["CircleId"] = new SelectList(_context.Circle, "Id", "Name", actualState.CircleId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Name", actualState.PersonId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name", actualState.ProjectId);
            ViewData["TypeConsultorId"] = new SelectList(_context.TypeConsultor, "Id", "Name", actualState.TypeConsultorId);
            return View(actualState);
        }

        // GET: ActualStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualState = await _context.ActualStates
                .Include(a => a.Circle)
                .Include(a => a.Person)
                .Include(a => a.Project)
                .Include(a => a.TypeConsultor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actualState == null)
            {
                return NotFound();
            }

            return View(actualState);
        }

        // POST: ActualStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actualState = await _context.ActualStates.FindAsync(id);
            _context.ActualStates.Remove(actualState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActualStateExists(int id)
        {
            return _context.ActualStates.Any(e => e.Id == id);
        }
    }
}
