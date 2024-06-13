using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mvc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_parentId",
                        column: x => x.parentId,
                        principalTable: "Menu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    menuId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenu", x => x.id);
                    table.ForeignKey(
                        name: "FK_RoleMenu_Menu_menuId",
                        column: x => x.menuId,
                        principalTable: "Menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleMenu_Role_roleId",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordhash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordsalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.id);
                    table.ForeignKey(
                        name: "FK_Account_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_roleId",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "id", "CreatedBy", "CreatedDate", "IsDeleted", "name", "parentId", "path", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(558), false, "Quản lý bán hàng", null, "sale", null, null },
                    { 2, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(559), false, "Quản lý nội dung", null, "content", null, null },
                    { 3, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(561), false, "Quản lý nhân sự", null, "hr", null, null },
                    { 4, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(562), false, "Quản lý hệ thống", null, "system", null, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "id", "CreatedBy", "CreatedDate", "IsDeleted", "name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(504), false, "ADMIN", null, null },
                    { 2, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(506), false, "CONTENT CREATOR", null, null },
                    { 3, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(507), false, "SALE", null, null },
                    { 4, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(508), false, "HR", null, null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "address", "CreatedBy", "CreatedDate", "full_name", "IsDeleted", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Long Biên", "System", new DateTime(2024, 6, 14, 0, 11, 1, 53, DateTimeKind.Local).AddTicks(9753), "Admin", false, null, null },
                    { 2, "Hà Đông", "System", new DateTime(2024, 6, 14, 0, 11, 1, 53, DateTimeKind.Local).AddTicks(9766), "Nhân viên CC01", false, null, null },
                    { 3, "Hai Bà Trưng", "System", new DateTime(2024, 6, 14, 0, 11, 1, 53, DateTimeKind.Local).AddTicks(9767), "Nhân viên SALE02", false, null, null },
                    { 4, "Thanh Xuân", "System", new DateTime(2024, 6, 14, 0, 11, 1, 53, DateTimeKind.Local).AddTicks(9768), "Nhân viên HR03", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "id", "CreatedBy", "CreatedDate", "IsDeleted", "passwordhash", "passwordsalt", "UpdatedBy", "UpdatedDate", "userId", "username" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(256), false, "76EFBFBD2D5CEFBFBD375A7402EFBFBDD9AF2FEFBFBDEFBFBD43EFBFBDEFBFBDEFBFBDDBBB033FEFBFBD48EFBFBD2E40EFBFBD09EFBFBD06", "00000000-0000-0000-0000-000000000000", null, null, 1, "admin" },
                    { 2, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(358), false, "76EFBFBD2D5CEFBFBD375A7402EFBFBDD9AF2FEFBFBDEFBFBD43EFBFBDEFBFBDEFBFBDDBBB033FEFBFBD48EFBFBD2E40EFBFBD09EFBFBD06", "00000000-0000-0000-0000-000000000000", null, null, 2, "nv01" },
                    { 3, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(397), false, "76EFBFBD2D5CEFBFBD375A7402EFBFBDD9AF2FEFBFBDEFBFBD43EFBFBDEFBFBDEFBFBDDBBB033FEFBFBD48EFBFBD2E40EFBFBD09EFBFBD06", "00000000-0000-0000-0000-000000000000", null, null, 3, "nv02" },
                    { 4, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(437), false, "76EFBFBD2D5CEFBFBD375A7402EFBFBDD9AF2FEFBFBDEFBFBD43EFBFBDEFBFBDEFBFBDDBBB033FEFBFBD48EFBFBD2E40EFBFBD09EFBFBD06", "00000000-0000-0000-0000-000000000000", null, null, 4, "nv03" }
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "id", "CreatedBy", "CreatedDate", "IsDeleted", "name", "parentId", "path", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 5, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(565), false, "Menu", 4, "menu", null, null },
                    { 6, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(567), false, "Quyền", 4, "role", null, null },
                    { 7, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(568), false, "Quyền", 4, "permission", null, null }
                });

            migrationBuilder.InsertData(
                table: "RoleMenu",
                columns: new[] { "id", "CreatedBy", "CreatedDate", "IsDeleted", "menuId", "roleId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(595), false, 1, 1, null, null },
                    { 2, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(597), false, 2, 1, null, null },
                    { 3, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(598), false, 3, 1, null, null },
                    { 4, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(599), false, 4, 1, null, null },
                    { 5, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(601), false, 2, 2, null, null },
                    { 6, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(602), false, 1, 3, null, null },
                    { 7, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(603), false, 3, 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "id", "CreatedBy", "CreatedDate", "IsDeleted", "roleId", "UpdatedBy", "UpdatedDate", "userId" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(532), false, 1, null, null, 1 },
                    { 2, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(533), false, 2, null, null, 2 },
                    { 3, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(534), false, 3, null, null, 3 },
                    { 4, "System", new DateTime(2024, 6, 14, 0, 11, 1, 54, DateTimeKind.Local).AddTicks(535), false, 4, null, null, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_userId",
                table: "Account",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_parentId",
                table: "Menu",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_menuId",
                table: "RoleMenu",
                column: "menuId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_roleId",
                table: "RoleMenu",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_roleId",
                table: "UserRole",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_userId",
                table: "UserRole",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "RoleMenu");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
