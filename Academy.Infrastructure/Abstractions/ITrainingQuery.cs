using Academy.ViewModels.TraningVm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Infrastructure.Abstractions
{
    public interface ITrainingQuery
    {
        Task<List<TraningTypeVm>> TrainingTypeList();
        Task<List<TrainingSessionVm>> TrainingSessionList();
        Task<List<TrainingScheduleVm>> TrainingScheduleList();
        Task<List<SpeakerCreateEditVm>> SpeakerList();
        Task<List<SessionSpeakerVm>> SessionSpeakerList();
    }
}
