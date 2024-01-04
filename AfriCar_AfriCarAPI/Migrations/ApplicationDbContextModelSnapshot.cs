﻿// <auto-generated />
using System;
using AfriCar_AfriCarAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AfriCar_AfriCarAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AfriCar_AfriCarAPI.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<string>("ReleaseYear")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Classification = "Sedan",
                            CreatedDate = new DateTime(2024, 1, 4, 13, 23, 0, 412, DateTimeKind.Local).AddTicks(849),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475328/DotNet%20API/hxsu50sgmt5onrl3p1p8.jpg",
                            Name = "Toyota Corolla",
                            Occupancy = 4,
                            Rate = 200.0,
                            ReleaseYear = "2018",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Classification = "SUV",
                            CreatedDate = new DateTime(2024, 1, 4, 13, 23, 0, 412, DateTimeKind.Local).AddTicks(861),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475327/DotNet%20API/sopj1bycevitusiddh0n.jpg",
                            Name = "Ford Explorer",
                            Occupancy = 4,
                            Rate = 500.0,
                            ReleaseYear = "2019",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Classification = "Convertible",
                            CreatedDate = new DateTime(2024, 1, 4, 13, 23, 0, 412, DateTimeKind.Local).AddTicks(863),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475327/DotNet%20API/zq2f27omunuan1lba1tg.jpg",
                            Name = "Ford Mustang",
                            Occupancy = 2,
                            Rate = 200.0,
                            ReleaseYear = "2019",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Classification = "Sedan",
                            CreatedDate = new DateTime(2024, 1, 4, 13, 23, 0, 412, DateTimeKind.Local).AddTicks(865),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475328/DotNet%20API/l5zxmoivfspke86qmu9b.jpg",
                            Name = "Chrysler 300",
                            Occupancy = 4,
                            Rate = 300.0,
                            ReleaseYear = "2014",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Classification = "Sedan",
                            CreatedDate = new DateTime(2024, 1, 4, 13, 23, 0, 412, DateTimeKind.Local).AddTicks(867),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475328/DotNet%20API/nhobn79bdvgoasgwtxvt.jpg",
                            Name = "Volkswagen Jetta",
                            Occupancy = 4,
                            Rate = 290.0,
                            ReleaseYear = "2017",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AfriCar_AfriCarAPI.Models.CarNumberModel", b =>
                {
                    b.Property<int>("CarNo")
                        .HasColumnType("int");

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CarNo");

                    b.HasIndex("CarID");

                    b.ToTable("CarNumbers");
                });

            modelBuilder.Entity("AfriCar_AfriCarAPI.Models.CarNumberModel", b =>
                {
                    b.HasOne("AfriCar_AfriCarAPI.Models.CarModel", "Car")
                        .WithMany()
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });
#pragma warning restore 612, 618
        }
    }
}
