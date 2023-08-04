using System;
using System.Collections.Generic;

namespace BlazorApp6.Server.Database.Entity;

public partial class Todo
{
    public int TodoId { get; set; }

    public int UserId { get; set; }

    public string Task { get; set; } = null!;

    public ulong IsCompleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
