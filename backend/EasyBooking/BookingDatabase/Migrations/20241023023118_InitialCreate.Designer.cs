﻿// <auto-generated />
using System;
using BookingDatabase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingDatabase.Migrations
{
    [DbContext(typeof(EasyBookingContext))]
    [Migration("20241023023118_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("BookingDatabase.Models.Booking", b =>
                {
                    b.Property<int>("ProviderID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeslotID")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ClientID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProviderID", "ServiceID", "TimeslotID", "Date");

                    b.HasIndex("ClientID");

                    b.HasIndex("ServiceID");

                    b.HasIndex("TimeslotID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BookingDatabase.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BookingDatabase.Models.Provider", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("BookingDatabase.Models.Review", b =>
                {
                    b.Property<int>("ClientID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProviderID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClientID", "ProviderID");

                    b.HasIndex("ProviderID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BookingDatabase.Models.Service", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DurationInMinutes")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<int>("ProviderID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ProviderID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("BookingDatabase.Models.Timeslot", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProviderID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Time")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ProviderID");

                    b.HasIndex("ServiceID");

                    b.ToTable("Timeslots");
                });

            modelBuilder.Entity("BookingDatabase.Models.Booking", b =>
                {
                    b.HasOne("BookingDatabase.Models.Client", null)
                        .WithMany("Bookings")
                        .HasForeignKey("ClientID");

                    b.HasOne("BookingDatabase.Models.Provider", "Provider")
                        .WithMany("Bookings")
                        .HasForeignKey("ProviderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingDatabase.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingDatabase.Models.Timeslot", "Timeslot")
                        .WithMany()
                        .HasForeignKey("TimeslotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");

                    b.Navigation("Service");

                    b.Navigation("Timeslot");
                });

            modelBuilder.Entity("BookingDatabase.Models.Review", b =>
                {
                    b.HasOne("BookingDatabase.Models.Client", "Client")
                        .WithMany("Reviews")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingDatabase.Models.Provider", "Provider")
                        .WithMany("Reviews")
                        .HasForeignKey("ProviderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("BookingDatabase.Models.Service", b =>
                {
                    b.HasOne("BookingDatabase.Models.Provider", "Provider")
                        .WithMany("Services")
                        .HasForeignKey("ProviderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("BookingDatabase.Models.Timeslot", b =>
                {
                    b.HasOne("BookingDatabase.Models.Provider", "Provider")
                        .WithMany("Timeslots")
                        .HasForeignKey("ProviderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingDatabase.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("BookingDatabase.Models.Client", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BookingDatabase.Models.Provider", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");

                    b.Navigation("Services");

                    b.Navigation("Timeslots");
                });
#pragma warning restore 612, 618
        }
    }
}