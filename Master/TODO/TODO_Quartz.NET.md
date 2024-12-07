
# TODO: Implementazione di Job in Background in Portale Booking Multi-Struttura e Multi-Owner

## 1. Configurazione Generale
- [ ] **Scegliere tra Hangfire o Quartz.NET**
  - **Hangfire**: Semplice da configurare, include una dashboard.
  - **Quartz.NET**: Adatto per scenari di pianificazione avanzata e trigger complessi.

---

## 2. Implementazione con Quartz.NET

### 2.1 Installazione
- [ ] Aggiungere i pacchetti NuGet:
    ```bash
    dotnet add package Quartz
    dotnet add package Quartz.Extensions.Hosting
    dotnet add package Quartz.Persistence.SqlServer
    ```

### 2.2 Creare un Job
- [ ] Creare un job che implementa `IJob`:
    ```csharp
    using Quartz;
    using System;
    using System.Threading.Tasks;

    public class HelloJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"Hello, Quartz.NET! Eseguito alle: {DateTime.Now}");
            return Task.CompletedTask;
        }
    }
    ```

### 2.3 Configurare Quartz.NET
- [ ] Configurare Quartz.NET nel file `Program.cs`:
    ```csharp
    builder.Services.AddQuartz(q =>
    {
        q.UseMicrosoftDependencyInjectionJobFactory();
        var jobKey = new JobKey("HelloJob");

        q.AddJob<HelloJob>(opts => opts.WithIdentity(jobKey));
        q.AddTrigger(opts => opts
            .ForJob(jobKey)
            .WithIdentity("HelloJobTrigger")
            .StartNow()
            .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).RepeatForever()));
    });

    builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    ```

### 2.4 Configurare Trigger Avanzati
- [ ] Configurare un trigger cron per sincronizzazione dei calendari:
    ```csharp
    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("SyncCalendarTrigger")
        .WithCronSchedule("0 0 * * * ?")); // Ogni ora
    ```
- [ ] Configurare un trigger per reportistica settimanale:
    ```csharp
    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("ReportTrigger")
        .WithCronSchedule("0 0 6 ? * MON")); // Ogni lunedì alle 6:00
    ```

### 2.5 Persistenza del Job
- [ ] Configurare Quartz per utilizzare un database:
    ```csharp
    q.UsePersistentStore(options =>
    {
        options.UseSqlServer(sqlServerOptions =>
        {
            sqlServerOptions.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        });
        options.UseJsonSerializer();
        options.UseClustering(); // Se necessario
    });
    ```
- [ ] Eseguire gli script SQL di Quartz.NET per creare le tabelle necessarie.

---

## 3. Multi-Tenancy e Sicurezza
- [ ] Implementare code personalizzate per strutture:
    ```csharp
    builder.Services.AddQuartz(q =>
    {
        q.UseMicrosoftDependencyInjectionJobFactory();
        // Aggiungi job e trigger per ogni struttura
    });
    ```

- [ ] Proteggere endpoint e dashboard con autenticazione.

---

## 4. Logging e Monitoraggio
- [ ] Integrare un sistema di logging come **Serilog** o **Application Insights** per monitorare i job e gestire gli errori.

---

## 5. Test e Debug
- [ ] Testare l'esecuzione dei job con diversi scenari di trigger.
- [ ] Verificare la persistenza dei job e la loro ripresa dopo un riavvio dell'app.

---

## 6. Documentazione
- [ ] Documentare i job configurati e i trigger utilizzati.
- [ ] Fornire istruzioni per la manutenzione e l'aggiunta di nuovi job.
