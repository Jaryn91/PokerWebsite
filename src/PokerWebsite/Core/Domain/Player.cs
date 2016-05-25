using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Core.Domain
{
    public class Player
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<PlayerAchievement> PlayerAchievements { get; set; }

        public IEnumerable<Result> GetSeasonResults(int year, int season)
        {
            if (Results != null)
            {
                var results = Results.Where(r => r.Tournament.Season == season && r.Tournament.Year == year);
                return results;
            }
            return null;
        }

        public IEnumerable<Result> GetSeasonResultsForVenue(Venue venue, int year, int season)
        {
            var seasonResults = GetSeasonResults(year, season);
            if (seasonResults != null)
            {
                var results = seasonResults.Where(r => r.Tournament.Venue.ID == venue.ID);
                return results;
            }
            return null;
        }
    }
}
