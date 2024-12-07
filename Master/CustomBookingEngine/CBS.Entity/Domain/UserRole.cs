using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain;

public class UserRole
{
    public Guid UserRoleId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; } // Relazione con Identity User
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
}

