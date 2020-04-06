using System.ComponentModel.DataAnnotations;

namespace Academy.ViewModels.TraningVm
{
    public class SessionSpeakerVm
    {
        public int SessionSpeakerId { get; set; }

        [Display(Name = "Training Session")]
        [Required]
        public int TrainingSessionId { get; set; }

        [Display(Name = "Speaker Name")]
        [Required]
        public int SpeakerId { get; set; }

        [Display(Name = "Is Lead Speaker?")]
        public bool IsLeadSpeaker { get; set; }
        public string SpeakerName { get; set; }
        public string TrainingSessionName { get; set; }

    }
}
