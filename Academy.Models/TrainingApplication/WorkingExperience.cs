using Academy.Models.Core;

using System;

namespace Academy.Models.TrainingApplication
{
    public class WorkingExperience : Audit
    {
        public int WorkingExperienceId { get; set; }
        public string ApplicantId { get; set; }
        public string Organization { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        public bool IsCurrent { get; set; }
        public string EmploymentType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public Applicant Applicant { get; set; }
    }
}
