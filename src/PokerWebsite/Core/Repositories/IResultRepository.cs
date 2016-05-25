using PokerWebsite.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Core.Repositories
{
    interface IResultRepository : IRepository<Result>
    {
        IEnumerable<Result> GetResults(Player player, int year, int season);
    }
}
