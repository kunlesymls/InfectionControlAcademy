using Academy.Models.Core;
using Academy.Models.Training;
using System;

namespace Academy.Models.TrainingApplication
{
    public class ApplicantSchedule : Audit
    {
        public int ApplicantScheduleId { get; set; }
        public string ApplicantId { get; set; }
        public int TrainingScheduleId { get; set; }
        public bool IsQualified { get; set; }
        public bool HasPaid { get; set; }
        public bool HasCompletedSchedule { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime DateCompleted { get; set; }
        public bool IsRefunded { get; set; }
        public bool IsSuspended { get; set; }
        public string GeneralComment { get; set; }
        public Applicant Applicant { get; set; }
        public TrainingSchedule TrainingSchedule { get; set; }
    }
}
