using Microsoft.EntityFrameworkCore;
using mvc.Domain;
using mvc.Infrastructure.Helpers;

namespace mvc.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Khởi tạo dữ liệu mẫu
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "Admin", Address = "Long Biên", CreatedBy = "System", CreatedDate = DateTime.Now },
                new User { Id = 2, FullName = "Nhân viên CC01", Address = "Hà Đông", CreatedBy = "System", CreatedDate = DateTime.Now },
                new User { Id = 3, FullName = "Nhân viên SALE02", Address = "Hai Bà Trưng", CreatedBy = "System", CreatedDate = DateTime.Now },
                new User { Id = 4, FullName = "Nhân viên HR03", Address = "Thanh Xuân", CreatedBy = "System", CreatedDate = DateTime.Now });
            var salt = new Guid().ToString();
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Username = "admin", UserId = 1, PasswordHash = Utils.EncryptedPassword("123456", salt), PasswordSalt = salt, CreatedBy = "System", CreatedDate = DateTime.Now },
                new Account { Id = 2, Username = "nv01", UserId = 2, PasswordHash = Utils.EncryptedPassword("123456", salt), PasswordSalt = salt, CreatedBy = "System", CreatedDate = DateTime.Now },
                new Account { Id = 3, Username = "nv02", UserId = 3, PasswordHash = Utils.EncryptedPassword("123456", salt), PasswordSalt = salt, CreatedBy = "System", CreatedDate = DateTime.Now },
                new Account { Id = 4, Username = "nv03", UserId = 4, PasswordHash = Utils.EncryptedPassword("123456", salt), PasswordSalt = salt, CreatedBy = "System", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "ADMIN", CreatedBy = "System", CreatedDate = DateTime.Now },
                new Role { Id = 2, Name = "CONTENT CREATOR", CreatedBy = "System", CreatedDate = DateTime.Now },
                new Role { Id = 3, Name = "SALE", CreatedBy = "System", CreatedDate = DateTime.Now },
                new Role { Id = 4, Name = "HR", CreatedBy = "System", CreatedDate = DateTime.Now });
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, UserId = 1, RoleId = 1, CreatedBy = "System", CreatedDate = DateTime.Now },
                new UserRole { Id = 2, UserId = 2, RoleId = 2, CreatedBy = "System", CreatedDate = DateTime.Now },
                new UserRole { Id = 3, UserId = 3, RoleId = 3, CreatedBy = "System", CreatedDate = DateTime.Now },
                new UserRole { Id = 4, UserId = 4, RoleId = 4, CreatedBy = "System", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = 1, Name = "Quản lý bán hàng", Path = "sale", CreatedBy = "System", CreatedDate = DateTime.Now },
                new Menu { Id = 2, Name = "Quản lý nội dung", Path = "content", CreatedBy = "System", CreatedDate = DateTime.Now },
                new Menu { Id = 3, Name = "Quản lý nhân sự", Path = "hr", CreatedBy = "System", CreatedDate = DateTime.Now },
                new Menu { Id = 4, Name = "Quản lý hệ thống", Path = "system", CreatedBy = "System", CreatedDate = DateTime.Now },
                new Menu { Id = 5, Name = "Menu", Path = "menu", ParentId = 4, CreatedBy = "System", CreatedDate = DateTime.Now },
                new Menu { Id = 6, Name = "Quyền", Path = "role", ParentId = 4, CreatedBy = "System", CreatedDate = DateTime.Now },
                new Menu { Id = 7, Name = "Quyền", Path = "permission", ParentId = 4, CreatedBy = "System", CreatedDate = DateTime.Now });
            modelBuilder.Entity<RoleMenu>().HasData(
                new RoleMenu { Id = 1, RoleId = 1, MenuId = 1, CreatedBy = "System", CreatedDate = DateTime.Now },
                new RoleMenu { Id = 2, RoleId = 1, MenuId = 2, CreatedBy = "System", CreatedDate = DateTime.Now },
                new RoleMenu { Id = 3, RoleId = 1, MenuId = 3, CreatedBy = "System", CreatedDate = DateTime.Now },
                new RoleMenu { Id = 4, RoleId = 1, MenuId = 4, CreatedBy = "System", CreatedDate = DateTime.Now },
                new RoleMenu { Id = 5, RoleId = 2, MenuId = 2, CreatedBy = "System", CreatedDate = DateTime.Now },
                new RoleMenu { Id = 6, RoleId = 3, MenuId = 1, CreatedBy = "System", CreatedDate = DateTime.Now },
                new RoleMenu { Id = 7, RoleId = 4, MenuId = 3, CreatedBy = "System", CreatedDate = DateTime.Now });
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }
        public DbSet<Account> Account { get; set; }
    }
}
