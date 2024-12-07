
# Riepilogo delle Entità e Relazioni del Sistema

## **Elenco delle Tabelle e Relazioni**

### **1. Customer**
**Descrizione**: Gestisce i dati dei clienti.
- **Relazioni**:
  - **Booking** (1:N): Un cliente può avere più prenotazioni.
  - **Suspended** (1:N): Un cliente può avere più sospesi.
  - **Quote** (1:N): Un cliente può avere più preventivi.

---

### **2. Booking**
**Descrizione**: Gestisce le prenotazioni.
- **Relazioni**:
  - **Customer** (N:1): Ogni prenotazione è associata a un cliente.
  - **Structure** (N:1): Ogni prenotazione è associata a una struttura.
  - **Payment** (1:N): Una prenotazione può avere più pagamenti.
  - **Deposit** (1:N): Una prenotazione può avere più depositi.
  - **TouristTax** (1:N): Una prenotazione può avere più tasse di soggiorno.
  - **BookingRoomDetails** (1:N): Una prenotazione può avere dettagli relativi alle camere.
  - **BookingServiceDetails** (1:N): Una prenotazione può avere dettagli relativi ai servizi.

---

### **3. Structure**
**Descrizione**: Gestisce le strutture (hotel, resort, ecc.).
- **Relazioni**:
  - **Owner** (N:1): Ogni struttura ha un proprietario.
  - **RoomType** (1:N): Una struttura può avere più tipi di camera.
  - **Rate** (1:N): Una struttura può avere più tariffe.
  - **Season** (1:N): Una struttura può avere più stagioni.
  - **CashRegister** (1:N): Una struttura può avere più registrazioni di cassa.
  - **TouristTax** (1:N): Una struttura può avere più tasse di soggiorno.
  - **Facilities** (1:N): Una struttura può avere più facilities.
  - **Booking** (1:N): Una struttura può avere più prenotazioni.
  - **Service** (1:N): Una struttura può offrire più servizi.
  - **Promotion** (1:N): Una struttura può avere più promozioni.

---

### **4. RoomType**
**Descrizione**: Gestisce i tipi di camera.
- **Relazioni**:
  - **Structure** (N:1): Ogni tipo di camera appartiene a una struttura.
  - **Rate** (1:N): Un tipo di camera può avere più tariffe.
  - **FacilitiesApply** (1:N): Ogni tipo di camera può avere facilities applicate.
  - **BookingRoomDetails** (1:N): Ogni tipo di camera può essere associato a dettagli di prenotazione.

---

### **5. Rate**
**Descrizione**: Gestisce le tariffe.
- **Relazioni**:
  - **Structure** (N:1): Ogni tariffa è associata a una struttura.
  - **RoomType** (N:1): Una tariffa può essere associata a un tipo di camera.
  - **Season** (N:1): Una tariffa può essere valida in una stagione.

---

### **6. Season**
**Descrizione**: Gestisce le stagioni.
- **Relazioni**:
  - **Structure** (N:1): Ogni stagione è associata a una struttura.
  - **Rate** (1:N): Una stagione può avere più tariffe.

---

### **7. CashRegister**
**Descrizione**: Gestisce le registrazioni di cassa.
- **Relazioni**:
  - **Structure** (N:1): Ogni registrazione è associata a una struttura.

---

### **8. Deposit**
**Descrizione**: Gestisce gli acconti/caparre.
- **Relazioni**:
  - **Booking** (N:1): Ogni deposito è associato a una prenotazione.

---

### **9. TouristTax**
**Descrizione**: Gestisce le tasse di soggiorno.
- **Relazioni**:
  - **Structure** (N:1): Ogni tassa di soggiorno è associata a una struttura.
  - **Booking** (N:1): Ogni tassa di soggiorno è associata a una prenotazione.

---

### **10. Suspended**
**Descrizione**: Gestisce i sospesi.
- **Relazioni**:
  - **Customer** (N:1): Ogni sospeso è associato a un cliente.

---

### **11. Payment**
**Descrizione**: Gestisce i pagamenti.
- **Relazioni**:
  - **Booking** (N:1): Ogni pagamento è associato a una prenotazione.
  - **Currency** (N:1): Ogni pagamento è associato a una valuta.
  - **PaymentMethod** (N:1): Ogni pagamento è associato a un metodo di pagamento.

---

### **12. PaymentMethod**
**Descrizione**: Gestisce i metodi di pagamento.
- **Relazioni**:
  - Nessuna relazione diretta aggiuntiva.

---

### **13. Facilities**
**Descrizione**: Gestisce le facilities offerte.
- **Relazioni**:
  - **Structure** (N:1): Ogni facility è associata a una struttura.
  - **FacilitiesApply** (1:N): Una facility può essere applicata a più tipi di camera.

---

### **14. FacilitiesApply**
**Descrizione**: Gestisce l'applicazione delle facilities ai tipi di camera.
- **Relazioni**:
  - **RoomType** (N:1): Ogni facility applicata è associata a un tipo di camera.
  - **Facilities** (N:1): Ogni facility applicata è associata a una facility.

---

### **15. Promotion**
**Descrizione**: Gestisce le promozioni.
- **Relazioni**:
  - **Structure** (N:1): Ogni promozione è associata a una struttura.

---

### **16. Quote**
**Descrizione**: Gestisce i preventivi.
- **Relazioni**:
  - **Customer** (N:1): Ogni preventivo è associato a un cliente.

---

### **17. Refund**
**Descrizione**: Gestisce i rimborsi.
- **Relazioni**:
  - **Payment** (N:1): Ogni rimborso è associato a un pagamento.

---

### **Relazioni Chiave**

| **Entità**          | **Relazioni**                                                                              |
|----------------------|-------------------------------------------------------------------------------------------|
| `Customer`          | `Booking`, `Suspended`, `Quote`                                                           |
| `Booking`           | `Customer`, `Structure`, `Payment`, `Deposit`, `TouristTax`, `BookingRoomDetails`         |
| `Structure`         | `Owner`, `RoomType`, `Rate`, `Season`, `CashRegister`, `TouristTax`, `Facilities`, `Promotion` |
| `RoomType`          | `Structure`, `Rate`, `FacilitiesApply`, `BookingRoomDetails`                              |
| `Rate`              | `Structure`, `RoomType`, `Season`                                                         |
| `Season`            | `Structure`, `Rate`                                                                       |
| `CashRegister`      | `Structure`                                                                               |
| `Deposit`           | `Booking`                                                                                |
| `TouristTax`        | `Structure`, `Booking`                                                                    |
| `Payment`           | `Booking`, `Currency`, `PaymentMethod`                                                    |
| `Promotion`         | `Structure`                                                                               |

---

### **Note Finali**
- **Chiavi Primarie**: Tutte le entità utilizzano `Guid` come chiave primaria per coerenza.
- **Navigazione**: Tutte le entità includono proprietà di navigazione per supportare query complesse.
- **Configurazioni Fluent API**: Ogni relazione è configurata utilizzando `HasOne`, `WithMany`, `HasForeignKey` per garantire l'integrità referenziale.
