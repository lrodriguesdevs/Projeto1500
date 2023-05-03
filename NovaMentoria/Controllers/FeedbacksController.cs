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
using NovaMentoriaSistema.Models;

namespace NovaMentoria.Controllers
{
    [Authorize]
    public class FeedbacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedbacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Feedbacks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Feedback
                .Include(f => f.Circle)
                .Include(f => f.Theme)
                .Include(f => f.PersonFeedbacks)

                .ThenInclude(f => f.Person);


            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Feedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedback
                .Include(f => f.Circle)
                .Include(f => f.Theme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // GET: Feedbacks/Create
        public IActionResult Create()
        {
            ViewData["CircleId"] = new SelectList(_context.Circle, "Id", "Name");
            ViewData["ThemeId"] = new SelectList(_context.Themes, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Person.Where(x => x.Type ==
            TypePerson.Mentorado), "Id", "Name");
            ViewData["TeacherId"] = new SelectList(_context.Person.Where(x => x.Type ==
            TypePerson.Mentor), "Id", "Name");



            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,CircleId,ThemeId,OportunityLearning,Note,Comment,StudentPersonId,TeacherPersonId")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedback);
                await _context.SaveChangesAsync();

                PersonFeedback Student = new PersonFeedback();
                Student.TypePerson = TypePerson.Mentorado;
                Student.FeedbackId = feedback.Id;
                Student.PersonId = feedback.StudentPersonId;

                PersonFeedback Teacher = new PersonFeedback();
                Teacher.TypePerson = TypePerson.Mentor;
                Teacher.FeedbackId = feedback.Id;
                Teacher.PersonId = feedback.TeacherPersonId;


                _context.Add(Student);
                _context.Add(Teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CircleId"] = new SelectList(_context.Circle, "Id", "Name", feedback.CircleId);
            ViewData["ThemeId"] = new SelectList(_context.Themes, "Id", "Name", feedback.ThemeId);
            ViewData["StudentId"] = new SelectList(_context.Person.Where(x => x.Type ==
            TypePerson.Mentorado), "Id", "Name");
            ViewData["TeacherId"] = new SelectList(_context.Person.Where(x => x.Type ==
            TypePerson.Mentor), "Id", "Name");


            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedback.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            ViewData["CircleId"] = new SelectList(_context.Circle, "Id", "Name", feedback.CircleId);
            ViewData["ThemeId"] = new SelectList(_context.Themes, "Id", "Name", feedback.ThemeId);
            ViewData["StudentId"] = new SelectList(_context.Person.Where(x => x.Type ==
            TypePerson.Mentorado), "Id", "Name");
            ViewData["TeacherId"] = new SelectList(_context.Person.Where(x => x.Type ==
            TypePerson.Mentor), "Id", "Name");



            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind
            ("Id,Date,CircleId,ThemeId,OportunityLearning,Note,Comment,StudentPersonId,TeacherPersonId")] Feedback feedback)
        {
            if (id != feedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                 try
                { 
                {
                     var feedbacks = await _context.PersonFeedbacks
                        .Where(x => x.FeedbackId == feedback.Id)
                        .ToListAsync();

                foreach (var i in feedbacks)
                   {
                        if (i.TypePerson == TypePerson.Mentor)
                        {
                            i.PersonId = feedback.TeacherPerson.Id;
                        }
                        else
                        {
                            i.PersonId = feedback.StudentPersonId;
               }
                    }






                    _context.Update(feedback);
                    await _context.SaveChangesAsync();
                }
                    }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(feedback.Id))
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
            ViewData["CircleId"] = new SelectList(_context.Circle, "Id", "Name", feedback.CircleId);
            ViewData["ThemeId"] = new SelectList(_context.Themes, "Id", "Name", feedback.ThemeId);
            return View(feedback);
        }

        // GET: Feedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedback
                .Include(f => f.Circle)
                .Include(f => f.Theme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedback = await _context.Feedback.FindAsync(id);
            _context.Feedback.Remove(feedback);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackExists(int id)
        {
            return _context.Feedback.Any(e => e.Id == id);
        }
    }
}
