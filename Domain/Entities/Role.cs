using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<RoleMenuItemAccessRight> RoleMenuItemAccessRights { get; } = new List<RoleMenuItemAccessRight>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
