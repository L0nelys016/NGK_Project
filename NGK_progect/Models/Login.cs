using System;
using System.Collections.Generic;

namespace NGK_progect.Models;

public partial class Login
{
    public int LoginId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual User? User { get; set; }
}
