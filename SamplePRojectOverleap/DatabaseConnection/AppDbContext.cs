

using Microsoft.EntityFrameworkCore;

namespace SamplePRojectOverleap.DatabaseConnection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-RF1FS0ES;Database=EFGetStarted;Trusted_Connection=True;");
            }
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        public DbSet<TblClass> TblClasses { get; set; }
        public DbSet<TblSeller> TblSellers { get; set; }
        public DbSet<TblProducts> TblProducts { get; set; }
        public DbSet<TblEmployee> TblEmployees { get; set; }
    }
}
