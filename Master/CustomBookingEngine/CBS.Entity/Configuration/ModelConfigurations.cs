using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBS.Entity.Domain;

namespace CBS.Entity.Configuration
{
    public class ModelConfigurations
    {
        // Service Configuration
        public class ServiceConfiguration : IEntityTypeConfiguration<Service>
        {
            public void Configure(EntityTypeBuilder<Service> builder)
            {
                builder.HasKey(s => s.ServiceId);
                builder.Property(s => s.ServiceName).IsRequired().HasMaxLength(100);
                builder.Property(s => s.Description).HasMaxLength(500);
                builder.HasOne(s => s.Structure)
                       .WithMany(st => st.Services)
                       .HasForeignKey(s => s.StructureId);

            }
        }

        // ServiceImages Configuration
        public class ServiceImagesConfiguration : IEntityTypeConfiguration<ServiceImages>
        {
            public void Configure(EntityTypeBuilder<ServiceImages> builder)
            {
                builder.HasKey(si => si.ServiceImageId);
                builder.HasOne<Service>().WithMany().HasForeignKey(si => si.ServiceId);
            }
        }

        // Customer Configuration
        public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
        {
            public void Configure(EntityTypeBuilder<Customer> builder)
            {
                builder.HasKey(c => c.CustomerId);
                builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
                builder.Property(c => c.PhoneNumber).HasMaxLength(15);
                builder.Property(c => c.Email).HasMaxLength(100);
            }
        }

        // Booking Configuration
        public class BookingConfiguration : IEntityTypeConfiguration<Booking>
        {
            public void Configure(EntityTypeBuilder<Booking> builder)
            {
                builder.HasKey(b => b.BookingId);

                // Relazione con Customer
                builder.HasOne(b => b.Customer)
                       .WithMany(c => c.Bookings)
                       .HasForeignKey(b => b.CustomerId)
                       .IsRequired();


                // Relazione con Structure
                builder.HasOne(b => b.Structure)
                       .WithMany(s => s.Bookings)
                       .HasForeignKey(b => b.StructureId)
                       .IsRequired();

                // Proprietà di navigazione per Payments
                builder.HasMany(b => b.Payments)
                       .WithOne(p => p.Booking)
                       .HasForeignKey(p => p.BookingId);

                builder.HasMany(b => b.Deposits)
                       .WithOne(d => d.Booking)
                       .HasForeignKey(d => d.BookingId);

                builder.HasMany(b => b.TouristTaxes)
                       .WithOne(tt => tt.Booking)
                       .HasForeignKey(tt => tt.BookingId);

            }
        }

        // RoomType Configuration
        public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
        {
            public void Configure(EntityTypeBuilder<RoomType> builder)
            {
                builder.HasKey(rt => rt.RoomTypeId);

                builder.HasOne(rt => rt.Structure)
                       .WithMany(s => s.RoomTypes)
                       .HasForeignKey(rt => rt.StructureId)
                       .IsRequired();

                builder.HasMany(rt => rt.Rates)
                         .WithOne(r => r.RoomType)
                         .HasForeignKey(r => r.RoomTypeId)
                         .IsRequired(false);
            }
        }


        // RoomTypeImages Configuration
        public class RoomTypeImagesConfiguration : IEntityTypeConfiguration<RoomTypeImages>
        {
            public void Configure(EntityTypeBuilder<RoomTypeImages> builder)
            {
                builder.HasKey(rti => rti.RoomTypeImageId);
                builder.HasOne<RoomType>().WithMany().HasForeignKey(rti => rti.RoomTypeId);
            }
        }

        // Room Configuration
        public class RoomConfiguration : IEntityTypeConfiguration<Room>
        {
            public void Configure(EntityTypeBuilder<Room> builder)
            {
                builder.HasKey(r => r.RoomNumber);
                builder.HasOne<RoomType>().WithMany().HasForeignKey(r => r.RoomTypeId);
            }
        }

        // BookingRoomDetails Configuration
        public class BookingRoomDetailsConfiguration : IEntityTypeConfiguration<BookingRoomDetails>
        {
            public void Configure(EntityTypeBuilder<BookingRoomDetails> builder)
            {
                builder.HasKey(brd => brd.BookingRoomDetailsId);
                builder.HasOne<Booking>().WithMany().HasForeignKey(brd => brd.BookingId);
                builder.HasOne<RoomType>().WithMany().HasForeignKey(brd => brd.RoomTypeId);
            }
        }

