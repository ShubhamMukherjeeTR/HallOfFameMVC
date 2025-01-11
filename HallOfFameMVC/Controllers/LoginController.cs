using HallOfFameMVC.Data;
using HallOfFameMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Web;

namespace HallOfFameMVC.Controllers
{
    public class LoginController : Controller
    {
        public static DataRow userDetails { get; set; }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> LoginExistingUser(string username, string password)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                // Call the stored procedure to check if the user exists
                ExecuteProcedure executeProcedure = new ExecuteProcedure(configuration);
                DataTable dataTable = await executeProcedure.VerifyLoginCredentials(username, password);

                // If the user exists, redirect to the home page
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    // Assigning data to userDetails
                    userDetails = dataTable.Rows[0];

                    if (userDetails.Field<string>("UserName") == username && userDetails.Field<string>("Password") == password)
                    {
                        // You can now use the userId or other values as needed
                        ViewData["userDetails"] = userDetails;
                        return View("~/Views/Home/Index.cshtml");
                    }
                    else
                    {
                        // If the user does not exist, send alert message in same page
                        string message = "Invalid username or password. Please try again.";
                        ViewData["Message"] = message;
                    }
                }
                return View("Login");
            }
            catch (Exception)
            {
                // If an exception occurs, send alert message in same page
                string message = "An error occurred while processing your request. Please try again.";
                ViewData["Message"] = message;
                return View("Login");
            }
        }

        public async Task<IActionResult> CreateNewUser(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }
            try
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                // Call the stored procedure to check if the user exists
                ExecuteProcedure executeProcedure = new ExecuteProcedure(configuration);
                DataTable dataTable = await executeProcedure.InsertLoginCredentials(model.UserID,
                    model.LoginName,
                    model.UserEmail,
                    model.Password,
                    model.TeamName,
                    model.SubmissionRights,
                    model.ReviewRights);

                // If the user is successfully created, redirect to the login page
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    TempData["Message"] = "User registered successfully.";
                    return RedirectToAction("Login");
                }
                else
                {
                    // If the user creation fails, send alert message in the same page
                    string message = "User creation failed. Please try again.";
                    ViewData["Message"] = message;
                    return View("Register", model);
                }

            }
            catch (Exception)
            {
                // If an exception occurs, send alert message in same page
                string message = "An error occurred while processing your request. Please try again.";
                ViewData["Message"] = message;
                return View("Register");
            }
        }
    }
}
