using System;
using System.ComponentModel.DataAnnotations;

namespace Academy.ViewModels.ApplicationVm
{
    public class WorkingExperienceVm
    {
        public int WorkingExperienceId { get; set; }
        public string ApplicantId { get; set; }

        [Display(Name = "Organization")]
        [Required]
        public string Organization { get; set; }

        [Display(Name = "Role in Organization")]
        [Required]
        public string Role { get; set; }

        [Display(Name = "Location")]
        [Required]
        public string Location { get; set; }

        [Display(Name = "Is Current Employer")]
        public bool IsCurrent { get; set; }

        [Display(Name = "Employment Type")]
        [Required]
        public string EmploymentType { get; set; }

        [Display(Name = "From Date")]
        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }

        [Display(Name = "To Date")]
        [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }
    }
}
