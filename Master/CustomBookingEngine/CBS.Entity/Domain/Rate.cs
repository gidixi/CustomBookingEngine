using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain
{

    /// <summary>
    /// Tariffa
    /// </summary>
    public class Rate
    {
        public Guid RateId { get; set; } = Guid.NewGuid();
        public Guid StructureId { get; set; }
        public Structure Structure { get; set; }
        public Guid? RoomTypeId { get; set; } // Facoltativo: tariffa specifica per tipo di camera
        public RoomType RoomType { get; set; }
        public Guid? SeasonId { get; set; } // Facoltativo: tariffa valida in una stagione
        public Season Season { get; set; }
        public decimal Amount { get; set; } // Prezzo
        public string Description { get; set; } // Es. "Tariffa speciale per alta stagione"
    }

}
