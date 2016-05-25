using Microsoft.Data.Entity;
using PokerWebsite.Core.Domain;
using PokerWebsite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Persistence.Repositories
{
    public class ResultRepository : Repository<Result>, IResultRepository
    {
        public ResultRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Result> GetResults(Player player, int year, int season)
        {
            var results = GetAll();
            var filtredResults = results.Where(r => r.PlayerID == player.ID && r.Tournament.Year == year && r.Tournament.Season == season).ToList();
            return filtredResults;
        }
    }
}
