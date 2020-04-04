using Academy.Models.Core;

namespace Academy.Models.TrainingApplication
{
    public class AcademicQualification
    {
        public int AcademicQualificationId { get; set; }
        public string ApplicantId { get; set; }
        public string InstitutionName { get; set; }
        public string AwardedDegree { get; set; }
        public int YearObtained { get; set; }
        public Applicant Applicant { get; set; }
    }
}
