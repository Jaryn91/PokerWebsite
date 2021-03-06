﻿using PokerWebsite.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Core.Repositories
{
    public interface IVenueRepository : IRepository<Venue>
    {
        IEnumerable<Venue> OrderByDay();
    }
}
