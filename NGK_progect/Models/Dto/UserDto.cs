using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGK_progect.Models.Dto
{
    public class UserDto
    {
        public int? UserId { get; set; } = -1;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Login? Login { get; set; }
    }
}
