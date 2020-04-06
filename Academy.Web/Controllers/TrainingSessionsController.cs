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
    public class TrainingSessionsController : Controller
    {
        private readonly AcademyDbContext _context;

        public TrainingSessionsController(AcademyDbContext context)
        {
            _context = context;
        }

        // GET: TrainingSessions
        public async Task<IActionResult> Index()
        {
            var academyDbContext = _context.TrainingSessions.Include(t => t.TrainingSchedule);
            return View(await academyDbContext.ToListAsync());
        }

        // GET: TrainingSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingSession = await _context.TrainingSessions
                .Include(t => t.TrainingSchedule)
                .FirstOrDefaultAsync(m => m.TrainingSessionId == id);
            if (trainingSession == null)
            {
                return NotFound();
            }

            return View(trainingSession);
        }

        // GET: TrainingSessions/Create
        public IActionResult Create()
        {
            ViewData["TrainingScheduleId"] = new SelectList(_context.TrainingSchedules, "TrainingScheduleId", "TrainingScheduleId");
            return View();
        }

        // POST: TrainingSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingSessionId,TrainingScheduleId,SessionName,Topic,Expectations,Location,Duration,SessionDate,StartTime,IsActive,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] TrainingSession trainingSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrainingScheduleId"] = new SelectList(_context.TrainingSchedules, "TrainingScheduleId", "TrainingScheduleId", trainingSession.TrainingScheduleId);
            return View(trainingSession);
        }

        // GET: TrainingSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingSession = await _context.TrainingSessions.FindAsync(id);
            if (trainingSession == null)
            {
                return NotFound();
            }
            ViewData["TrainingScheduleId"] = new SelectList(_context.TrainingSchedules, "TrainingScheduleId", "TrainingScheduleId", trainingSession.TrainingScheduleId);
            return View(trainingSession);
        }

        // POST: TrainingSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainingSessionId,TrainingScheduleId,SessionName,Topic,Expectations,Location,Duration,SessionDate,StartTime,IsActive,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] TrainingSession trainingSession)
        {
            if (id != trainingSession.TrainingSessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingSessionExists(trainingSession.TrainingSessionId))
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
            ViewData["TrainingScheduleId"] = new SelectList(_context.TrainingSchedules, "TrainingScheduleId", "TrainingScheduleId", trainingSession.TrainingScheduleId);
            return View(trainingSession);
        }

        // GET: TrainingSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingSession = await _context.TrainingSessions
                .Include(t => t.TrainingSchedule)
                .FirstOrDefaultAsync(m => m.TrainingSessionId == id);
            if (trainingSession == null)
            {
                return NotFound();
            }

            return View(trainingSession);
        }

        // POST: TrainingSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainingSession = await _context.TrainingSessions.FindAsync(id);
            _context.TrainingSessions.Remove(trainingSession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingSessionExists(int id)
        {
            return _context.TrainingSessions.Any(e => e.TrainingSessionId == id);
        }
    }
}