        // BookingServiceDetails Configuration
        public class BookingServiceDetailsConfiguration : IEntityTypeConfiguration<BookingServiceDetails>
        {
            public void Configure(EntityTypeBuilder<BookingServiceDetails> builder)
            {
                builder.HasKey(bs => bs.BookingServiceDetailsId);
                builder.HasOne<Booking>().WithMany().HasForeignKey(bs => bs.BookingId);
                builder.HasOne<Service>().WithMany().HasForeignKey(bs => bs.ServiceId);
            }
        }

        // Promotion Configuration
        public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
        {
            public void Configure(EntityTypeBuilder<Promotion> builder)
            {
                builder.HasKey(p => p.PromotionId);
                builder.HasOne(p => p.Structure)
                       .WithMany(s => s.Promotions)
                       .HasForeignKey(p => p.StructureId);
            }
        }

        // PromotionApply Configuration
        public class PromotionApplyConfiguration : IEntityTypeConfiguration<PromotionApply>
        {
            public void Configure(EntityTypeBuilder<PromotionApply> builder)
            {
                builder.HasKey(pa => pa.PromotionApplyId);
                builder.HasOne<Promotion>().WithMany().HasForeignKey(pa => pa.PromotionId);
                builder.HasOne<RoomType>().WithMany().HasForeignKey(pa => pa.RoomTypeId);
            }
        }

        // Facilities Configuration
        public class FacilitiesConfiguration : IEntityTypeConfiguration<Facilities>
        {
            public void Configure(EntityTypeBuilder<Facilities> builder)
            {
                builder.HasKey(f => f.FacilityId);
                builder.HasOne(f => f.Structure)
                       .WithMany(s => s.Facilities)
                       .HasForeignKey(f => f.StructureId);

            }
        }

        // FacilitiesApply Configuration
        public class FacilitiesApplyConfiguration : IEntityTypeConfiguration<FacilitiesApply>
        {
            public void Configure(EntityTypeBuilder<FacilitiesApply> builder)
            {
                builder.HasKey(fa => fa.FacilitiesApplyId);
                builder.HasOne<Facilities>().WithMany().HasForeignKey(fa => fa.FacilityId);
                builder.HasOne<RoomType>().WithMany().HasForeignKey(fa => fa.RoomTypeId);
            }
        }

        // Coupon Configuration
        public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
        {
            public void Configure(EntityTypeBuilder<Coupon> builder)
            {
                builder.HasKey(c => c.CouponId);
                builder.HasOne(c => c.Structure)
                       .WithMany()
                       .HasForeignKey(c => c.StructureId)
                       .IsRequired(false);

            }
        }


        // Structure Configuration 
        // (hotel, resort o piu case vacanze)
        public class StructureConfiguration : IEntityTypeConfiguration<Structure>
        {
            public void Configure(EntityTypeBuilder<Structure> builder)
            {
                builder.HasKey(s => s.StructureId);
                builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
                builder.Property(s => s.Address).HasMaxLength(200);
                builder.Property(s => s.City).HasMaxLength(50);
                builder.Property(s => s.Country).HasMaxLength(50);
                builder.Property(s => s.PhoneNumber).HasMaxLength(15);
                builder.Property(s => s.Email).HasMaxLength(100);

                // Relazione con Owner
                builder.HasOne(s => s.Owner)
                       .WithMany(o => o.Structures)
                       .HasForeignKey(s => s.OwnerId);

                builder.HasMany(s => s.Rates)
                       .WithOne(r => r.Structure)
                       .HasForeignKey(r => r.StructureId);

                builder.HasMany(s => s.TouristTaxes)
                       .WithOne(tt => tt.Structure)
                       .HasForeignKey(tt => tt.StructureId);

                builder.HasMany(s => s.CashRegisters)
                       .WithOne(cr => cr.Structure)
                       .HasForeignKey(cr => cr.StructureId);

                builder.HasMany(s => s.TouristTaxes)
                       .WithOne(tt => tt.Structure)
                       .HasForeignKey(tt => tt.StructureId);

                builder.HasMany(s => s.Seasons)
                       .WithOne(season => season.Structure)
                       .HasForeignKey(season => season.StructureId);

            }
        }

        public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
        {
            public void Configure(EntityTypeBuilder<Owner> builder)
            {
                builder.HasKey(o => o.OwnerId);
                builder.Property(o => o.Name).IsRequired().HasMaxLength(100);
                builder.Property(o => o.PhoneNumber).HasMaxLength(15);
                builder.Property(o => o.Email).HasMaxLength(100);

                // Relazione con Structure
                builder.HasMany(o => o.Structures)
                       .WithOne(s => s.Owner)
                       .HasForeignKey(s => s.OwnerId);
            }
        }

