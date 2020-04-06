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
    public class AcademicQualificationsController : Controller
    {
        private readonly AcademyDbContext _context;

        public AcademicQualificationsController(AcademyDbContext context)
        {
            _context = context;
        }

        // GET: AcademicQualifications
        public async Task<IActionResult> Index()
        {
            var academyDbContext = _context.AcademicQualifications.Include(a => a.Applicant);
            return View(await academyDbContext.ToListAsync());
        }

        // GET: AcademicQualifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicQualification = await _context.AcademicQualifications
                .Include(a => a.Applicant)
                .FirstOrDefaultAsync(m => m.AcademicQualificationId == id);
            if (academicQualification == null)
            {
                return NotFound();
            }

            return View(academicQualification);
        }

        // GET: AcademicQualifications/Create
        public IActionResult Create()
        {
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId");
            return View();
        }

        // POST: AcademicQualifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcademicQualificationId,ApplicantId,InstitutionName,AwardedDegree,YearObtained,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] AcademicQualification academicQualification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicQualification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId", academicQualification.ApplicantId);
            return View(academicQualification);
        }

        // GET: AcademicQualifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicQualification = await _context.AcademicQualifications.FindAsync(id);
            if (academicQualification == null)
            {
                return NotFound();
            }
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId", academicQualification.ApplicantId);
            return View(academicQualification);
        }

        // POST: AcademicQualifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcademicQualificationId,ApplicantId,InstitutionName,AwardedDegree,YearObtained,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] AcademicQualification academicQualification)
        {
            if (id != academicQualification.AcademicQualificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicQualification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicQualificationExists(academicQualification.AcademicQualificationId))
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
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId", academicQualification.ApplicantId);
            return View(academicQualification);
        }

        // GET: AcademicQualifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicQualification = await _context.AcademicQualifications
                .Include(a => a.Applicant)
                .FirstOrDefaultAsync(m => m.AcademicQualificationId == id);
            if (academicQualification == null)
            {
                return NotFound();
            }

            return View(academicQualification);
        }

        // POST: AcademicQualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicQualification = await _context.AcademicQualifications.FindAsync(id);
            _context.AcademicQualifications.Remove(academicQualification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicQualificationExists(int id)
        {
            return _context.AcademicQualifications.Any(e => e.AcademicQualificationId == id);
        }
    }
}
