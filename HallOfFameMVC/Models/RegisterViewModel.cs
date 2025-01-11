using System.ComponentModel.DataAnnotations;

namespace HallOfFameMVC.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "UserID is required")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "TeamName is required")]
        public string TeamName { get; set; }
        public bool SubmissionRights { get; set; }
        public bool ReviewRights { get; set; }
    }
}
