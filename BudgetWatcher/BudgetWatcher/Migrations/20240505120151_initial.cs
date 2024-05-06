using System;
using System.Security;
using BudgetWatcher.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetWatcher.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Recipient = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfTransaction = table.Column<DateTime>(type: "TEXT", nullable: true),
                    wasSend = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revenues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sender = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfTransaction = table.Column<DateTime>(type: "TEXT", nullable: true),
                    wasReceived = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenues", x => x.Id);
                });

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
                    LastAccessDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExpenseModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    RevenueModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_Salt", x => x.Salt);
                    table.ForeignKey(
                        name: "FK_Users_Expenses_ExpenseModelId",
                        column: x => x.ExpenseModelId,
                        principalTable: "Expenses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Revenues_RevenueModelId",
                        column: x => x.RevenueModelId,
                        principalTable: "Revenues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ExpenseModelId",
                table: "Users",
                column: "ExpenseModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RevenueModelId",
                table: "Users",
                column: "RevenueModelId");

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
                name: "Balances");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Revenues");
        }
    }
}
