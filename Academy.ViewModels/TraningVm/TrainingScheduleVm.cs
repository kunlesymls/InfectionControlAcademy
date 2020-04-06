using System;
using System.ComponentModel.DataAnnotations;

namespace Academy.ViewModels.TraningVm
{
    public class TrainingScheduleVm
    {
        public int TrainingScheduleId { get; set; }

        [Display(Name = "Training Type")]
        [Required]
        public int TraningTypeId { get; set; }

        [Display(Name = "Subject")]
        [Required]
        public string Subject { get; set; }

        [Display(Name = "Subject Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Venue")]
        [Required]
        public string Venue { get; set; }

        [Display(Name = "Additional Information")]
        public string AdditionalInformation { get; set; }

        [Display(Name = "Training Fee")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal Fee { get; set; }

        [Display(Name = "Refundable Fee")]
        public decimal RefundFee { get; set; }

        [Display(Name = "Has Certificate?")]
        public bool HasCertificate { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string TraningTypeName { get; set; }
    }
}
