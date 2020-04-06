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
    public class ApplicantSchedulesController : Controller
    {
        private readonly AcademyDbContext _context;

        public ApplicantSchedulesController(AcademyDbContext context)
        {
            _context = context;
        }

        // GET: ApplicantSchedules
        public async Task<IActionResult> Index()
        {
            var academyDbContext = _context.ApplicantSchedules.Include(a => a.Applicant).Include(a => a.TrainingSchedule);
            return View(await academyDbContext.ToListAsync());
        }

        // GET: ApplicantSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantSchedule = await _context.ApplicantSchedules
                .Include(a => a.Applicant)
                .Include(a => a.TrainingSchedule)
                .FirstOrDefaultAsync(m => m.ApplicantScheduleId == id);
            if (applicantSchedule == null)
            {
                return NotFound();
            }

            return View(applicantSchedule);
        }

        // GET: ApplicantSchedules/Create
        public IActionResult Create()
        {
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId");
            ViewData["TrainingScheduleId"] = new SelectList(_context.TrainingSchedules, "TrainingScheduleId", "TrainingScheduleId");
            return View();
        }

        // POST: ApplicantSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicantScheduleId,ApplicantId,TrainingScheduleId,IsQualified,HasPaid,HasCompletedSchedule,ApplicationDate,DateCompleted,IsRefunded,IsSuspended,GeneralComment,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] ApplicantSchedule applicantSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicantSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId", applicantSchedule.ApplicantId);
            ViewData["TrainingScheduleId"] = new SelectList(_context.TrainingSchedules, "TrainingScheduleId", "TrainingScheduleId", applicantSchedule.TrainingScheduleId);
            return View(applicantSchedule);
        }

        // GET: ApplicantSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantSchedule = await _context.ApplicantSchedules.FindAsync(id);
            if (applicantSchedule == null)
            {
                return NotFound();
            }
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId", applicantSchedule.ApplicantId);
            ViewData["TrainingScheduleId"] = new SelectList(_context.TrainingSchedules, "TrainingScheduleId", "TrainingScheduleId", applicantSchedule.TrainingScheduleId);
            return View(applicantSchedule);
        }

        // POST: ApplicantSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicantScheduleId,ApplicantId,TrainingScheduleId,IsQualified,HasPaid,HasCompletedSchedule,ApplicationDate,DateCompleted,IsRefunded,IsSuspended,GeneralComment,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] ApplicantSchedule applicantSchedule)
        {
            if (id != applicantSchedule.ApplicantScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicantSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantScheduleExists(applicantSchedule.ApplicantScheduleId))
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
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId", applicantSchedule.ApplicantId);
            ViewData["TrainingScheduleId"] = new SelectList(_context.TrainingSchedules, "TrainingScheduleId", "TrainingScheduleId", applicantSchedule.TrainingScheduleId);
            return View(applicantSchedule);
        }

        // GET: ApplicantSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantSchedule = await _context.ApplicantSchedules
                .Include(a => a.Applicant)
                .Include(a => a.TrainingSchedule)
                .FirstOrDefaultAsync(m => m.ApplicantScheduleId == id);
            if (applicantSchedule == null)
            {
                return NotFound();
            }

            return View(applicantSchedule);
        }

        // POST: ApplicantSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicantSchedule = await _context.ApplicantSchedules.FindAsync(id);
            _context.ApplicantSchedules.Remove(applicantSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicantScheduleExists(int id)
        {
            return _context.ApplicantSchedules.Any(e => e.ApplicantScheduleId == id);
        }
    }
}
