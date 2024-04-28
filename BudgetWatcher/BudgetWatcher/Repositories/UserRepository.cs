using BudgetWatcher.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWatcher.Repositories
{
    class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser = false;

            using (var connection = GetConnection())
            using (var command = new SQLiteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT Password, Salt FROM [Users] WHERE Username = @username";
                command.Parameters.AddWithValue("@username", credential.UserName);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string? hashedPasswordFromDB = reader.IsDBNull(0) ? null : reader.GetString(0); // Assuming password column is at index 0
                        string? saltFromDB = reader.IsDBNull(1) ? null : reader.GetString(1); // Assuming salt column is at index 1

                        if (hashedPasswordFromDB != null && saltFromDB != null)
                        {
                            string hashedPasswordToCheck = PasswordHasher.HashPassword(credential.SecurePassword, saltFromDB);
                            validUser = hashedPasswordFromDB == hashedPasswordToCheck;
                        }
                    }
                }
            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetbyAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetbyUsername(string username)
        {
            UserModel user = null;

            using (var connection = GetConnection())
            {
                using (var command = new SQLiteCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select * from [Users] where Username=@username";
                    command.Parameters.AddWithValue("@username", username);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new UserModel()
                            {
                                Id = reader.GetInt32(0),
                                AccessLevel = reader.GetInt32(1),
                                Username = reader.GetString(2),
                                Password = string.Empty,
                            };
                        }
                    }
                }
                return user;
            }

        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

    }
}
