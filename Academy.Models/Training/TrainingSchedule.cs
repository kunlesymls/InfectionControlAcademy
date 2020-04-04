using System;
using System.Collections.Generic;

namespace Academy.Models.Training
{
    public class TrainingSchedule
    {
        public int TrainingScheduleId { get; set; }
        public int TraningTypeId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TraningType TraningType { get; set; }
        public ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}
