using PokerWebsite.Core.Domain;
using PokerWebsite.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Extension
{
    public static class RepositoryExtension
    {
        public static void EnsureSeedData(this ApplicationContext context)
        {
            var venue1 = new Venue { Address = "Wroclaw, pl. Grunwaldzki 18", Day = DayOfWeek.Monday, Descrition = "Rejestra 30 minut przed rozpoczeciem gry", Hour = 20, Minute = 0, Name = "Klub Bilardowy" };

            context.Venues.Add(venue1);
            context.SaveChanges();


            var player1 = new Player { Name = "Andrzej", Surname = "Gołota", Email = "golota@gmail.com", Mobile = "123456789" };
            var player2 = new Player { Name = "Michał", Surname = "Wiśniewski", Email = "wisniewski@gmail.com", Mobile = "123123123" };
            var player3 = new Player { Name = "Maryla", Surname = "Rodowicz", Email = "rodowicz@gmail.com", Mobile = "654456654" };
            var player4 = new Player { Name = "Andrzej", Surname = "Duda", Email = "duda@gmail.com", Mobile = "987987987" };
            var player5 = new Player { Name = "Zdzisław", Surname = "Kręcina", Email = "krecina@gmail.com", Mobile = "0987654321" };

            context.Players.AddRange(player1, player2, player3, player4, player5);
            context.SaveChanges();


            var tournament1 = new Tournament { Date = new DateTime(2016, 03, 20), NumberOfPlayers = 4, Season = 1, Venue = venue1, Year = 2016 };
            var tournament2 = new Tournament { Date = new DateTime(2016, 03, 27), NumberOfPlayers = 5, Season = 1, Venue = venue1, Year = 2016 };

            context.Tournaments.AddRange(tournament1, tournament2);
            context.SaveChanges();


            var player1tournament1 = new Result { Tournament = tournament1, Place = 1, Player = player1, Points = 20 };
            var player2tournament1 = new Result { Tournament = tournament1, Place = 2, Player = player2, Points = 15 };
            var player3tournament1 = new Result { Tournament = tournament1, Place = 3, Player = player3, Points = 10 };
            var player4tournament1 = new Result { Tournament = tournament1, Place = 4, Player = player4, Points = 5 };

            var player1tournament2 = new Result { Tournament = tournament2, Place = 4, Player = player1, Points = 10 };
            var player2tournament2 = new Result { Tournament = tournament2, Place = 2, Player = player2, Points = 20 };
            var player3tournament2 = new Result { Tournament = tournament2, Place = 5, Player = player3, Points = 5 };
            var player4tournament2 = new Result { Tournament = tournament2, Place = 1, Player = player4, Points = 35 };
            var player5tournament2 = new Result { Tournament = tournament2, Place = 3, Player = player5, Points = 15 };

            context.Results.AddRange(player1tournament1, player2tournament1, player3tournament1, player4tournament1, player1tournament2, player2tournament2, player3tournament2, player4tournament2, player5tournament2);
            context.SaveChanges();


            tournament1.Results = new List<Result> { player1tournament1, player2tournament1, player3tournament1, player4tournament1 };
            tournament2.Results = new List<Result> { player1tournament2, player2tournament2, player3tournament2, player4tournament2, player5tournament2 };

            context.Tournaments.Update(tournament1);
            context.Tournaments.Update(tournament2);
            context.SaveChanges();

            player1.Results = new List<Result> { player1tournament1, player1tournament2 };
            player2.Results = new List<Result> { player2tournament1, player2tournament2 };
            player3.Results = new List<Result> { player3tournament1, player3tournament2 };
            player4.Results = new List<Result> { player4tournament1, player4tournament2 };
            player5.Results = new List<Result> { player5tournament2 };


            context.Players.Update(player1);
            context.Players.Update(player2);
            context.Players.Update(player3);
            context.Players.Update(player4);
            context.Players.Update(player5);
            context.SaveChanges();
        }
    }
}
