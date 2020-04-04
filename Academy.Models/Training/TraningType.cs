using Academy.Models.Core;
using System.Collections.Generic;

namespace Academy.Models.Training
{
    public class TraningType : Audit
    {
        public int TraningTypeId { get; set; }
        public string TraningCode { get; set; }
        public string TraningName { get; set; }
        public ICollection<TrainingSchedule> TrainingSchedules { get; set; }        
    }
}
