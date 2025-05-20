using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTOs.User
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public bool IsEnabled { get; set; }
    }
}
