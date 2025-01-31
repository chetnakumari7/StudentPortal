using Microsoft.EntityFrameworkCore;
using StudentPortal.Data.Models.Entities;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        { 
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<BankDetails> BankDetails { get; set; }
        // public Dbset< model class> table name {get;set}
    }
}
