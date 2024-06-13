using Microsoft.EntityFrameworkCore;
using mvc.Common;

namespace mvc.Domains
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Khởi tạo dữ liệu mẫu
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "Admin", Address = "Long Biên" },
                new User { Id = 2, FullName = "Nhân viên CC01", Address = "Hà Đông" },
                new User { Id = 3, FullName = "Nhân viên SALE02", Address = "Hai Bà Trưng" },
                new User { Id = 4, FullName = "Nhân viên HR03", Address = "Thanh Xuân" });
            var salt = new Guid().ToString();
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Username = "admin", UserId = 1, PasswordHash = Utils.EncryptedPassword("123456", salt), PasswordSalt = salt },
                new Account { Id = 2, Username = "nv01", UserId = 2, PasswordHash = Utils.EncryptedPassword("123456", salt), PasswordSalt = salt },
                new Account { Id = 3, Username = "nv02", UserId = 3, PasswordHash = Utils.EncryptedPassword("123456", salt), PasswordSalt = salt },
                new Account { Id = 4, Username = "nv03", UserId = 4, PasswordHash = Utils.EncryptedPassword("123456", salt), PasswordSalt = salt });
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "ADMIN" },
                new Role { Id = 2, Name = "CONTENT CREATOR" },
                new Role { Id = 3, Name = "SALE" },
                new Role { Id = 4, Name = "HR" });
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, UserId = 1, RoleId = 1 },
                new UserRole { Id = 2, UserId = 2, RoleId = 2 },
                new UserRole { Id = 3, UserId = 3, RoleId = 3 },
                new UserRole { Id = 4, UserId = 4, RoleId = 4 });
            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = 1, Name = "Quản lý bán hàng", Path = "sale" },
                new Menu { Id = 2, Name = "Quản lý nội dung", Path = "content" },
                new Menu { Id = 3, Name = "Quản lý nhân sự", Path = "hr" },
                new Menu { Id = 4, Name = "Quản lý hệ thống", Path = "system" },
                new Menu { Id = 5, Name = "Menu", Path = "menu", ParentId = 4 },
                new Menu { Id = 6, Name = "Quyền", Path = "role", ParentId = 4 },
                new Menu { Id = 7, Name = "Quyền", Path = "permission", ParentId = 4 });
            modelBuilder.Entity<RoleMenu>().HasData(
                new RoleMenu { Id = 1, RoleId = 1, MenuId = 1 },
                new RoleMenu { Id = 2, RoleId = 1, MenuId = 2 },
                new RoleMenu { Id = 3, RoleId = 1, MenuId = 3 },
                new RoleMenu { Id = 4, RoleId = 1, MenuId = 4 },
                new RoleMenu { Id = 5, RoleId = 2, MenuId = 2 },
                new RoleMenu { Id = 6, RoleId = 3, MenuId = 1 },
                new RoleMenu { Id = 7, RoleId = 4, MenuId = 3 });
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }
        public DbSet<Account> Account { get; set; }
    }
}
