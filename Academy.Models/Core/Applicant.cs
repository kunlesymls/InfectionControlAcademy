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
        public bool IsQualifiedForTraining { get; set; }
        public bool HasCompletedTraining { get; set; }
        public ProfessionalCategory ProfessionalCategory { get; set; }
        public ICollection<AcademicQualification> AcademicQualifications { get; set; }
        public ICollection<WorkingExperience> WorkingExperiences { get; set; }

    }
}
