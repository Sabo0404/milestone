using F1Schedule.Models.Cars;
using F1Schedule.Models.Drivers;
using F1Schedule.Models.Places;
using F1Schedule.Models.RaceResults;
using F1Schedule.Models.Races;
using F1Schedule.Models.SeasonRaces;
using F1Schedule.Models.Seasons;
using F1Schedule.Models.Teams;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions option): base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SeasonRace>().HasKey(sc => new { sc.SeasonId, sc.RaceId });

            modelBuilder.Entity<SeasonRace>()
                .HasOne<Season>(sc => sc.Season)
                .WithMany(s => s.Races)
                .HasForeignKey(sc => sc.SeasonId);


            modelBuilder.Entity<SeasonRace>()
                .HasOne<Race>(sc => sc.Race)
                .WithMany(s => s.Seasons)
                .HasForeignKey(sc => sc.RaceId);
        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceResult> RaceResults { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<SeasonRace> SeasonRaces { get; set; }
    }
}
