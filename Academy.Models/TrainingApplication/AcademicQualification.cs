using Academy.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;

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
