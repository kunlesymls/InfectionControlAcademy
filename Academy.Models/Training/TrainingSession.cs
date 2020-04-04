using Academy.Models.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academy.Models.Training
{
    public class TrainingSession : Audit
    {
        public int TrainingSessionId { get; set; }
        public int TrainingScheduleId { get; set; }
        public string SessionName { get; set; }
        public string Topic { get; set; }
        public string Expectations { get; set; }
        public string Location { get; set; }
        public int Duration { get; set; }
        public DateTime SessionDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        public bool IsActive { get; set; }      
        public TrainingSchedule TrainingSchedule { get; set; }
        public ICollection<SessionSpeaker> SessionSpeakers { get; set; }
    }
}
