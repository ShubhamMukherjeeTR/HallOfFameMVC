using System.ComponentModel.DataAnnotations;

namespace HallOfFameMVC.Models
{
    public class EmployeeSubmissionViewModel
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Location { get; set; }
        public string NominatingManagerName { get; set; }
        public string LeadershipMember { get; set; }
        public string OKR { get; set; }
        public int ReviewScore { get; set; }
        public string ReviewComment { get; set; }
    }
}
