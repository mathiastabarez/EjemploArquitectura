using LogicaNegocio.Domain;
using LogicaNegocio.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public void Add(User user)
        {
            using var connection = CreateConnection();
            using var command = new SqlCommand(@"
                INSERT INTO Users (Username, Password, Name, Email, IsEnabled)
                VALUES (@Username, @Password, @Name, @Email, @IsEnabled)", connection);

            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@IsEnabled", user.IsEnabled);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public bool ExistsByUsername(string username)
        {
            using var connection = CreateConnection();
            using var command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username", connection);
            command.Parameters.AddWithValue("@Username", username);

            connection.Open();
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        public User? GetByUsername(string username)
        {
            using var connection = CreateConnection();
            using var command = new SqlCommand("SELECT * FROM Users WHERE Username = @Username", connection);
            command.Parameters.AddWithValue("@Username", username);

            connection.Open();
            using var reader = command.ExecuteReader();

            if (!reader.Read()) return null;

            return new User(
                  username: reader.GetString(reader.GetOrdinal("Username")),
                  password: reader.GetString(reader.GetOrdinal("Password")),
                  name: reader.GetString(reader.GetOrdinal("Name")),
                  email: reader.GetString(reader.GetOrdinal("Email"))
            );
        }

        // Otros métodos de IRepository<User> aún deben implementarse.
        public User GetById(int id) => throw new NotImplementedException();
        public List<User> GetAll() => throw new NotImplementedException();
        public void Update(User entity) => throw new NotImplementedException();
        public void Delete(int id) => throw new NotImplementedException();
    }
}

