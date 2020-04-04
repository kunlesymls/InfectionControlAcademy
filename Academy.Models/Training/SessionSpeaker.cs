namespace Academy.Models.Training
{
    public class SessionSpeaker
    {
        public int SessionSpeakerId { get; set; }
        public int TrainingSessionId { get; set; }
        public int SpeakerId { get; set; }
        public bool IsLeadSpeaker { get; set; }
        public Speaker Speaker { get; set; }
        public TrainingSession TrainingSession { get; set; }

    }
}
