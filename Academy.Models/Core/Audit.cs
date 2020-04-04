using System;

namespace Academy.Models.Core
{
    public abstract class Audit
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
