using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{
    public class Season
    {
        public Guid SeasonId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } // Es. "Alta Stagione", "Bassa Stagione"
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        // Relazione con Structure
        public Guid StructureId { get; set; }
        public Structure Structure { get; set; }
    }

}
