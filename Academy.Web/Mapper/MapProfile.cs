using Academy.Models.Core;
using Academy.Models.Training;
using Academy.Models.TrainingApplication;
using Academy.ViewModels.ApplicationVm;
using Academy.ViewModels.CoreVm;
using Academy.ViewModels.TraningVm;
using AutoMapper;

namespace Academy.Web.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //CreateMap<Staff, CreateEditStaffVm>().ReverseMap();
            CreateMap<AcademicQualification, AcademicQualificationVm>().ReverseMap();
            CreateMap<ApplicantSchedule, ApplicantScheduleCreateVm>().ReverseMap();
            CreateMap<WorkingExperience, WorkingExperienceVm>().ReverseMap();

            CreateMap<Applicant, ApplicantCreateEditVm>().ReverseMap();
            CreateMap<ProfessionalCategory, ProfessionalCategoryVm>().ReverseMap();

            CreateMap<SessionSpeaker, SessionSpeakerVm>().ReverseMap();
            CreateMap<Speaker, SpeakerCreateEditVm>().ReverseMap();
            CreateMap<TrainingSchedule, TrainingScheduleVm>().ReverseMap();
            CreateMap<TrainingSession, TrainingSessionVm>().ReverseMap();
            CreateMap<TraningType, TraningTypeVm>().ReverseMap();
        }
    }
}
