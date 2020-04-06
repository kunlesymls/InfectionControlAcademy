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
    public class SessionSpeakersController : Controller
    {
        private readonly AcademyDbContext _context;

        public SessionSpeakersController(AcademyDbContext context)
        {
            _context = context;
        }

        // GET: SessionSpeakers
        public async Task<IActionResult> Index()
        {
            var academyDbContext = _context.SessionSpeakers.Include(s => s.Speaker).Include(s => s.TrainingSession);
            return View(await academyDbContext.ToListAsync());
        }

        // GET: SessionSpeakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionSpeaker = await _context.SessionSpeakers
                .Include(s => s.Speaker)
                .Include(s => s.TrainingSession)
                .FirstOrDefaultAsync(m => m.SessionSpeakerId == id);
            if (sessionSpeaker == null)
            {
                return NotFound();
            }

            return View(sessionSpeaker);
        }

        // GET: SessionSpeakers/Create
        public IActionResult Create()
        {
            ViewData["SpeakerId"] = new SelectList(_context.Speakers, "SpeakerId", "SpeakerId");
            ViewData["TrainingSessionId"] = new SelectList(_context.TrainingSessions, "TrainingSessionId", "TrainingSessionId");
            return View();
        }

        // POST: SessionSpeakers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessionSpeakerId,TrainingSessionId,SpeakerId,IsLeadSpeaker")] SessionSpeaker sessionSpeaker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sessionSpeaker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpeakerId"] = new SelectList(_context.Speakers, "SpeakerId", "SpeakerId", sessionSpeaker.SpeakerId);
            ViewData["TrainingSessionId"] = new SelectList(_context.TrainingSessions, "TrainingSessionId", "TrainingSessionId", sessionSpeaker.TrainingSessionId);
            return View(sessionSpeaker);
        }

        // GET: SessionSpeakers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionSpeaker = await _context.SessionSpeakers.FindAsync(id);
            if (sessionSpeaker == null)
            {
                return NotFound();
            }
            ViewData["SpeakerId"] = new SelectList(_context.Speakers, "SpeakerId", "SpeakerId", sessionSpeaker.SpeakerId);
            ViewData["TrainingSessionId"] = new SelectList(_context.TrainingSessions, "TrainingSessionId", "TrainingSessionId", sessionSpeaker.TrainingSessionId);
            return View(sessionSpeaker);
        }

        // POST: SessionSpeakers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SessionSpeakerId,TrainingSessionId,SpeakerId,IsLeadSpeaker")] SessionSpeaker sessionSpeaker)
        {
            if (id != sessionSpeaker.SessionSpeakerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessionSpeaker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionSpeakerExists(sessionSpeaker.SessionSpeakerId))
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
            ViewData["SpeakerId"] = new SelectList(_context.Speakers, "SpeakerId", "SpeakerId", sessionSpeaker.SpeakerId);
            ViewData["TrainingSessionId"] = new SelectList(_context.TrainingSessions, "TrainingSessionId", "TrainingSessionId", sessionSpeaker.TrainingSessionId);
            return View(sessionSpeaker);
        }

        // GET: SessionSpeakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionSpeaker = await _context.SessionSpeakers
                .Include(s => s.Speaker)
                .Include(s => s.TrainingSession)
                .FirstOrDefaultAsync(m => m.SessionSpeakerId == id);
            if (sessionSpeaker == null)
            {
                return NotFound();
            }

            return View(sessionSpeaker);
        }

        // POST: SessionSpeakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sessionSpeaker = await _context.SessionSpeakers.FindAsync(id);
            _context.SessionSpeakers.Remove(sessionSpeaker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionSpeakerExists(int id)
        {
            return _context.SessionSpeakers.Any(e => e.SessionSpeakerId == id);
        }
    }
}
