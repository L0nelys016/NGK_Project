using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGK_progect.Models.Dto
{
    public class LoginDto
    {
        public int? LoginId { get; set; } = -1;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
