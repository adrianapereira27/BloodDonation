﻿// <auto-generated />
using System;
using BloodDonation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BloodDonation.Infrastructure.Migrations
{
    [DbContext(typeof(BloodDonationDbContext))]
    partial class BloodDonationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BloodDonation.Core.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdDonor")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdDonor")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("BloodDonation.Core.Entities.BloodStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BloodType")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOfMl")
                        .HasColumnType("int");

                    b.Property<string>("RhFactor")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("BloodStocks");
                });

            modelBuilder.Entity("BloodDonation.Core.Entities.Donation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DonationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDonor")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOfMl")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDonor");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("BloodDonation.Core.Entities.Donor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BloodType")
                        .HasColumnType("int");

                    b.Property<int>("DonationId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("IdAddress")
                        .HasColumnType("int");

                    b.Property<int>("IdDonation")
                        .HasColumnType("int");

                    b.Property<string>("RhFactor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DonationId");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("BloodDonation.Core.Entities.Address", b =>
                {
                    b.HasOne("BloodDonation.Core.Entities.Donor", "Donor")
                        .WithOne("Address")
                        .HasForeignKey("BloodDonation.Core.Entities.Address", "IdDonor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("BloodDonation.Core.Entities.Donation", b =>
                {
                    b.HasOne("BloodDonation.Core.Entities.Donor", "Donor")
                        .WithMany("Donations")
                        .HasForeignKey("IdDonor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("BloodDonation.Core.Entities.Donor", b =>
                {
                    b.HasOne("BloodDonation.Core.Entities.Donation", "Donation")
                        .WithMany()
                        .HasForeignKey("DonationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donation");
                });

            modelBuilder.Entity("BloodDonation.Core.Entities.Donor", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Donations");
                });
#pragma warning restore 612, 618
        }
    }
}