        //ruoli

        public class RoleConfiguration : IEntityTypeConfiguration<Role>
        {
            public void Configure(EntityTypeBuilder<Role> builder)
            {
                builder.HasKey(r => r.RoleId);
                builder.Property(r => r.RoleName).IsRequired().HasMaxLength(50);
            }
        }

        public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
        {
            public void Configure(EntityTypeBuilder<UserRole> builder)
            {
                builder.HasKey(ur => ur.UserRoleId);
                builder.HasOne(ur => ur.Role)
                       .WithMany(r => r.UserRoles)
                       .HasForeignKey(ur => ur.RoleId);
            }
        }

        public class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
        {
            public void Configure(EntityTypeBuilder<Availability> builder)
            {
                builder.HasKey(a => a.AvailabilityId);
                builder.Property(a => a.ResourceType).IsRequired().HasMaxLength(50);
                builder.Property(a => a.Date).IsRequired();
            }
        }

        public class ReportConfiguration : IEntityTypeConfiguration<Report>
        {
            public void Configure(EntityTypeBuilder<Report> builder)
            {
                builder.HasKey(r => r.ReportId);
                builder.Property(r => r.Name).IsRequired().HasMaxLength(100);
                builder.Property(r => r.Description).HasMaxLength(500);
                builder.Property(r => r.ReportData).IsRequired();
            }
        }

        public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
        {
            public void Configure(EntityTypeBuilder<Notification> builder)
            {
                builder.HasKey(n => n.NotificationId);
                builder.Property(n => n.Title).IsRequired().HasMaxLength(100);
                builder.Property(n => n.Message).IsRequired().HasMaxLength(500);
                builder.Property(n => n.ScheduledAt).IsRequired();
            }
        }


        // pagamenti, valute, fatturazione, preventivi, rimborsi, sconti e tasse

        public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
        {
            public void Configure(EntityTypeBuilder<Currency> builder)
            {
                builder.HasKey(c => c.CurrencyId);
                builder.Property(c => c.Code).IsRequired().HasMaxLength(10);
                builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
                builder.Property(c => c.ExchangeRate).IsRequired();
            }
        }


        public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
        {
            public void Configure(EntityTypeBuilder<Payment> builder)
            {
                builder.HasKey(p => p.PaymentId);

                builder.HasOne(p => p.Booking)
                       .WithMany(b => b.Payments)
                       .HasForeignKey(p => p.BookingId)
                       .IsRequired();

                builder.HasOne(p => p.Currency)
                       .WithMany()
                       .HasForeignKey(p => p.CurrencyId)
                       .IsRequired();

                builder.HasOne(p => p.PaymentMethod)
                       .WithMany()
                       .HasForeignKey(p => p.PaymentMethodId)
                       .IsRequired();

                builder.Property(p => p.Amount).IsRequired();
                builder.Property(p => p.PaymentDate).IsRequired();
            }
        }


        public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
        {
            public void Configure(EntityTypeBuilder<PaymentMethod> builder)
            {
                builder.HasKey(pm => pm.PaymentMethodId);
                builder.Property(pm => pm.Name).IsRequired().HasMaxLength(50);
                builder.Property(pm => pm.Description).HasMaxLength(200);
                builder.Property(pm => pm.IsActive).IsRequired();
            }
        }



        public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
        {
            public void Configure(EntityTypeBuilder<Invoice> builder)
            {
                builder.HasKey(i => i.InvoiceId);
                builder.HasOne(i => i.Booking)
                       .WithOne()
                       .HasForeignKey<Invoice>(i => i.BookingId)
                       .IsRequired();
                builder.Property(i => i.IssueDate).IsRequired();
                builder.Property(i => i.TotalAmount).IsRequired();
            }
        }

        public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
        {
            public void Configure(EntityTypeBuilder<Quote> builder)
            {
                builder.HasKey(q => q.QuoteId);

                builder.HasOne(q => q.Customer)
                       .WithMany(c => c.Quotes)
                       .HasForeignKey(q => q.CustomerId)
                       .IsRequired();


                builder.Property(q => q.IssueDate).IsRequired();
                builder.Property(q => q.EstimatedAmount).IsRequired();
            }
        }

