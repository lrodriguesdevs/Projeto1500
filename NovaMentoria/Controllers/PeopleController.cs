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
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index(int pageNumber = 1, int
             pageSize = 3)  //define a qtde de cadastros por pagina
        {
            var data = await _context.Person.ToListAsync();
            // Espaço de memória recebe informações do banco que estão na 
            // tabela cículo
            int totalCount = data.Count();
            int correctNumber = (pageNumber - 1) * pageSize;
            data = data
               .Skip(correctNumber)//0
                   .Take(pageSize)
                   .ToList();//0 - 1000 <- (10 -20) <- 10 unidades páginadas

            var viewModel = new PaginationViewModel<Person>
            {
                Items = data,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount

            };
            return View(viewModel);
        }

        public async Task<IActionResult> Students(int pageNumber = 1, int
             pageSize = 3)
        {

            //var data = await _context.Person.ToListAsync();
            // Espaço de memória recebe informações do banco que estão na 
            // tabela cículo
            int totalCount = _context.Person.Where(x => x.Type == TypePerson.Mentorado).Count();
            int excludeRecords = (pageNumber - 1) * pageSize;
            var data = await _context.Person

                   .Where(x => x.Type == TypePerson.Mentorado)
                   .Skip(excludeRecords)
                   .Take(pageSize)
                   //Filtra o aluno mentorado
                   .Include(p => p.Circle)
                   .ToListAsync();//0 - 1000 <- (10 -20) <- 10 unidades páginadas

            var viewModel = new PaginationViewModel<Person>
            {
                Items = data,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount

            };
            return View("Index", viewModel);
        }

        public async Task<IActionResult> Teachers(int pageNumber = 1, int
             pageSize = 3)
        {

            //var data = await _context.Person.ToListAsync();
            // Espaço de memória recebe informações do banco que estão na 
            // tabela cículo
            int totalCount = _context.Person.Where(x => x.Type == TypePerson.Mentor).Count();
            int excludeRecords = (pageNumber - 1) * pageSize;
            var data = await _context.Person
                .Where(x => x.Type == TypePerson.Mentor)
               .Skip(excludeRecords)
                   .Take(pageSize)
                   //Filtra o aluno mentorado
                   .Include(p => p.Circle)
                   .ToListAsync();//0 - 1000 <- (10 -20) <- 10 unidades páginadas

            var viewModel = new PaginationViewModel<Person>
            {
                Items = data,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount

            };
            return View("Index", viewModel);
        }
        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.Circle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            ViewData["CircleId"] = new SelectList(_context.Circle, "Id", "Name");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CircleId,Name,Type,CPF,Phone,DateBorn,NivelStudy,University,GraduateDate,Enterprise,Recommendation,IsStudying,Email")] Person person)
        {
            if (ModelState.IsValid)
            {
                person.DateRegister = DateTime.Now;
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CircleId"] = new SelectList(_context.Circle, "Id", "Name", person.CircleId);
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["CircleId"] = new SelectList(_context.Circle, "Id", "Name", person.CircleId);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CircleId,Name,Type,CPF,Phone,DateBorn,University,Enterprise,Recommendation,IsStudying,Email")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userPerson = _context.Person.FirstOrDefault(u => u.Id == id);

                    userPerson.DateRegister = person.DateRegister;
                    userPerson.DateBorn = person.DateBorn;
                    userPerson.Type = person.Type;
                    userPerson.CircleId = person.CircleId;
                    userPerson.Name = person.Name;
                    userPerson.CPF = person.CPF;
                    userPerson.Email = person.Email;
                    userPerson.Phone = person.Phone;
                    userPerson.NivelStudy = person.NivelStudy;
                    userPerson.University = person.University;
                    userPerson.GraduateDate = person.GraduateDate;
                    userPerson.Enterprise = person.Enterprise;
                    userPerson.Recommendation = person.Recommendation;
                    userPerson.IsStudying = person.IsStudying;

                    _context.Update(userPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            ViewData["CircleId"] = new SelectList(_context.Circle, "Id", "Name", person.CircleId);
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.Circle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Person.FindAsync(id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("MultipleDelete")]
        public async Task<IActionResult> MultipleDeleteConfirmed(List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var person = await _context.Person.FindAsync(id);
                    _context.Person.Remove(person);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }


            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}
