﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvc.Domains;

#nullable disable

namespace mvc.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("mvc.Domains.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("passwordhash");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("passwordsalt");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userId");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("account");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = "76EFBFBD2D5CEFBFBD375A7402EFBFBDD9AF2FEFBFBDEFBFBD43EFBFBDEFBFBDEFBFBDDBBB033FEFBFBD48EFBFBD2E40EFBFBD09EFBFBD06",
                            PasswordSalt = "00000000-0000-0000-0000-000000000000",
                            UserId = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            PasswordHash = "76EFBFBD2D5CEFBFBD375A7402EFBFBDD9AF2FEFBFBDEFBFBD43EFBFBDEFBFBDEFBFBDDBBB033FEFBFBD48EFBFBD2E40EFBFBD09EFBFBD06",
                            PasswordSalt = "00000000-0000-0000-0000-000000000000",
                            UserId = 2,
                            Username = "nv01"
                        },
                        new
                        {
                            Id = 3,
                            PasswordHash = "76EFBFBD2D5CEFBFBD375A7402EFBFBDD9AF2FEFBFBDEFBFBD43EFBFBDEFBFBDEFBFBDDBBB033FEFBFBD48EFBFBD2E40EFBFBD09EFBFBD06",
                            PasswordSalt = "00000000-0000-0000-0000-000000000000",
                            UserId = 3,
                            Username = "nv02"
                        },
                        new
                        {
                            Id = 4,
                            PasswordHash = "76EFBFBD2D5CEFBFBD375A7402EFBFBDD9AF2FEFBFBDEFBFBD43EFBFBDEFBFBDEFBFBDDBBB033FEFBFBD48EFBFBD2E40EFBFBD09EFBFBD06",
                            PasswordSalt = "00000000-0000-0000-0000-000000000000",
                            UserId = 4,
                            Username = "nv03"
                        });
                });

            modelBuilder.Entity("mvc.Domains.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("parentId");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("path");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("menu");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Quản lý bán hàng",
                            Path = "sale"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Quản lý nội dung",
                            Path = "content"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Quản lý nhân sự",
                            Path = "hr"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Quản lý hệ thống",
                            Path = "system"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Menu",
                            ParentId = 4,
                            Path = "menu"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Quyền",
                            ParentId = 4,
                            Path = "role"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Quyền",
                            ParentId = 4,
                            Path = "permission"
                        });
                });

            modelBuilder.Entity("mvc.Domains.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            Name = "CONTENT CREATOR"
                        },
                        new
                        {
                            Id = 3,
                            Name = "SALE"
                        },
                        new
                        {
                            Id = 4,
                            Name = "HR"
                        });
                });

            modelBuilder.Entity("mvc.Domains.RoleMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuId")
                        .HasColumnType("int")
                        .HasColumnName("menuId");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("roleId");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.ToTable("role_menu");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            MenuId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 3,
                            MenuId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 4,
                            MenuId = 4,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 5,
                            MenuId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 6,
                            MenuId = 1,
                            RoleId = 3
                        },
                        new
                        {
                            Id = 7,
                            MenuId = 3,
                            RoleId = 4
                        });
                });

            modelBuilder.Entity("mvc.Domains.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("full_name");

                    b.HasKey("Id");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Long Biên",
                            FullName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Hà Đông",
                            FullName = "Nhân viên CC01"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Hai Bà Trưng",
                            FullName = "Nhân viên SALE02"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Thanh Xuân",
                            FullName = "Nhân viên HR03"
                        });
                });

            modelBuilder.Entity("mvc.Domains.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("roleId");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("user_role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            RoleId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            RoleId = 3,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            RoleId = 4,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("mvc.Domains.Account", b =>
                {
                    b.HasOne("mvc.Domains.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("mvc.Domains.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("mvc.Domains.Menu", b =>
                {
                    b.HasOne("mvc.Domains.Menu", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("mvc.Domains.RoleMenu", b =>
                {
                    b.HasOne("mvc.Domains.Menu", "Menu")
                        .WithMany("RoleMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mvc.Domains.Role", "Role")
                        .WithMany("RoleControllers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("mvc.Domains.UserRole", b =>
                {
                    b.HasOne("mvc.Domains.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mvc.Domains.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("mvc.Domains.Menu", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("RoleMenus");
                });

            modelBuilder.Entity("mvc.Domains.Role", b =>
                {
                    b.Navigation("RoleControllers");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("mvc.Domains.User", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
