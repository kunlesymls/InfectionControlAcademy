using Academy.Models.Core;

namespace Academy.Models.Training
{
    public class SessionSpeaker : Audit
    {
        public int SessionSpeakerId { get; set; }
        public int TrainingSessionId { get; set; }
        public int SpeakerId { get; set; }
        public bool IsLeadSpeaker { get; set; }
        public Speaker Speaker { get; set; }
        public TrainingSession TrainingSession { get; set; }

    }
}
