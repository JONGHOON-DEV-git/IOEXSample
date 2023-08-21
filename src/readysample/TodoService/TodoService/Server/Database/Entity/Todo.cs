using System;
using System.Collections.Generic;

namespace TodoService.Server.Database.Entity;

public partial class Todo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public bool IsComplete { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
