﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Context;

namespace WebAPI.Migrations
{
    [DbContext(typeof(IMToolContext))]
    [Migration("20200130122601_init6")]
    partial class init6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Entities.Device", b =>
                {
                    b.Property<int>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentDeviceTypeId");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.HasKey("DeviceId");

                    b.HasIndex("CurrentDeviceTypeId");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            DeviceId = 1,
                            CurrentDeviceTypeId = 1,
                            Location = "Lokaal B11",
                            Name = "HP Printer"
                        },
                        new
                        {
                            DeviceId = 2,
                            CurrentDeviceTypeId = 1,
                            Location = "Lokaal B19",
                            Name = "Canon Printer"
                        },
                        new
                        {
                            DeviceId = 3,
                            CurrentDeviceTypeId = 2,
                            Location = "Leraarslokaal",
                            Name = "Pelican Koffiemachine"
                        },
                        new
                        {
                            DeviceId = 4,
                            CurrentDeviceTypeId = 2,
                            Location = "Coördinatorenlokaal",
                            Name = "Nespresso Koffiemachine"
                        });
                });

            modelBuilder.Entity("WebAPI.Entities.DeviceType", b =>
                {
                    b.Property<int>("DeviceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("DeviceTypeId");

                    b.ToTable("DeviceTypes");

                    b.HasData(
                        new
                        {
                            DeviceTypeId = 1,
                            Description = "Printer"
                        },
                        new
                        {
                            DeviceTypeId = 2,
                            Description = "Koffiemachine"
                        });
                });

            modelBuilder.Entity("WebAPI.Entities.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentDeviceTypeId");

                    b.Property<string>("Description");

                    b.HasKey("IncidentId");

                    b.HasIndex("CurrentDeviceTypeId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CurrentDeviceTypeId = 1,
                            Description = "Papier is op"
                        },
                        new
                        {
                            IncidentId = 2,
                            CurrentDeviceTypeId = 1,
                            Description = "Inkt is op"
                        },
                        new
                        {
                            IncidentId = 3,
                            CurrentDeviceTypeId = 2,
                            Description = "Koffie is op"
                        },
                        new
                        {
                            IncidentId = 4,
                            CurrentDeviceTypeId = 2,
                            Description = "Koffie is niet warm"
                        });
                });

            modelBuilder.Entity("WebAPI.Entities.OccurredIncident", b =>
                {
                    b.Property<int>("OccurredIncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentUserId");

                    b.Property<string>("DeviceName");

                    b.Property<string>("IncidentDescription");

                    b.Property<bool>("Solved");

                    b.HasKey("OccurredIncidentId");

                    b.HasIndex("CurrentUserId");

                    b.ToTable("OccurredIncidents");

                    b.HasData(
                        new
                        {
                            OccurredIncidentId = 1,
                            CurrentUserId = 1,
                            DeviceName = "HP Printer",
                            IncidentDescription = "Papier is op",
                            Solved = false
                        },
                        new
                        {
                            OccurredIncidentId = 2,
                            CurrentUserId = 2,
                            DeviceName = "Pelican Koffiemachine",
                            IncidentDescription = "Koffie is op",
                            Solved = false
                        });
                });

            modelBuilder.Entity("WebAPI.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "maarten",
                            Password = "pxl"
                        },
                        new
                        {
                            UserId = 2,
                            Name = "chelsea",
                            Password = "pxl"
                        });
                });

            modelBuilder.Entity("WebAPI.Entities.Device", b =>
                {
                    b.HasOne("WebAPI.Entities.DeviceType", "DeviceType")
                        .WithMany("Devices")
                        .HasForeignKey("CurrentDeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Entities.Incident", b =>
                {
                    b.HasOne("WebAPI.Entities.DeviceType", "DeviceType")
                        .WithMany("Incidents")
                        .HasForeignKey("CurrentDeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Entities.OccurredIncident", b =>
                {
                    b.HasOne("WebAPI.Entities.User", "User")
                        .WithMany("OccurredIncidents")
                        .HasForeignKey("CurrentUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
