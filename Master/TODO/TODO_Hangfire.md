
# TODO: Implementazione di Hangfire in Portale Booking Multi-Struttura e Multi-Owner

## 1. Configurazione Generale
- [ ] **Aggiungere Hangfire al progetto**
  - Installare i pacchetti NuGet:
    ```bash
    dotnet add package Hangfire
    dotnet add package Hangfire.SqlServer
    ```
  - Configurare Hangfire nel file `Program.cs`:
    ```csharp
    builder.Services.AddHangfire(config =>
        config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
    builder.Services.AddHangfireServer();
    app.UseHangfireDashboard("/hangfire");
    ```

- [ ] **Configurare la connessione al database**
  - Aggiornare `appsettings.json`:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=HangfireDb;User Id=sa;Password=yourpassword;"
      }
    }
    ```

---

## 2. Creazione dei Job

### 2.1 Notifiche di Conferma Prenotazione
- [ ] Creare il servizio `NotificationService`:
    ```csharp
    public class NotificationService
    {
        public void SendBookingConfirmation(int bookingId)
        {
            Console.WriteLine($"Conferma inviata per la prenotazione: {bookingId}");
        }
    }
    ```
- [ ] Eseguire il job:
    ```csharp
    BackgroundJob.Enqueue<NotificationService>(service => service.SendBookingConfirmation(bookingId));
    ```

### 2.2 Sincronizzazione dei Calendari
- [ ] Creare il servizio `CalendarSyncService`:
    ```csharp
    public class CalendarSyncService
    {
        public void SyncCalendars(int strutturaId)
        {
            Console.WriteLine($"Calendario sincronizzato per la struttura: {strutturaId}");
        }
    }
    ```
- [ ] Pianificare il job ricorrente:
    ```csharp
    RecurringJob.AddOrUpdate<CalendarSyncService>(
        $"sync-structure-{strutturaId}",
        service => service.SyncCalendars(strutturaId),
        Cron.Hourly
    );
    ```

### 2.3 Pulizia Automatica Prenotazioni Scadute
- [ ] Creare il servizio `CleanupService`:
    ```csharp
    public class CleanupService
    {
        public void CleanupOldBookings()
        {
            Console.WriteLine("Prenotazioni vecchie pulite.");
        }
    }
    ```
- [ ] Pianificare la pulizia quotidiana:
    ```csharp
    RecurringJob.AddOrUpdate<CleanupService>(
        "cleanup-old-bookings",
        service => service.CleanupOldBookings(),
        Cron.Daily
    );
    ```

---

## 3. Multi-Tenancy e Code Personalizzate
- [ ] Configurare code specifiche per le strutture:
    ```csharp
    builder.Services.AddHangfireServer(options =>
    {
        options.Queues = new[] { "default", "structure1", "structure2" };
    });
    ```
- [ ] Aggiungere job alle code:
    ```csharp
    BackgroundJob.Enqueue(() => Console.WriteLine("Esegui su coda predefinita"));
    BackgroundJob.Enqueue(() => Console.WriteLine("Esegui per struttura 1"), "structure1");
    ```

---

## 4. Sicurezza della Dashboard
- [ ] Implementare il filtro di autorizzazione:
    ```csharp
    app.UseHangfireDashboard("/hangfire", new DashboardOptions
    {
        Authorization = new[] { new MyAuthorizationFilter() }
    });
    ```
- [ ] Creare `MyAuthorizationFilter`:
    ```csharp
    using Hangfire.Dashboard;

    public class MyAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            // Logica di autorizzazione
            return true;
        }
    }
    ```

---

## 5. Logging e Monitoraggio
- [ ] Integrare un sistema di logging come **Serilog** o **Application Insights** per tracciare i job e gestire gli errori.

---

## 6. Test e Debug
- [ ] Verificare che tutti i job vengano eseguiti correttamente.
- [ ] Testare la sicurezza della dashboard e l'accesso controllato.
- [ ] Assicurarsi che le configurazioni multi-tenant funzionino come previsto.

---

## 7. Documentazione
- [ ] Scrivere documentazione per i job e le configurazioni principali.
- [ ] Fornire istruzioni per la manutenzione del sistema.
