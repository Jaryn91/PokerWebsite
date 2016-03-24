using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Core.Domain
{
    public class PlayerAchievement
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

        public Player Player { get; set; }
        public int PlayerID { get; set; }

        public Achievement Achievement { get; set; }
        public int AchievementID { get; set; }
    }
}
