using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain;

public class Availability
{
    public Guid AvailabilityId { get; set; } = Guid.NewGuid();
    public Guid ResourceId { get; set; } // ID della risorsa (Room, Service, Promotion)
    public string ResourceType { get; set; } // Es. "Room", "Service", "Promotion"
    public DateTime Date { get; set; }
    public int AvailableQuantity { get; set; }
}

