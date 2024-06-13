using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu", x => x.id);
                    table.ForeignKey(
                        name: "FK_menu_menu_parentId",
                        column: x => x.parentId,
                        principalTable: "menu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    menuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_role_menu_menu_menuId",
                        column: x => x.menuId,
                        principalTable: "menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_role_menu_role_roleId",
                        column: x => x.roleId,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordhash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordsalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.id);
                    table.ForeignKey(
                        name: "FK_account_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_role_role_roleId",
                        column: x => x.roleId,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_role_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "menu",
                columns: new[] { "id", "name", "parentId", "path" },
                values: new object[,]
                {
                    { 1, "Quản lý bán hàng", null, "sale" },
                    { 2, "Quản lý nội dung", null, "content" },
                    { 3, "Quản lý nhân sự", null, "hr" },
                    { 4, "Quản lý hệ thống", null, "system" }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "ADMIN" },
                    { 2, "CONTENT CREATOR" },
                    { 3, "SALE" },
                    { 4, "HR" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "address", "full_name" },
                values: new object[,]
                {
                    { 1, "Long Biên", "Admin" },
                    { 2, "Hà Đông", "Nhân viên CC01" },
                    { 3, "Hai Bà Trưng", "Nhân viên SALE02" },
                    { 4, "Thanh Xuân", "Nhân viên HR03" }
                });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "id", "passwordhash", "passwordsalt", "userId", "username" },
                values: new object[,]
                {
                    { 1, "76EFBFBD2D5CEFBFBD375A7402EFBFBDD9AF2FEFBFBDEFBFBD43EFBFBDEFBFBDEFBFBDDBBB033FEFBFBD48EFBFBD2E40EFBFBD09EFBFBD06", "00000000-0000-0000-0000-000000000000", 1, "admin" },
                    { 2, "76EFBFBD2D5CEFBFBD375A7402EFBFBDD9AF2FEFBFBDEFBFBD43EFBFBDEFBFBDEFBFBDDBBB033FEFBFBD48EFBFBD2E40EFBFBD09EFBFBD06", "00000000-0000-0000-0000-000000000000", 2, "nv01" },
                    { 3, "76EFBFBD2D5CEFBFBD375A7402EFBFBDD9AF2FEFBFBDEFBFBD43EFBFBDEFBFBDEFBFBDDBBB033FEFBFBD48EFBFBD2E40EFBFBD09EFBFBD06", "00000000-0000-0000-0000-000000000000", 3, "nv02" },
                    { 4, "76EFBFBD2D5CEFBFBD375A7402EFBFBDD9AF2FEFBFBDEFBFBD43EFBFBDEFBFBDEFBFBDDBBB033FEFBFBD48EFBFBD2E40EFBFBD09EFBFBD06", "00000000-0000-0000-0000-000000000000", 4, "nv03" }
                });

            migrationBuilder.InsertData(
                table: "menu",
                columns: new[] { "id", "name", "parentId", "path" },
                values: new object[,]
                {
                    { 5, "Menu", 4, "menu" },
                    { 6, "Quyền", 4, "role" },
                    { 7, "Quyền", 4, "permission" }
                });

            migrationBuilder.InsertData(
                table: "role_menu",
                columns: new[] { "Id", "menuId", "roleId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 2, 2 },
                    { 6, 1, 3 },
                    { 7, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "user_role",
                columns: new[] { "Id", "roleId", "userId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_userId",
                table: "account",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menu_parentId",
                table: "menu",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_role_menu_menuId",
                table: "role_menu",
                column: "menuId");

            migrationBuilder.CreateIndex(
                name: "IX_role_menu_roleId",
                table: "role_menu",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_roleId",
                table: "user_role",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_userId",
                table: "user_role",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "role_menu");

            migrationBuilder.DropTable(
                name: "user_role");

            migrationBuilder.DropTable(
                name: "menu");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
