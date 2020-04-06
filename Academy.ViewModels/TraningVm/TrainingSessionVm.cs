using System;
using System.ComponentModel.DataAnnotations;

namespace Academy.ViewModels.TraningVm
{
    public class TrainingSessionVm
    {
        public int TrainingSessionId { get; set; }

        [Display(Name = "Training Schedule")]
        [Required]
        public int TrainingScheduleId { get; set; }

        [Display(Name = "Session Name")]
        [Required]
        public string SessionName { get; set; }

        [Display(Name = "Topic")]
        [Required]
        public string Topic { get; set; }

        [Display(Name = "Expectations")]
        [Required]
        public string Expectations { get; set; }

        [Display(Name = "Location")]
        [Required]
        public string Location { get; set; }

        [Display(Name = "Duration (Hrs)")]
        public int Duration { get; set; }

        [Display(Name = "Session Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime SessionDate { get; set; }

        [Display(Name = "Start Time")]
        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Display(Name = "Is Activated?")]
        public bool IsActive { get; set; }
        public string TrainingScheduleName { get; set; }
    }
}
