using Academy.DAL.Context;
using Academy.Infrastructure.Abstractions;
using Academy.ViewModels.TraningVm;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Infrastructure.Concrete
{
    public class TrainingQuery : ITrainingQuery
    {
        private AcademyDbContext _db { get; }
        public TrainingQuery(AcademyDbContext db)
        {
            _db = db;
        }

        public async Task<List<TraningTypeVm>> TrainingTypeList()
        {
            return await _db.TraningTypes.AsNoTracking().Select(s => new TraningTypeVm
            {
                TraningTypeId = s.TraningTypeId,
                TraningCode = s.TraningCode,
                TraningName = s.TraningName
            }).ToListAsync();
        }

        public async Task<List<TrainingSessionVm>> TrainingSessionList()
        {
            return await _db.TrainingSessions.Include(i => i.TrainingSchedule).AsNoTracking().Select(s => new TrainingSessionVm
            {
                TrainingSessionId = s.TrainingSessionId,
                SessionName = s.SessionName,
                Topic = s.Topic,
                Expectations = s.Expectations,
                Duration = s.Duration,
                Location = s.Location,
                IsActive = s.IsActive,
                SessionDate = s.SessionDate,
                StartTime = s.StartTime,
                TrainingScheduleId = s.TrainingScheduleId,
                TrainingScheduleName = s.TrainingSchedule.Subject
            }).ToListAsync();
        }

        public async Task<List<TrainingScheduleVm>> TrainingScheduleList()
        {
            return await _db.TrainingSchedules.Include(i => i.TraningType).AsNoTracking().Select(s => new TrainingScheduleVm
            {
                TrainingScheduleId = s.TrainingScheduleId,
                TraningTypeId = s.TraningTypeId,
                TraningTypeName = s.TraningType.TraningName,
                Subject = s.Subject,
                Venue = s.Venue,
                AdditionalInformation = s.AdditionalInformation,
                Description = s.Description,
                EndDate = s.EndDate,
                Fee = s.Fee,
                HasCertificate = s.HasCertificate,
                RefundFee = s.RefundFee,
                StartDate = s.StartDate
            }).ToListAsync();
        }

        public async Task<List<SpeakerCreateEditVm>> SpeakerList()
        {
            return await _db.Speakers.AsNoTracking().Select(s => new SpeakerCreateEditVm
            {
                SpeakerId = s.SpeakerId,
                Title = s.Title,
                Honours = s.Honours,
                FirstName = s.FirstName,
                LastName = s.LastName,
                MiddleName = s.MiddleName,
                Gender = s.Gender,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Passport = s.Passport,
                Signature = s.Signature,
            }).ToListAsync();
        }


        public async Task<List<SessionSpeakerVm>> SessionSpeakerList()
        {
            return await _db.SessionSpeakers.Include(i => i.Speaker).Include(i => i.TrainingSession).AsNoTracking()
                .Select(s => new SessionSpeakerVm
                {
                    SessionSpeakerId = s.SessionSpeakerId,
                    SpeakerId = s.SpeakerId,
                    SpeakerName = s.Speaker.FullName,
                    IsLeadSpeaker = s.IsLeadSpeaker,
                    TrainingSessionId = s.TrainingSessionId,
                    TrainingSessionName = s.TrainingSession.SessionName
                }).ToListAsync();
        }
    }
}
