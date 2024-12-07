using CBS.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain;

public class Structure
{
    public Guid StructureId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; }

    // Relazione con Owner
    public Guid OwnerId { get; set; }
    public Owner Owner { get; set; }

    public ICollection<Service> Services { get; set; }
    public ICollection<RoomType> RoomTypes { get; set; }
    public ICollection<Booking> Bookings { get; set; }
    public ICollection<Promotion> Promotions { get; set; }
    public ICollection<Facilities> Facilities { get; set; }

    //stato
    public StructureState StructureState { get; set; }

  
    public ICollection<Rate> Rates { get; set; }
    public ICollection<Season> Seasons { get; set; }
    public ICollection<CashRegister> CashRegisters { get; set; }
    public ICollection<Deposit> Deposits { get; set; }
    public ICollection<TouristTax> TouristTaxes { get; set; }


}

