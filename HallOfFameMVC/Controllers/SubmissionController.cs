using HallOfFameMVC.Data;
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

        public async Task<IActionResult> SubmitSubmissionValues(UserDetailsViewModel model, string NominationType, string Location, string TimePeriod, string Period, string OKR2025, string LeadershipMember, string EmployeeID, string EmployeeName, string EmployeeDesignation, string EmployeeTeam, string TeamID, string SubmissionTeamName)
        {
            var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

            ExecuteProcedure executeProcedure = new ExecuteProcedure(configuration);

            bool issubmitted = false;

            if (NominationType == "Individual")
            {
                issubmitted = await executeProcedure.InsertIndividualSubmission(model, NominationType, Location, TimePeriod, Period, OKR2025, LeadershipMember, EmployeeID, EmployeeName, EmployeeDesignation, EmployeeTeam);
                string message = "Individual Submission submitted successfully.";
                ViewData["Message"] = message;
                return View("~/Views/Home/Index.cshtml");

            }
            else if (NominationType == "Team Award")
            {
                issubmitted = await executeProcedure.InsertTeamSubmission(model, NominationType, Location, TimePeriod, Period, OKR2025, LeadershipMember, TeamID, SubmissionTeamName);
                string message = "Team Submission submitted successfully.";
                ViewData["Message"] = message;
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                string message = "Invalid Nomination Type. Please check the drop down carefully.";
                ViewData["Message"] = message;
                return View("~/Views/Home/Index.cshtml");
            }
        }
    }
}
