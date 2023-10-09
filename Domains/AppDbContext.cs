using Microsoft.EntityFrameworkCore;

namespace mvc.Domains
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<AppController> Controllers { get; set; }
        public DbSet<RoleController> RoleControllers { get; set; }
        public DbSet<AppAction> Actions { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
