using System.ComponentModel.DataAnnotations;

namespace Academy.ViewModels.ApplicationVm
{
    public class AcademicQualificationVm
    {
        public int AcademicQualificationId { get; set; }
        public string ApplicantId { get; set; }

        [Display(Name = "Institution Attended")]
        [Required]
        public string InstitutionName { get; set; }

        [Display(Name = "Awarded Degree")]
        [Required]
        public string AwardedDegree { get; set; }

        [Display(Name = "Year Obtained")]
        [Required]
        public int YearObtained { get; set; }
    }
}
