using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain;

public class Notification
{
    public Guid NotificationId { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Message { get; set; }
    public Guid? UserId { get; set; } // Facoltativo, se indirizzato a un utente specifico
    public Guid? BookingId { get; set; } // Facoltativo, se associato a una prenotazione
    public DateTime ScheduledAt { get; set; }
    public bool IsSent { get; set; }
}
