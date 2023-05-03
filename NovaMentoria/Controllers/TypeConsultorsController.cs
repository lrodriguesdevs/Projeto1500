using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NovaMentoria.Data;
using NovaMentoria.Models;

namespace NovaMentoria.Controllers
{
    public class TypeConsultorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeConsultorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeConsultors
        public async Task<IActionResult> Index(int pageNumber = 1, int
            pageSize = 3)  //define a qtde de cadastros por pagina
        {
            var data = await _context.TypeConsultor.ToListAsync();
            // Espaço de memória recebe informações do banco que estão na 
            // tabela círculo
            int totalCount = data.Count();
            int correctNumber = (pageNumber - 1) * pageSize;
            data = data
               .Skip(correctNumber)//0
               .Take(pageSize)
               .ToList();//0 - 1000 <- (10 -20) <- 10 unidades páginadas

            var viewModel = new PaginationViewModel<TypeConsultor>
            {
                Items = data,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount

            };




            // Take pega somente a qtde indicada entre os parenteses
            // Skip pula a quantidade indicada entre os parenteses

            return View(viewModel);
        }

        //{
        //    return View(await _context.TypeConsultor.ToListAsync());
        //}

        // GET: TypeConsultors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeConsultor = await _context.TypeConsultor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeConsultor == null)
            {
                return NotFound();
            }

            return View(typeConsultor);
        }

        // GET: TypeConsultors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeConsultors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Fee")] TypeConsultor typeConsultor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeConsultor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeConsultor);
        }

        // GET: TypeConsultors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeConsultor = await _context.TypeConsultor.FindAsync(id);
            if (typeConsultor == null)
            {
                return NotFound();
            }
            return View(typeConsultor);
        }

        // POST: TypeConsultors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Fee")] TypeConsultor typeConsultor)
        {
            if (id != typeConsultor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeConsultor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeConsultorExists(typeConsultor.Id))
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
            return View(typeConsultor);
        }

        // GET: TypeConsultors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeConsultor = await _context.TypeConsultor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeConsultor == null)
            {
                return NotFound();
            }

            return View(typeConsultor);
        }

        // POST: TypeConsultors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeConsultor = await _context.TypeConsultor.FindAsync(id);
            _context.TypeConsultor.Remove(typeConsultor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeConsultorExists(int id)
        {
            return _context.TypeConsultor.Any(e => e.Id == id);
        }
    }
}
