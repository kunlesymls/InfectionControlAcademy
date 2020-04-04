using Academy.Models.Core;

using System;

namespace Academy.Models.TrainingApplication
{
    public class WorkingExperience
    {
        public int WorkingExperienceId { get; set; }
        public string ApplicantId { get; set; }
        public string Organization { get; set; }
        public string Rank { get; set; }
        public string Location { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public Applicant Applicant { get; set; }
    }
}
