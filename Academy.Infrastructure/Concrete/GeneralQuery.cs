using Academy.DAL.Context;
using Academy.Infrastructure.Abstractions;
using Academy.Models.Core;
using Academy.ViewModels.CoreVm;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Infrastructure.Concrete
{
    public class GeneralQuery : IGeneralQuery
    {
        private AcademyDbContext _db { get; }

        public GeneralQuery(AcademyDbContext db)
        {
            _db = db;
        }

        public Staff GetStaffDetail(string userName)
        {
            return _db.Staffs.FirstOrDefault(x => x.Email.Equals(userName));
        }

        public Applicant GetApplicantId(string userId)
        {
            return _db.Applicants.AsNoTracking().FirstOrDefault(x => x.ApplicantId.Equals(userId));
        }

        public async Task<List<ProfessionalCategoryVm>> ProfessionalCategoryList()
        {
            return await _db.ProfessionalCategories.AsNoTracking().Select(s => new ProfessionalCategoryVm
            {
                ProfessionalCategoryId = s.ProfessionalCategoryId,
                ProfessionalCode = s.ProfessionalCode,
                ProfessionalName = s.ProfessionalName,
                IsVisible = s.IsVisible
            }).ToListAsync();
        } 
        
        public async Task<List<ApplicantCreateEditVm>> ApplicantList()
        {
            return await _db.Applicants.AsNoTracking().Select(s => new ApplicantCreateEditVm
            {
                ApplicantId = s.ApplicantId,
                ProfessionalCategoryId = s.ProfessionalCategoryId,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Address = s.Address,
                FirstName = s.FirstName,
                LastName = s.LastName,
                MiddleName = s.MiddleName,
                Gender = s.Gender,
                LicenseAuthority = s.LicenseAuthority,
                LicenseNumber = s.LicenseNumber,
                Passport = s.Passport,
                Signature = s.Signature,
                StateOfOrigin = s.StateOfOrigin,
                Lga = s.Lga
            }).ToListAsync();
        }
    }
}
