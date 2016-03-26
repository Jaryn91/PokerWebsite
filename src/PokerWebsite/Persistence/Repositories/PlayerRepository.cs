using Microsoft.Data.Entity;
using PokerWebsite.Core.Domain;
using PokerWebsite.Core.Repositories;
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
    }
}
