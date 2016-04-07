using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using PokerWebsite.Core.Domain;
using PokerWebsite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Persistence
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=TOMASZ\\SQLEXPRESS;Initial Catalog=PokerWebsite;Integrated Security=True");
        }

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
