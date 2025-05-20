using LogicaNegocio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        bool ExistsByUsername(string username);
        User? GetByUsername(string username);
    }
}
