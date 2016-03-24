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
    }
}
