using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Core.Domain
{
    public class Achievement
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public string SPName { get; set; }
        public virtual ICollection<PlayerAchievement> PlayerAchievements { get; set; }
    }

}
