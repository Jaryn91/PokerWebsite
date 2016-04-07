using Microsoft.Data.Entity;
using PokerWebsite.Core.Domain;
using PokerWebsite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Persistence.Repositories
{
    public class TournamentRepository : Repository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(DbContext context) : base(context)
        {

        }
    }
}
