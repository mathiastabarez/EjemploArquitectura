using LogicaNegocio.Domain;
using LogicaNegocio.DTOs.User;
using LogicaNegocio.Repository;

namespace LogicaNegocio.SubSystems
{
    public class UserSubSystem
    {
        private readonly IUserRepository _userRepository;

        public UserSubSystem(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(AddUserRequest request)
        {
            if (_userRepository.ExistsByUsername(request.Username))
                throw new InvalidOperationException("Username already exists.");

            var user = new User(request.Username, request.Password, request.Name, request.Email);
            _userRepository.Add(user);
        }

        public UserResponse? GetUserByUsername(string username)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null)
                return null;

            return new UserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Email = user.Email,
                IsEnabled = user.IsEnabled
            };
        }

        public void UpdateUser(UpdateUserRequest request)
        {
            var user = _userRepository.GetById(request.Id);
            if (user == null)
                throw new InvalidOperationException("User not found.");

            user.Update(request.Name, request.Email);

            if (request.IsEnabled)
                user.Enable();
            else
                user.Disable();

            _userRepository.Update(user);
        }
    }
}

