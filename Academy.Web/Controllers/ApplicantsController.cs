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
    public class ApplicantsController : Controller
    {
        private readonly AcademyDbContext _context;

        public ApplicantsController(AcademyDbContext context)
        {
            _context = context;
        }

        // GET: Applicants
        public async Task<IActionResult> Index()
        {
            var academyDbContext = _context.Applicants.Include(a => a.ProfessionalCategory);
            return View(await academyDbContext.ToListAsync());
        }

        // GET: Applicants/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants
                .Include(a => a.ProfessionalCategory)
                .FirstOrDefaultAsync(m => m.ApplicantId == id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // GET: Applicants/Create
        public IActionResult Create()
        {
            ViewData["ProfessionalCategoryId"] = new SelectList(_context.ProfessionalCategories, "ProfessionalCategoryId", "ProfessionalCategoryId");
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicantId,ProfessionalCategoryId,LicenseNumber,LicenseAuthority,IsLicenseVerified,FirstName,MiddleName,LastName,Gender,Email,PhoneNumber,MaritalStatus,Address,TownOfBirth,Lga,StateOfOrigin,Nationality,CountryOfBirth,DateOfBirth,Passport,Signature,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfessionalCategoryId"] = new SelectList(_context.ProfessionalCategories, "ProfessionalCategoryId", "ProfessionalCategoryId", applicant.ProfessionalCategoryId);
            return View(applicant);
        }

        // GET: Applicants/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            ViewData["ProfessionalCategoryId"] = new SelectList(_context.ProfessionalCategories, "ProfessionalCategoryId", "ProfessionalCategoryId", applicant.ProfessionalCategoryId);
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ApplicantId,ProfessionalCategoryId,LicenseNumber,LicenseAuthority,IsLicenseVerified,FirstName,MiddleName,LastName,Gender,Email,PhoneNumber,MaritalStatus,Address,TownOfBirth,Lga,StateOfOrigin,Nationality,CountryOfBirth,DateOfBirth,Passport,Signature,DateCreated,DateLastUpdated,CreatedBy,UpdatedBy")] Applicant applicant)
        {
            if (id != applicant.ApplicantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantExists(applicant.ApplicantId))
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
            ViewData["ProfessionalCategoryId"] = new SelectList(_context.ProfessionalCategories, "ProfessionalCategoryId", "ProfessionalCategoryId", applicant.ProfessionalCategoryId);
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants
                .Include(a => a.ProfessionalCategory)
                .FirstOrDefaultAsync(m => m.ApplicantId == id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicant = await _context.Applicants.FindAsync(id);
            _context.Applicants.Remove(applicant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicantExists(string id)
        {
            return _context.Applicants.Any(e => e.ApplicantId == id);
        }
    }
}
