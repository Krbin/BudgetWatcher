using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWatcher.Models.DatabaseModels
{
    internal class GenerateDefaultSuperUser
    {

        private static void Create()
        {
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
        internal class migrationBuilder
        {
            internal static void InsertData(string table, string[] columns, object[] values) { }
        }
    }
}
