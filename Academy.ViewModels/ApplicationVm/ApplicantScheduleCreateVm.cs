using System;
using System.ComponentModel.DataAnnotations;

namespace Academy.ViewModels.ApplicationVm
{
    public class ApplicantScheduleCreateVm
    {
        public int ApplicantScheduleId { get; set; }
        public string ApplicantId { get; set; }

        [Display(Name = "Traning Schedule")]
        [Required]
        public int TrainingScheduleId { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public string ApplicantName { get; set; }
    }
}
