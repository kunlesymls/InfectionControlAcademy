using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academy.DAL.Context;
using Academy.Models.Training;

namespace Academy.Web.Controllers
{
    public class TrainingSchedulesController : Controller
    {
        private readonly AcademyDbContext _context;

        public TrainingSchedulesController(AcademyDbContext context)
        {
            _context = context;
        }

        // GET: TrainingSchedules
        public async Task<IActionResult> Index()
        {
            var academyDbContext = _context.TrainingSchedules.Include(t => t.TraningType);
            return View(await academyDbContext.ToListAsync());
        }

        // GET: TrainingSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingSchedule = await _context.TrainingSchedules
                .Include(t => t.TraningType)
                .FirstOrDefaultAsync(m => m.TrainingScheduleId == id);
            if (trainingSchedule == null)
            {
                return NotFound();
            }

            return View(trainingSchedule);
        }

        // GET: TrainingSchedules/Create
        public IActionResult Create()
        {
            ViewData["TraningTypeId"] = new SelectList(_context.TraningTypes, "TraningTypeId", "TraningTypeId");
            return View();
        }

        // POST: TrainingSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingScheduleId,TraningTypeId,Subject,Description,Venue,AdditionalInformation,Fee,RefundFee,HasCertificate,StartDate,EndDate,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] TrainingSchedule trainingSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TraningTypeId"] = new SelectList(_context.TraningTypes, "TraningTypeId", "TraningTypeId", trainingSchedule.TraningTypeId);
            return View(trainingSchedule);
        }

        // GET: TrainingSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingSchedule = await _context.TrainingSchedules.FindAsync(id);
            if (trainingSchedule == null)
            {
                return NotFound();
            }
            ViewData["TraningTypeId"] = new SelectList(_context.TraningTypes, "TraningTypeId", "TraningTypeId", trainingSchedule.TraningTypeId);
            return View(trainingSchedule);
        }

        // POST: TrainingSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainingScheduleId,TraningTypeId,Subject,Description,Venue,AdditionalInformation,Fee,RefundFee,HasCertificate,StartDate,EndDate,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] TrainingSchedule trainingSchedule)
        {
            if (id != trainingSchedule.TrainingScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingScheduleExists(trainingSchedule.TrainingScheduleId))
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
            ViewData["TraningTypeId"] = new SelectList(_context.TraningTypes, "TraningTypeId", "TraningTypeId", trainingSchedule.TraningTypeId);
            return View(trainingSchedule);
        }

        // GET: TrainingSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingSchedule = await _context.TrainingSchedules
                .Include(t => t.TraningType)
                .FirstOrDefaultAsync(m => m.TrainingScheduleId == id);
            if (trainingSchedule == null)
            {
                return NotFound();
            }

            return View(trainingSchedule);
        }

        // POST: TrainingSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainingSchedule = await _context.TrainingSchedules.FindAsync(id);
            _context.TrainingSchedules.Remove(trainingSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingScheduleExists(int id)
        {
            return _context.TrainingSchedules.Any(e => e.TrainingScheduleId == id);
        }
    }
}
