using System;
using System.Collections.Generic;

namespace NGK_progect.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int? LoginId { get; set; }

    public virtual Login? Login { get; set; }
}
