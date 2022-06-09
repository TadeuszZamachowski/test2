using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using Test2.Models;

namespace TestExample.Contexts
{
    public class FlightsDbContext : DbContext
    {
        public FlightsDbContext()
        {

        }

        public FlightsDbContext(DbContextOptions options) 
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        public virtual DbSet<CityDict> CityDicts { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<FlightPassanger> FlightPassangers { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FlightPassanger>().HasKey(x => new
            {
                x.IdFlight,
                x.IdPassanger
            });
        }
    }
}
