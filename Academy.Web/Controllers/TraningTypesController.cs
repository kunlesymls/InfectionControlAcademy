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
    public class TraningTypesController : Controller
    {
        private readonly AcademyDbContext _context;

        public TraningTypesController(AcademyDbContext context)
        {
            _context = context;
        }

        // GET: TraningTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TraningTypes.ToListAsync());
        }

        // GET: TraningTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traningType = await _context.TraningTypes
                .FirstOrDefaultAsync(m => m.TraningTypeId == id);
            if (traningType == null)
            {
                return NotFound();
            }

            return View(traningType);
        }

        // GET: TraningTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TraningTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TraningTypeId,TraningCode,TraningName,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] TraningType traningType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(traningType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(traningType);
        }

        // GET: TraningTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traningType = await _context.TraningTypes.FindAsync(id);
            if (traningType == null)
            {
                return NotFound();
            }
            return View(traningType);
        }

        // POST: TraningTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TraningTypeId,TraningCode,TraningName,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] TraningType traningType)
        {
            if (id != traningType.TraningTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(traningType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraningTypeExists(traningType.TraningTypeId))
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
            return View(traningType);
        }

        // GET: TraningTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traningType = await _context.TraningTypes
                .FirstOrDefaultAsync(m => m.TraningTypeId == id);
            if (traningType == null)
            {
                return NotFound();
            }

            return View(traningType);
        }

        // POST: TraningTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var traningType = await _context.TraningTypes.FindAsync(id);
            _context.TraningTypes.Remove(traningType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraningTypeExists(int id)
        {
            return _context.TraningTypes.Any(e => e.TraningTypeId == id);
        }
    }
}
