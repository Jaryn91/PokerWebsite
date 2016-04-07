using PokerWebsite.Core.Domain;
using PokerWebsite.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Core.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        IEnumerable<PlayerStatistics> GetTopSeasonPlayers(int year, int season, int top);
        IEnumerable<PlayerStatistics> GetTopPlayersInVenue(Venue venue, int year, int season, int top);
    }
}