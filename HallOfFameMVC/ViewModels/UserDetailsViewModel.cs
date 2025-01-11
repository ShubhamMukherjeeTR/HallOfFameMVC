namespace HallOfFameMVC.ViewModels
{
    public class UserDetailsViewModel
    {
        public int LoginNo { get; set; }
        public string LoginName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TeamName { get; set; }
        public bool SubmissionRights { get; set; }
        public bool ReviewRights { get; set; }
        public bool AdminRights { get; set; }

    }
}
