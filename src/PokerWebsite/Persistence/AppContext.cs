using Microsoft.Data.Entity;
using PokerWebsite.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Persistence
{
    public class AppContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entity.Name).ToTable(entity.Name + "s");
            }
            modelBuilder.Entity<Result>().HasKey(x => new { x.PlayerID, x.TournamentID });
            modelBuilder.Entity<PlayerAchievement>().HasKey(x => new { x.PlayerID, x.AchievementID });
        }
    }
}
