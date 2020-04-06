using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academy.DAL.Context;
using Academy.Models.Core;

namespace Academy.Web.Controllers
{
    public class ProfessionalCategoriesController : Controller
    {
        private readonly AcademyDbContext _context;

        public ProfessionalCategoriesController(AcademyDbContext context)
        {
            _context = context;
        }

        // GET: ProfessionalCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProfessionalCategories.ToListAsync());
        }

        // GET: ProfessionalCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalCategory = await _context.ProfessionalCategories
                .FirstOrDefaultAsync(m => m.ProfessionalCategoryId == id);
            if (professionalCategory == null)
            {
                return NotFound();
            }

            return View(professionalCategory);
        }

        // GET: ProfessionalCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfessionalCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessionalCategoryId,ProfessionalCode,ProfessionalName,IsVisible,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] ProfessionalCategory professionalCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professionalCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professionalCategory);
        }

        // GET: ProfessionalCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalCategory = await _context.ProfessionalCategories.FindAsync(id);
            if (professionalCategory == null)
            {
                return NotFound();
            }
            return View(professionalCategory);
        }

        // POST: ProfessionalCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessionalCategoryId,ProfessionalCode,ProfessionalName,IsVisible,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] ProfessionalCategory professionalCategory)
        {
            if (id != professionalCategory.ProfessionalCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professionalCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionalCategoryExists(professionalCategory.ProfessionalCategoryId))
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
            return View(professionalCategory);
        }

        // GET: ProfessionalCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalCategory = await _context.ProfessionalCategories
                .FirstOrDefaultAsync(m => m.ProfessionalCategoryId == id);
            if (professionalCategory == null)
            {
                return NotFound();
            }

            return View(professionalCategory);
        }

        // POST: ProfessionalCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professionalCategory = await _context.ProfessionalCategories.FindAsync(id);
            _context.ProfessionalCategories.Remove(professionalCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionalCategoryExists(int id)
        {
            return _context.ProfessionalCategories.Any(e => e.ProfessionalCategoryId == id);
        }
    }
}
