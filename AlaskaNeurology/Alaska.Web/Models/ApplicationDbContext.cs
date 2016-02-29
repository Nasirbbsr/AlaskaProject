using Alaska.Model.DataModel;
using System.Data.Entity;

namespace Alaska.Web.Models
{
    public class ApplicationDbContext : DbContext//DbIdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<People> People { get; set; }
    }
}
