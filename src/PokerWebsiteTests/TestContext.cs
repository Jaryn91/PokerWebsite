using Microsoft.Data.Entity;
using Moq;
using PokerWebsite.Core.Domain;
using PokerWebsite.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerWebsiteTests
{
    public class TestContext
    {
        public TestContext()
        {

        }

        public IQueryable<Player> PlayerContext()
        {        
            var venue1 = new Venue { ID = 1, Address = "Wroclaw, pl. Grunwaldzki 18", Day = DayOfWeek.Monday, Descrition = "Rejestra 30 minut przed rozpoczeciem gry", Hour = 20, Minute = 0, Name = "Klub Bilardowy" };

            var player1 = new Player { ID = 1, Name = "Andrzej", Surname = "Gołota", Email = "golota@gmail.com", Mobile = "123456789" };
            var player2 = new Player { ID = 2, Name = "Michał", Surname = "Wiśniewski", Email = "wisniewski@gmail.com", Mobile = "123123123" };
            var player3 = new Player { ID = 3, Name = "Maryla", Surname = "Rodowicz", Email = "rodowicz@gmail.com", Mobile = "654456654" };
            var player4 = new Player { ID = 4, Name = "Andrzej", Surname = "Duda", Email = "duda@gmail.com", Mobile = "987987987" };
            var player5 = new Player { ID = 5, Name = "Zdzisław", Surname = "Kręcina", Email = "krecina@gmail.com", Mobile = "0987654321" };

            var tournament1 = new Tournament { Date = new DateTime(2016, 03, 20), NumberOfPlayers = 4, Season = 1, Venue = venue1, Year = 2016, ID = 1 };
            var tournament2 = new Tournament { Date = new DateTime(2016, 03, 27), NumberOfPlayers = 5, Season = 1, Venue = venue1, Year = 2016, ID = 2 };


            var player1tournament1 = new Result { Tournament = tournament1, TournamentID = 1, Place = 1, Player = player1, PlayerID = 1, Points = 20, ID = 1 };
            var player2tournament1 = new Result { Tournament = tournament1, TournamentID = 1, Place = 2, Player = player2, PlayerID = 2, Points = 15, ID = 2 };
            var player3tournament1 = new Result { Tournament = tournament1, TournamentID = 1, Place = 3, Player = player3, PlayerID = 3, Points = 10, ID = 3 };
            var player4tournament1 = new Result { Tournament = tournament1, TournamentID = 1, Place = 4, Player = player4, PlayerID = 4, Points = 5, ID = 4 };


            var player1tournament2 = new Result { Tournament = tournament2, TournamentID = 2, Place = 4, Player = player1, PlayerID = 1, Points = 10, ID = 5 };
            var player2tournament2 = new Result { Tournament = tournament2, TournamentID = 2, Place = 2, Player = player2, PlayerID = 2, Points = 20, ID = 6 };
            var player3tournament2 = new Result { Tournament = tournament2, TournamentID = 2, Place = 5, Player = player3, PlayerID = 3, Points = 5, ID = 7 };
            var player4tournament2 = new Result { Tournament = tournament2, TournamentID = 2, Place = 3, Player = player4, PlayerID = 4, Points = 15, ID = 8 };
            var player5tournament2 = new Result { Tournament = tournament2, TournamentID = 2, Place = 1, Player = player5, PlayerID = 5, Points = 25, ID = 9 };

            tournament1.Results = new List<Result> { player1tournament1, player2tournament1, player3tournament1, player4tournament1};
            tournament2.Results = new List<Result> { player1tournament2, player2tournament2, player3tournament2, player4tournament2, player5tournament2};

            player1.Results = new List<Result> { player1tournament1, player1tournament2 };
            player2.Results = new List<Result> { player2tournament1, player2tournament2 };
            player3.Results = new List<Result> { player3tournament1, player3tournament2 };
            player4.Results = new List<Result> { player4tournament1, player4tournament2 };
            player5.Results = new List<Result> { player5tournament2 };

            var players = new List<Player> { player1, player2, player3, player4, player5 };
            return players.AsQueryable();
        }

        public Mock<ApplicationContext> ResultVenues(IQueryable<Result> data)
        {
            var mockSet = new Mock<DbSet<Result>>();
            mockSet.As<IQueryable<Result>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Result>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Result>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Result>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationContext>();
            mockContext.Setup(m => m.Set<Result>()).Returns(mockSet.Object);
            return mockContext;
        }

        public IQueryable<Result> ResultContext()
        {
            var players = PlayerContext();
            var listOfPlayers = players.SelectMany(p => p.Results);
            return listOfPlayers;
        }

        public Mock<ApplicationContext> MockVenues(IQueryable<Venue> data)
        {
            var mockSet = new Mock<DbSet<Venue>>();
            mockSet.As<IQueryable<Venue>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Venue>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Venue>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Venue>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationContext>();
            mockContext.Setup(m => m.Set<Venue>()).Returns(mockSet.Object);
            return mockContext;
        }

        public Mock<ApplicationContext> MockPlayers(IQueryable<Player> data)
        {
            var mockSet = new Mock<DbSet<Player>>();
            mockSet.As<IQueryable<Player>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Player>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Player>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Player>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationContext>();
            mockContext.Setup(m => m.Set<Player>()).Returns(mockSet.Object);
            return mockContext;
        }

        public IQueryable<Venue> VenueContext()
        {
            var venue1 = new Venue { ID = 1, Address = "Wroclaw, pl. Grunwaldzki 18", Day = DayOfWeek.Monday, Descrition = "Rejestra 30 minut przed rozpoczeciem gry", Hour = 20, Minute = 0, Name = "Klub Bilardowy" };
            var venue2 = new Venue { ID = 2, Address = "Wroclaw, Powstańców Śląskich 95", Day = DayOfWeek.Sunday, Descrition = "Rejestra 30 minut przed rozpoczeciem gry", Hour = 20, Minute = 0, Name = "Sky Tower" };
            var venue3 = new Venue { ID = 2, Address = "Wroclaw, Wystawowa 1", Day = DayOfWeek.Wednesday, Descrition = "Rejestra 30 minut przed rozpoczeciem gry", Hour = 20, Minute = 0, Name = "Hala Stulecia" };

            var venues = new List<Venue> { venue1, venue2, venue3 };
            return venues.AsQueryable();

        }

    }
}
