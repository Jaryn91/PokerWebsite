using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Core.Domain
{
    public class Venue
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Descrition { get; set; }
        public DayOfWeek Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public Image Image { get; set; }
    }
}
