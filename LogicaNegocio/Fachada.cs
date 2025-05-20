using LogicaNegocio.DTOs.User;
using LogicaNegocio.SubSystems;

namespace LogicaNegocio
{
    public class Fachada
    {
        private readonly UserSubSystem _userSubSystem;

        public Fachada(UserSubSystem userSubSystem)
        {
            _userSubSystem = userSubSystem;
        }

        public void AddUser(AddUserRequest request)
        {
            _userSubSystem.AddUser(request);
        }

        public UserResponse? GetUserByUsername(string username)
        {
            return _userSubSystem.GetUserByUsername(username);
        }

        public void UpdateUser(UpdateUserRequest request)
        {
            _userSubSystem.UpdateUser(request);
        }
    }
}


