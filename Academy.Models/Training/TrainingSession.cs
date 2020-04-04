using System;
using System.ComponentModel.DataAnnotations;

namespace Academy.Models.Training
{
    public class TrainingSession
    {
        public int TrainingSessionId { get; set; }
        public int TrainingScheduleId { get; set; }
        public int SpeakerId { get; set; }
        public string SessionName { get; set; }
        public string Topic { get; set; }
        public string Expectations { get; set; }
        public DateTime SessionDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        public Speaker Speaker { get; set; }
        public TrainingSchedule TrainingSchedule { get; set; }
    }
}
