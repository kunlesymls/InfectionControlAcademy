using Academy.ViewModels.ApplicationVm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Academy.Infrastructure.Abstractions
{
    public interface IApplicantQuery
    {
        Task<List<AcademicQualificationVm>> AcademicQualificationList(string applicantId);
        Task<List<WorkingExperienceVm>> WorkingExperienceList(string applicantId);
        Task<List<ApplicantScheduleCreateVm>> ApplicantScheduleList(string applicantId);
    }
}
