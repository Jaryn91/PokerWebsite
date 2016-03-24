using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Core.Domain
{
    public class Tournament
    {
        public Tournament() { }
        public int ID { get; set; }
        public int NumberOfPlayers { get; set; }
        public int Year { get; set; }
        public int Season { get; set; }
        public Image WinnerImage { get; set; }
        public virtual ICollection<Result> Results { get; set; }     
    }
}
