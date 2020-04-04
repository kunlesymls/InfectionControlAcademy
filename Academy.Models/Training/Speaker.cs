using Academy.Models.Core;
using System.Collections.Generic;

namespace Academy.Models.Training
{
    public class Speaker : Person
    {
        public int SpeakerId { get; set; }
        public string Title { get; set; }
        public string Honours { get; set; }
        public ICollection<SessionSpeaker> SessionSpeakers { get; set; }
    }
}
