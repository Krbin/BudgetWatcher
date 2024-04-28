using System;
using Microsoft.EntityFrameworkCore.Migrations;
using BudgetWatcher.Models;
using System.Security;

#nullable disable

namespace BudgetWatcher.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccessLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Salt = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastAccessDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_Salt", x => x.Salt);
                });

            string saltBase64 = PasswordHasher.GenerateSaltBase64();
            SecureString defaultPassword = new SecureString();

            foreach (char c in "password") // Change "default_password" to your desired default password
            {
                defaultPassword.AppendChar(c);
            }
            defaultPassword.MakeReadOnly();

            string hashedPassword = PasswordHasher.HashPassword(defaultPassword, saltBase64);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AccessLevel", "Username", "Password", "Salt", "CreationDate", "LastAccessDate" },
                values: new object[] { 0, "admin", hashedPassword, saltBase64, DateTime.UtcNow, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
