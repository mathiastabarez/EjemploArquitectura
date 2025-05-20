using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Domain
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsEnabled { get; private set; }

        public User(string username, string password, string name, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required.");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is required.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");

            Username = username;
            Password = password;
            Name = name;
            Email = email;
            IsEnabled = true;
        }

        public void Disable() => IsEnabled = false;
        public void Enable() => IsEnabled = true;

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
