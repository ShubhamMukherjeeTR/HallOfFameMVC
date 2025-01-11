using HallOfFameMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HallOfFameMVC.Controllers
{
    public class SubmissionController : Controller
    {
        public IActionResult LoadSubmissionPage(UserDetailsViewModel userDetails)
        {
            return View("Submission", userDetails);
        }
    }
}