        public class RefundConfiguration : IEntityTypeConfiguration<Refund>
        {
            public void Configure(EntityTypeBuilder<Refund> builder)
            {
                builder.HasKey(r => r.RefundId);
                builder.HasOne(r => r.Payment)
                       .WithMany()
                       .HasForeignKey(r => r.PaymentId)
                       .IsRequired();
                builder.Property(r => r.RefundAmount).IsRequired();
                builder.Property(r => r.RefundDate).IsRequired();
            }
        }

        public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
        {
            public void Configure(EntityTypeBuilder<Discount> builder)
            {
                builder.HasKey(d => d.DiscountId);
                builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
                builder.Property(d => d.Percentage).IsRequired();
            }
        }

        public class TaxConfiguration : IEntityTypeConfiguration<Tax>
        {
            public void Configure(EntityTypeBuilder<Tax> builder)
            {
                builder.HasKey(t => t.TaxId);
                builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
                builder.Property(t => t.Percentage).IsRequired();
            }
        }

        public class SeasonConfiguration : IEntityTypeConfiguration<Season>
        {
            public void Configure(EntityTypeBuilder<Season> builder)
            {
                builder.HasKey(s => s.SeasonId);
                builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
                builder.Property(s => s.StartDate).IsRequired();
                builder.Property(s => s.EndDate).IsRequired();

                builder.HasOne(s => s.Structure)
                       .WithMany(st => st.Seasons)
                       .HasForeignKey(s => s.StructureId);
            }
        }

        public class RateConfiguration : IEntityTypeConfiguration<Rate>
        {
            public void Configure(EntityTypeBuilder<Rate> builder)
            {

                builder.HasKey(r => r.RateId);
                
                builder.HasOne(r => r.Structure)
                       .WithMany(s => s.Rates)
                       .HasForeignKey(r => r.StructureId)
                       .IsRequired();

                builder.HasOne(r => r.RoomType)
                       .WithMany()
                       .HasForeignKey(r => r.RoomTypeId)
                       .IsRequired(false);

                builder.HasOne(r => r.Season)
                       .WithMany()
                       .HasForeignKey(r => r.SeasonId)
                       .IsRequired(false);

                builder.Property(r => r.Amount).IsRequired();


            }
        }

        public class CashRegisterConfiguration : IEntityTypeConfiguration<CashRegister>
        {
            public void Configure(EntityTypeBuilder<CashRegister> builder)
            {
                builder.HasKey(cr => cr.CashRegisterId);
                builder.HasOne(cr => cr.Structure)
                       .WithMany()
                       .HasForeignKey(cr => cr.StructureId)
                       .IsRequired();

                builder.Property(cr => cr.TransactionDate).IsRequired();
                builder.Property(cr => cr.Amount).IsRequired();
                builder.Property(cr => cr.TransactionType).IsRequired();
            }
        }

        public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
        {
            public void Configure(EntityTypeBuilder<Deposit> builder)
            {
                builder.HasKey(d => d.DepositId);
                builder.HasOne(d => d.Booking)
                       .WithMany(b => b.Deposits)
                       .HasForeignKey(d => d.BookingId)
                       .IsRequired();

                builder.Property(d => d.Amount).IsRequired();
                builder.Property(d => d.DepositDate).IsRequired();
            }
        }

        public class SuspendedConfiguration : IEntityTypeConfiguration<Suspended>
        {
            public void Configure(EntityTypeBuilder<Suspended> builder)
            {
                builder.HasKey(s => s.SuspendedId);
                builder.HasOne(s => s.Customer)
                       .WithMany(c => c.Suspendeds)
                       .HasForeignKey(s => s.CustomerId)
                       .IsRequired();

                builder.Property(s => s.Amount).IsRequired();
                builder.Property(s => s.DueDate).IsRequired();
            }
        }

        public class TouristTaxConfiguration : IEntityTypeConfiguration<TouristTax>
        {
            public void Configure(EntityTypeBuilder<TouristTax> builder)
            {
                builder.HasKey(tt => tt.TouristTaxId);

                // Relazione con Booking
                builder.HasOne(tt => tt.Booking)
                       .WithMany(b => b.TouristTaxes)
                       .HasForeignKey(tt => tt.BookingId)
                       .IsRequired();

                // Relazione con Structure
                builder.HasOne(tt => tt.Structure)
                       .WithMany(s => s.TouristTaxes)
                       .HasForeignKey(tt => tt.StructureId)
                       .IsRequired();

                builder.Property(tt => tt.Amount).IsRequired();
                builder.Property(tt => tt.TaxDate).IsRequired();
            }
        }


    }
}
