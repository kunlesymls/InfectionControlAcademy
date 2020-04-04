using System.Collections.Generic;

namespace Academy.Models.Core
{
    public class ProfessionalCategory : Audit
    {
        public int ProfessionalCategoryId { get; set; }
        public string ProfessionalCode { get; set; }
        public string ProfessionalName { get; set; }
        public bool IsVisible { get; set; }
        public ICollection<Applicant> Applicants { get; set; }
    }
}
