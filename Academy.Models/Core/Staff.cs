using System.ComponentModel.DataAnnotations;

namespace Academy.Models.Core
{
    public class Staff : Person
    {
        [Key]
        public string StaffId { get; set; }
    }
}
