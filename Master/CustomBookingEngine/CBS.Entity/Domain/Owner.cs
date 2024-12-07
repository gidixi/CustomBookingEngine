using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{
    public class Owner
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        // Relazione con Structure
        public ICollection<Structure> Structures { get; set; }
    }

}
