using Microsoft.Data.Entity;
using PokerWebsite.Core.Domain;
using PokerWebsite.Core.Repositories;
using PokerWebsite.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Persistence.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbContext context) : base(context)
        {

        }

        public ApplicationContext ApplicationContext
        {
            get { return Context as ApplicationContext; }
        }

        public IEnumerable<PlayerStatistics> GetTopSeasonPlayers(int year, int season, int top)
        {
            var playersStatistics = new List<PlayerStatistics>();
            var players = GetAll();
            foreach (var player in players)
            {
                var results = player.GetSeasonResults(year, season);
                var playerStats = new PlayerStatistics(player, results);
                playersStatistics.Add(playerStats);
            }
            return playersStatistics.OrderByDescending(p => p.Sum).Take(top).ToList();
        }

        public IEnumerable<PlayerStatistics> GetTopPlayersInVenue(Venue venue, int year, int season, int top)
        {
            var playersStatistics = new List<PlayerStatistics>();
            var players = GetAll();
            foreach (var player in players)
            {
                var results = player.GetSeasonResultsForVenue(venue, year, season);
                var playerStats = new PlayerStatistics(player, results);
                playersStatistics.Add(playerStats);
            }
            return playersStatistics.OrderByDescending(p => p.Sum).Take(top).ToList();
        }
    }
}
