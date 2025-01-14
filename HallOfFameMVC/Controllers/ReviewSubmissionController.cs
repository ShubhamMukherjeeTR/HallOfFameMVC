using HallOfFameMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HallOfFameMVC.Controllers
{
    public class ReviewSubmissionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewSubmissionController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ReviewSubmissionPage()
        {
            var submissions = await _context.EmployeeSubmissions.ToListAsync();
            return View("ReviewSubmission", submissions);
        }
    }
}
