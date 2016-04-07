using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using PokerWebsite.Persistence;

namespace PokerWebsite.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20160328105713_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PokerWebsite.Core.Domain.Achievement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<string>("SPName");

                    b.HasKey("ID");

                    b.HasAnnotation("Relational:TableName", "PokerWebsite.Core.Domain.Achievements");
                });

            modelBuilder.Entity("PokerWebsite.Core.Domain.Image", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.HasKey("ID");

                    b.HasAnnotation("Relational:TableName", "PokerWebsite.Core.Domain.Images");
                });

            modelBuilder.Entity("PokerWebsite.Core.Domain.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Mobile");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("ID");

                    b.HasAnnotation("Relational:TableName", "PokerWebsite.Core.Domain.Players");
                });

            modelBuilder.Entity("PokerWebsite.Core.Domain.PlayerAchievement", b =>
                {
                    b.Property<int>("PlayerID");

                    b.Property<int>("AchievementID");

                    b.Property<DateTime>("Date");

                    b.Property<int>("ID");

                    b.HasKey("PlayerID", "AchievementID");

                    b.HasAnnotation("Relational:TableName", "PokerWebsite.Core.Domain.PlayerAchievements");
                });

            modelBuilder.Entity("PokerWebsite.Core.Domain.Result", b =>
                {
                    b.Property<int>("PlayerID");

                    b.Property<int>("TournamentID");

                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Place");

                    b.Property<int>("Points");

                    b.HasKey("PlayerID", "TournamentID");

                    b.HasAnnotation("Relational:TableName", "PokerWebsite.Core.Domain.Results");
                });

            modelBuilder.Entity("PokerWebsite.Core.Domain.Tournament", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("NumberOfPlayers");

                    b.Property<int>("Season");

                    b.Property<int?>("VenueID");

                    b.Property<int?>("WinnerImageID");

                    b.Property<int>("Year");

                    b.HasKey("ID");

                    b.HasAnnotation("Relational:TableName", "PokerWebsite.Core.Domain.Tournaments");
                });

            modelBuilder.Entity("PokerWebsite.Core.Domain.Venue", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("Day");

                    b.Property<string>("Descrition");

                    b.Property<int>("Hour");

                    b.Property<int?>("ImageID");

                    b.Property<int>("Minute");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasAnnotation("Relational:TableName", "PokerWebsite.Core.Domain.Venues");
                });

            modelBuilder.Entity("PokerWebsite.Core.Domain.PlayerAchievement", b =>
                {
                    b.HasOne("PokerWebsite.Core.Domain.Achievement")
                        .WithMany()
                        .HasForeignKey("AchievementID");

                    b.HasOne("PokerWebsite.Core.Domain.Player")
                        .WithMany()
                        .HasForeignKey("PlayerID");
                });

            modelBuilder.Entity("PokerWebsite.Core.Domain.Result", b =>
                {
                    b.HasOne("PokerWebsite.Core.Domain.Player")
                        .WithMany()
                        .HasForeignKey("PlayerID");

                    b.HasOne("PokerWebsite.Core.Domain.Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentID");
                });

            modelBuilder.Entity("PokerWebsite.Core.Domain.Tournament", b =>
                {
                    b.HasOne("PokerWebsite.Core.Domain.Venue")
                        .WithMany()
                        .HasForeignKey("VenueID");

                    b.HasOne("PokerWebsite.Core.Domain.Image")
                        .WithMany()
                        .HasForeignKey("WinnerImageID");
                });

            modelBuilder.Entity("PokerWebsite.Core.Domain.Venue", b =>
                {
                    b.HasOne("PokerWebsite.Core.Domain.Image")
                        .WithMany()
                        .HasForeignKey("ImageID");
                });
        }
    }
}
