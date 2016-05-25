using Microsoft.Data.Entity;
using PokerWebsite.Core.Domain;
using PokerWebsite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Persistence.Repositories
{
    public class VenueRepository : Repository<Venue>, IVenueRepository
    {
        public VenueRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Venue> OrderByDay()
        {
            var venues = GetAll();
            var sortedVenues = venues.OrderBy(v => ((int)v.Day + 6) % 7).
                                        ThenBy(v => v.Hour).
                                        ThenBy(v => v.Minute).
                                        ThenBy(v => v.Name).ToList();
            return sortedVenues;
        }
    }
}
