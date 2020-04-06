using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academy.DAL.Context;
using Academy.Models.TrainingApplication;

namespace Academy.Web.Controllers
{
    public class WorkingExperiencesController : Controller
    {
        private readonly AcademyDbContext _context;

        public WorkingExperiencesController(AcademyDbContext context)
        {
            _context = context;
        }

        // GET: WorkingExperiences
        public async Task<IActionResult> Index()
        {
            var academyDbContext = _context.WorkingExperiences.Include(w => w.Applicant);
            return View(await academyDbContext.ToListAsync());
        }

        // GET: WorkingExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingExperience = await _context.WorkingExperiences
                .Include(w => w.Applicant)
                .FirstOrDefaultAsync(m => m.WorkingExperienceId == id);
            if (workingExperience == null)
            {
                return NotFound();
            }

            return View(workingExperience);
        }

        // GET: WorkingExperiences/Create
        public IActionResult Create()
        {
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId");
            return View();
        }

        // POST: WorkingExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkingExperienceId,ApplicantId,Organization,Role,Location,IsCurrent,EmploymentType,FromDate,ToDate,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] WorkingExperience workingExperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workingExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId", workingExperience.ApplicantId);
            return View(workingExperience);
        }

        // GET: WorkingExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingExperience = await _context.WorkingExperiences.FindAsync(id);
            if (workingExperience == null)
            {
                return NotFound();
            }
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId", workingExperience.ApplicantId);
            return View(workingExperience);
        }

        // POST: WorkingExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkingExperienceId,ApplicantId,Organization,Role,Location,IsCurrent,EmploymentType,FromDate,ToDate,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] WorkingExperience workingExperience)
        {
            if (id != workingExperience.WorkingExperienceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workingExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkingExperienceExists(workingExperience.WorkingExperienceId))
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
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId", workingExperience.ApplicantId);
            return View(workingExperience);
        }

        // GET: WorkingExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingExperience = await _context.WorkingExperiences
                .Include(w => w.Applicant)
                .FirstOrDefaultAsync(m => m.WorkingExperienceId == id);
            if (workingExperience == null)
            {
                return NotFound();
            }

            return View(workingExperience);
        }

        // POST: WorkingExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workingExperience = await _context.WorkingExperiences.FindAsync(id);
            _context.WorkingExperiences.Remove(workingExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkingExperienceExists(int id)
        {
            return _context.WorkingExperiences.Any(e => e.WorkingExperienceId == id);
        }
    }
}
