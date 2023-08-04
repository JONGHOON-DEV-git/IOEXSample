using System;
using System.Collections.Generic;

namespace BlazorApp6.Server.Database.Entity;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public DateTime RegistDateTime { get; set; }

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<Todo> Todos { get; set; } = new List<Todo>();
}
