using System.Collections.Generic;

namespace Academy.Models.Training
{
    public class Speaker
    {
        public int SpeakerId { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string ShortBio { get; set; }
        public byte[] Image { get; set; }
        public ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}
