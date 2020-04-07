using Academy.DAL.Context;
using Academy.Infrastructure.Abstractions;
using Academy.ViewModels.ApplicationVm;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Infrastructure.Concrete
{
    public class ApplicantQuery : IApplicantQuery
    {
        private AcademyDbContext _db { get; }
        public ApplicantQuery(AcademyDbContext db)
        {
            _db = db;
        }

        public async Task<List<AcademicQualificationVm>> AcademicQualificationList(string applicantId)
        {
            return await _db.AcademicQualifications.AsNoTracking()
                .Where(x => x.ApplicantId.Equals(applicantId))
                .Select(s => new AcademicQualificationVm
                {
                    AcademicQualificationId = s.AcademicQualificationId,
                    ApplicantId = s.ApplicantId,
                    AwardedDegree = s.AwardedDegree,
                    InstitutionName = s.InstitutionName,
                    YearObtained = s.YearObtained,
                }).ToListAsync();
        }

        public async Task<List<WorkingExperienceVm>> WorkingExperienceList(string applicantId)
        {
            return await _db.WorkingExperiences.AsNoTracking()
                .Where(x => x.ApplicantId.Equals(applicantId))
                .Select(s => new WorkingExperienceVm
                {
                    WorkingExperienceId = s.WorkingExperienceId,
                    ApplicantId = s.ApplicantId,
                    EmploymentType = s.EmploymentType,
                    IsCurrent = s.IsCurrent,
                    Location = s.Location,
                    Organization = s.Organization,
                    Role = s.Role,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate
                }).ToListAsync();
        }


        public async Task<List<ApplicantScheduleCreateVm>> ApplicantScheduleList(string applicantId)
        {
            var model = await _db.ApplicantSchedules.AsNoTracking()
                .Where(x => x.ApplicantId.Equals(applicantId)).ToListAsync();
            return model.Select(s => new ApplicantScheduleCreateVm
            {
                ApplicantScheduleId = s.ApplicantScheduleId,
                ApplicantId = s.ApplicantId,
                ApplicationDate = s.ApplicationDate,
                TrainingScheduleId = s.TrainingScheduleId,
                ApplicantName = s.Applicant.FullName
            }).ToList();
        }
    }
}
