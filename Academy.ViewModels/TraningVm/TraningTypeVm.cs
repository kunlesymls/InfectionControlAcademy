using System.ComponentModel.DataAnnotations;

namespace Academy.ViewModels.TraningVm
{
    public class TraningTypeVm
    {
        public int TraningTypeId { get; set; }

        [Display(Name = "Training Code")]
        [Required]
        public string TraningCode { get; set; }

        [Display(Name = "Training Name")]
        [Required]
        public string TraningName { get; set; }
    }
}
