using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpendingManagement.Data.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LimitMoney = table.Column<long>(type: "bigint", nullable: false, defaultValue: 10000000000L),
                    UnitTime = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenditures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: ""),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenditures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenditures_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenditures_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), "", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), 0, "3dec58e8-9430-4f73-b2dd-d9c9e849c7bc", new DateTime(2022, 11, 30, 12, 36, 58, 499, DateTimeKind.Local).AddTicks(4924), "leminhloi@gmail.com", true, 2, false, null, "Lee Minh Loij", "LEMINHLOI@GMAIL.COM", "LEMINHLOI", "AQAAAAEAACcQAAAAECzuBw4SP+dUMp4v0hV0WDsggYPiy2zV7RSA0VjKyBNhq19D1r4GTslPYTYOTjfqrQ==", "0948123432", true, "", "", false, "leminhloi" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "LinkIcon", "Name", "TypeOfCategory" },
                values: new object[,]
                {
                    { new Guid("13df1094-249b-442e-9877-34b7d6bb67f6"), "Tiền cho thuê", null, "Tiền cho thuê", 0 },
                    { new Guid("64a74972-0fcb-4c1f-9423-e7476cd7d73b"), "Tiền để đi đổ xăng", null, "Tiền xăng", 1 },
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), "Tiền mua đồ ăn này nọ", null, "Tiền ăn", 1 },
                    { new Guid("74fa08d6-5f84-4722-a274-87fa9a223c05"), "Tiền mua sắm cho sinh hoạt", null, "Tiền mua sắm", 1 },
                    { new Guid("7a980fa3-1905-4d9f-9fb3-1b154d6dab0e"), "", null, "Quà tặng", 0 },
                    { new Guid("920d7974-62a7-4490-8a4c-263947584c7c"), "Tiền lương", null, "Tiền lương", 0 },
                    { new Guid("b68c1556-d198-44bb-8200-f9a0f8ec576a"), "", null, "Kinh doanh", 0 },
                    { new Guid("e0981d40-787e-4fa6-9a10-8a59cb2b7b9b"), "Khác với những cái ở trên", null, "Khác", 0 },
                    { new Guid("eea2a6b9-a8e4-4d6f-a435-3c7cb5ce4638"), "Khác với những cái ở trên", null, "Khác", 1 },
                    { new Guid("f458a439-20c7-4a98-85e4-77459cb51dab"), "Tiền để thuê nhà này nọ", null, "Tiền nhà", 1 }
                });

            migrationBuilder.InsertData(
                table: "Expenditures",
                columns: new[] { "Id", "AppUserId", "CategoryId", "Cost", "DateCreate", "Note" },
                values: new object[] { new Guid("2784bc9c-2dc9-40de-bc87-af5797a2cb08"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 10000L, new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.InsertData(
                table: "Expenditures",
                columns: new[] { "Id", "AppUserId", "CategoryId", "Cost", "DateCreate", "Note" },
                values: new object[] { new Guid("2d397fa1-5739-4639-a3e6-ff45d5993216"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 20000L, new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.InsertData(
                table: "Expenditures",
                columns: new[] { "Id", "AppUserId", "CategoryId", "Cost", "DateCreate", "Note" },
                values: new object[] { new Guid("d55a36a4-a592-49d4-abb4-97be4f6932fe"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 100000L, new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_AppUserId",
                table: "Budgets",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_AppUserId",
                table: "Expenditures",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_CategoryId",
                table: "Expenditures",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Expenditures");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
