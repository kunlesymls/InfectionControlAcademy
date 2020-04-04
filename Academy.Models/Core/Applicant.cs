using Academy.Models.TrainingApplication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academy.Models.Core
{
    public class Applicant : Person
    {
        [Key]
        public string ApplicantId { get; set; }
        public int ProfessionalCategoryId { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseAuthority { get; set; }
        public bool IsLicenseVerified { get; set; }       
        public ProfessionalCategory ProfessionalCategory { get; set; }
        public ICollection<AcademicQualification> AcademicQualifications { get; set; }
        public ICollection<WorkingExperience> WorkingExperiences { get; set; }
        public ICollection<ApplicantSchedule> ApplicantSchedules { get; set; }
    }

    
}
