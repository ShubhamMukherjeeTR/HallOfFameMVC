using HallOfFameMVC.Models;
using Microsoft.EntityFrameworkCore;

   namespace HallOfFameMVC.Data
   {
       public class ApplicationDbContext : DbContext
       {
           public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
               : base(options)
           {
           }

           public DbSet<EmployeeSubmissionViewModel> EmployeeSubmissions { get; set; }
           public DbSet<TeamSubmissionViewModel> TeamSubmissions { get; set; }
        }
   }
   