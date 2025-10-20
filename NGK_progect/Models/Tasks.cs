using System;
using System.Collections.Generic;

namespace NGK_progect.Models;

public partial class Tasks
{
    public int TaskId { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Category { get; set; }

    public DateOnly? DueDate { get; set; }

    public bool? IsCompleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
