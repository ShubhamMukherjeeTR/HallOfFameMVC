using HallOfFameMVC.Data;
using HallOfFameMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Diagnostics;

namespace HallOfFameMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAllLoginTableData()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            ExecuteProcedure executeProcedure = new ExecuteProcedure(configuration);
            DataTable dataTable = await executeProcedure.GetAllLoginTableData();
            // Convert DataTable to JSON or any other format as needed
            return Json(dataTable);
        }
    }
}
