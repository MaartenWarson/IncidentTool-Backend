using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Context
{
    public class IMToolContext : DbContext
    {
        // Tabellen van entities maken
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<OccurredIncident> OccurredIncidents { get; set; }
        public DbSet<User> Users { get; set; }

        public IMToolContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relaties tussen tabellen configureren
            // OneToMany
            modelBuilder.Entity<Device>()
                .HasOne<DeviceType>(d => d.DeviceType)
                .WithMany(t => t.Devices)
                .HasForeignKey(d => d.CurrentDeviceTypeId);

            // OneToMany
            modelBuilder.Entity<Incident>()
                .HasOne<DeviceType>(i => i.DeviceType)
                .WithMany(t => t.Incidents)
                .HasForeignKey(i => i.CurrentDeviceTypeId);

            // OneToMany
            modelBuilder.Entity<OccurredIncident>()
                .HasOne<User>(oi => oi.User)
                .WithMany(u => u.OccurredIncidents)
                .HasForeignKey(oi => oi.CurrentUserId);


            // Properties configureren: voor iedere tabel van Id een verplicht veld maken
            modelBuilder.Entity<Device>()
                .Property(d => d.DeviceId)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<DeviceType>()
                .Property(dt => dt.DeviceTypeId)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Incident>()
                .Property(i => i.IncidentId)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<OccurredIncident>()
                .Property(oi => oi.OccurredIncidentId)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .HasColumnName("Id")
                .IsRequired();


            // Tabellen vullen met data
            SeedDevicesTable(modelBuilder);
            SeedDeviceTypesTable(modelBuilder);
            SeedIncidentsTable(modelBuilder);
            SeedUsersTable(modelBuilder);
            SeedOccurredIncidentsTable(modelBuilder);
        }

        // Hulpmethoden
        private void SeedDevicesTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>().HasData(new List<Device>
            {
                new Device
                {
                    DeviceId = 1,
                    Name = "HP Printer",
                    Location = "Lokaal B11",
                    CurrentDeviceTypeId = 1
                },
                new Device
                {
                    DeviceId = 2,
                    Name = "Canon Printer",
                    Location = "Lokaal B19",
                    CurrentDeviceTypeId = 1
                },
                new Device
                {
                    DeviceId = 3,
                    Name = "Pelican Koffiemachine",
                    Location = "Leraarslokaal",
                    CurrentDeviceTypeId = 2
                },
                new Device
                {
                    DeviceId = 4,
                    Name = "Nespresso Koffiemachine",
                    Location = "Coördinatorenlokaal",
                    CurrentDeviceTypeId = 2
                }
            });
        }

        private void SeedDeviceTypesTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceType>().HasData(new List<DeviceType>
            {
                new DeviceType {DeviceTypeId = 1, Description = "Printer"},
                new DeviceType {DeviceTypeId = 2, Description = "Koffiemachine"}
            });
        }

        private void SeedIncidentsTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>().HasData(new List<Incident>
            {
                new Incident {IncidentId = 1, Description = "Papier is op", CurrentDeviceTypeId = 1},
                new Incident {IncidentId = 2, Description = "Inkt is op", CurrentDeviceTypeId = 1},
                new Incident {IncidentId = 3, Description = "Koffie is op", CurrentDeviceTypeId = 2},
                new Incident {IncidentId = 4, Description = "Koffie is niet warm", CurrentDeviceTypeId = 2}
            });
        }

        private void SeedUsersTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new List<User>
            {
                new User {UserId = 1, Name = "maarten", Password = "pxl"},
                new User {UserId = 2, Name = "chelsea", Password = "pxl"}
            });
        }

        private void SeedOccurredIncidentsTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OccurredIncident>().HasData(new List<OccurredIncident>
            {
                new OccurredIncident
                {
                    OccurredIncidentId = 1,
                    DeviceId = 1,
                    IncidentDescription = "Papier is op",
                    CurrentUserId = 1,
                    Solved = false
                },
                new OccurredIncident
                {
                    OccurredIncidentId = 2,
                    DeviceId = 3,
                    IncidentDescription = "Koffie is op",
                    CurrentUserId = 2,
                    Solved = false
                }
            });
        }
    }
}
