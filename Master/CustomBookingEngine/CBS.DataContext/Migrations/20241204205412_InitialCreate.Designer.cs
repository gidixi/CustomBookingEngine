﻿// <auto-generated />
using System;
using CBS.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CBS.DataContext.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241204205412_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CBS.Entity.Domain.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("CheckinDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CheckoutDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CouponId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("boolean");

                    b.Property<int>("NumberOfAdults")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfChildren")
                        .HasColumnType("integer");

                    b.Property<decimal>("RoomAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ServiceAmount")
                        .HasColumnType("numeric");

                    b.HasKey("BookingId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("CBS.Entity.Domain.BookingRoomDetails", b =>
                {
                    b.Property<int>("BookingRoomDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookingRoomDetailsId"));

                    b.Property<int>("BookingId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("RoomPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("RoomQuantity")
                        .HasColumnType("integer");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("integer");

                    b.HasKey("BookingRoomDetailsId");

                    b.HasIndex("BookingId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("BookingRoomDetails");
                });

            modelBuilder.Entity("CBS.Entity.Domain.BookingServiceDetails", b =>
                {
                    b.Property<int>("BookingServiceDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookingServiceDetailsId"));

                    b.Property<int>("BookingId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ServicePrice")
                        .HasColumnType("numeric");

                    b.Property<int>("ServiceQuantity")
                        .HasColumnType("integer");

                    b.HasKey("BookingServiceDetailsId");

                    b.HasIndex("BookingId");

                    b.HasIndex("ServiceId");

                    b.ToTable("BookingServiceDetails");
                });

            modelBuilder.Entity("CBS.Entity.Domain.Coupon", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CouponId"));

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Reduction")
                        .HasColumnType("numeric");

                    b.Property<int>("Remain")
                        .HasColumnType("integer");

                    b.HasKey("CouponId");

                    b.ToTable("Coupon");
                });

            modelBuilder.Entity("CBS.Entity.Domain.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CBS.Entity.Domain.Facilities", b =>
                {
                    b.Property<int>("FacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FacilityId"));

                    b.Property<byte[]>("FacilityImage")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("FacilityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FacilityId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("CBS.Entity.Domain.FacilitiesApply", b =>
                {
                    b.Property<int>("FacilitiesApplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FacilitiesApplyId"));

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("integer");

                    b.HasKey("FacilitiesApplyId");

                    b.HasIndex("FacilityId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("FacilitiesApply");
                });

            modelBuilder.Entity("CBS.Entity.Domain.Promotion", b =>
                {
                    b.Property<int>("PromotionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PromotionId"));

                    b.Property<decimal>("DiscountRates")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("PromotionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("PromotionId");

                    b.ToTable("Promotion");
                });

            modelBuilder.Entity("CBS.Entity.Domain.PromotionApply", b =>
                {
                    b.Property<int>("PromotionApplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PromotionApplyId"));

                    b.Property<int>("PromotionId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("integer");

                    b.HasKey("PromotionApplyId");

                    b.HasIndex("PromotionId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("PromotionApply");
                });

            modelBuilder.Entity("CBS.Entity.Domain.Room", b =>
                {
                    b.Property<int>("RoomNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoomNumber"));

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("boolean");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("integer");

                    b.HasKey("RoomNumber");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("CBS.Entity.Domain.RoomType", b =>
                {
                    b.Property<int>("RoomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoomTypeId"));

                    b.Property<decimal>("DefaultPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("MaxAdult")
                        .HasColumnType("integer");

                    b.Property<int>("MaxChildren")
                        .HasColumnType("integer");

                    b.Property<int>("MaxPeople")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("RoomTypeId");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("CBS.Entity.Domain.RoomTypeImages", b =>
                {
                    b.Property<int>("RoomTypeImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoomTypeImageId"));

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("integer");

                    b.HasKey("RoomTypeImageId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("RoomTypeImages");
                });

            modelBuilder.Entity("CBS.Entity.Domain.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ServiceId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ServiceId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("CBS.Entity.Domain.ServiceImages", b =>
                {
                    b.Property<int>("ServiceImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ServiceImageId"));

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.HasKey("ServiceImageId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceImages");
                });

            modelBuilder.Entity("CBS.Entity.Domain.Booking", b =>
                {
                    b.HasOne("CBS.Entity.Domain.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CBS.Entity.Domain.BookingRoomDetails", b =>
                {
                    b.HasOne("CBS.Entity.Domain.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CBS.Entity.Domain.RoomType", null)
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CBS.Entity.Domain.BookingServiceDetails", b =>
                {
                    b.HasOne("CBS.Entity.Domain.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CBS.Entity.Domain.Service", null)
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CBS.Entity.Domain.FacilitiesApply", b =>
                {
                    b.HasOne("CBS.Entity.Domain.Facilities", null)
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CBS.Entity.Domain.RoomType", null)
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CBS.Entity.Domain.PromotionApply", b =>
                {
                    b.HasOne("CBS.Entity.Domain.Promotion", null)
                        .WithMany()
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CBS.Entity.Domain.RoomType", null)
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CBS.Entity.Domain.Room", b =>
                {
                    b.HasOne("CBS.Entity.Domain.RoomType", null)
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CBS.Entity.Domain.RoomTypeImages", b =>
                {
                    b.HasOne("CBS.Entity.Domain.RoomType", null)
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CBS.Entity.Domain.ServiceImages", b =>
                {
                    b.HasOne("CBS.Entity.Domain.Service", null)
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}