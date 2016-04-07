using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Core.Domain
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<PlayerAchievement> PlayerAchievements { get; set; }


        public IEnumerable<Result> GetSeasonResults(int year, int season)
        {
            var results = Results.Where(r => r.Tournament.Season == season && r.Tournament.Year == year);
            return results;
        }

        public IEnumerable<Result> GetSeasonResultsForVenue(Venue venue, int year, int season)
        {
            var seasonResults = GetSeasonResults(year, season);
            var results = seasonResults.Where(r => r.Tournament.Venue.ID == venue.ID);
            return results;
        }
    }
}
