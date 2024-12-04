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
                builder.HasOne<Customer>().WithMany().HasForeignKey(b => b.CustomerId);
            }
        }

        // RoomType Configuration
        public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
        {
            public void Configure(EntityTypeBuilder<RoomType> builder)
            {
                builder.HasKey(rt => rt.RoomTypeId);
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
            }
        }
    }
}
