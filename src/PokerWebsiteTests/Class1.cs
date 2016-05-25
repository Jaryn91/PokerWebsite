using Microsoft.Data.Entity;
using Moq;
using PokerWebsite.Core.Domain;
using PokerWebsite.Core.Repositories;
using PokerWebsite.ModelView;
using PokerWebsite.Persistence;
using PokerWebsite.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PokerWebsiteTests
{
    public class Class1
    {
        [Fact]
        public void order_players_by_amount_points_in_season()
        {
            var testContext = new TestContext();
            var data = testContext.PlayerContext();
            var mockContext = testContext.MockPlayers(data);
            var playerRepository = new PlayerRepository(mockContext.Object);

            var actualStatistics = playerRepository.GetTopSeasonPlayers(2016, 1, 10);

            var expectedStatistics = new List<PlayerStatistics>() {
                new PlayerStatistics("Michał", "Wiśniewski", 17.5, 35),
                new PlayerStatistics("Andrzej", "Gołota", 15, 30),
                new PlayerStatistics("Zdzisław", "Kręcina", 25, 25),
                new PlayerStatistics("Andrzej", "Duda", 10, 20),
                new PlayerStatistics("Maryla", "Rodowicz", 7.5, 15)
            };

            Assert.Equal(expectedStatistics, actualStatistics);
        }

        [Fact]
        public void order_players_by_average_points_in_season()
        {
            var testContext = new TestContext();
            var data = testContext.PlayerContext();
            var mockContext = testContext.MockPlayers(data);
            var playerRepository = new PlayerRepository(mockContext.Object);

            var actualStatistics = playerRepository.GetTopAverageSeasonPlayers(2016, 1, 10);

            var expectedStatistics = new List<PlayerStatistics>() {
                new PlayerStatistics("Zdzisław", "Kręcina", 25, 25),
                new PlayerStatistics("Michał", "Wiśniewski", 17.5, 35),
                new PlayerStatistics("Andrzej", "Gołota", 15, 30),
                new PlayerStatistics("Andrzej", "Duda", 10, 20),
                new PlayerStatistics("Maryla", "Rodowicz", 7.5, 15)
            };

            Assert.Equal(expectedStatistics, actualStatistics);
        }

        [Fact]
        public void venus_are_ordered_by_day_of_week()
        {
            var testContext = new TestContext();
            var data = testContext.VenueContext();
            var mockContext = testContext.MockVenues(data);
            var veunesRepository = new VenueRepository(mockContext.Object);

            var orderedVenues = veunesRepository.OrderByDay();

            Assert.Equal(data.ElementAt(0), orderedVenues.ElementAt(0));
            Assert.Equal(data.ElementAt(2), orderedVenues.ElementAt(1));
            Assert.Equal(data.ElementAt(1), orderedVenues.ElementAt(2));
        }

        [Fact]
        public void results_for_player()
        {
            var testContext = new TestContext();
            var data = testContext.PlayerContext();
            var mockContext = testContext.MockPlayers(data);
            var playerRepository = new PlayerRepository(mockContext.Object);

            var player0 = data.ElementAt(0);
            var resultsForPlayer0 = playerRepository.GetPlayersResuls(player0, 2016, 1);

            var player1 = data.ElementAt(0);
            var resultsForPlayer1 = playerRepository.GetPlayersResuls(player1, 2016, 1);

            var player2 = data.ElementAt(0);
            var resultsForPlayer2 = playerRepository.GetPlayersResuls(player2, 2016, 1);

            var player3 = data.ElementAt(0);
            var resultsForPlayer3 = playerRepository.GetPlayersResuls(player3, 2016, 1);

            var player4 = data.ElementAt(0);
            var resultsForPlayer4 = playerRepository.GetPlayersResuls(player4, 2016, 1);

            Assert.Equal(2, resultsForPlayer0.Count());
            Assert.Equal(2, resultsForPlayer1.Count());
            Assert.Equal(2, resultsForPlayer2.Count());
            Assert.Equal(2, resultsForPlayer3.Count());
            Assert.Equal(1, resultsForPlayer4.Count());
        }
    }


}
