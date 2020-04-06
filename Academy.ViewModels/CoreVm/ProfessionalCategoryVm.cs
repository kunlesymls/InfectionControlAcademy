using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Academy.ViewModels.CoreVm
{
    public class ProfessionalCategoryVm
    {
        public int ProfessionalCategoryId { get; set; }

        [Display(Name = "Professional Code")]
        [Required]
        public string ProfessionalCode { get; set; }

        [Display(Name = "Professional Name")]
        [Required]
        public string ProfessionalName { get; set; }

        [Display(Name = "Is Visible")]
        public bool IsVisible { get; set; }
    }
}
