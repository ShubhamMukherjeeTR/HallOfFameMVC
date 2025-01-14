using HallOfFameMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HallOfFameMVC.Controllers
{
    public class TeamSubmissionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamSubmissionController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> TeamReviewPage()
        {
            var teamsubmissions = await _context.TeamSubmissions.ToListAsync();
            return View("TeamReview", teamsubmissions);
        }
    }
}
