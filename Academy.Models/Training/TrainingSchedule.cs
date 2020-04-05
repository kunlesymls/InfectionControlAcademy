using Academy.Models.Core;
using Academy.Models.TrainingApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models.Training
{
    public class TrainingSchedule : Audit
    {
        public int TrainingScheduleId { get; set; }
        public int TraningTypeId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public string AdditionalInformation { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Fee { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal RefundFee { get; set; }
        public bool HasCertificate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TraningType TraningType { get; set; }
        public ICollection<TrainingSession> TrainingSessions { get; set; }
        public ICollection<ApplicantSchedule> ApplicantSchedules { get; set; }
    }
}
