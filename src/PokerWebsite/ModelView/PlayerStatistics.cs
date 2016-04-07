using PokerWebsite.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.ModelView
{
    public class PlayerStatistics
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Average { get; set; }
        public int Sum { get; set; }

        public PlayerStatistics(Player player, IEnumerable<Result> results)
        {
            Name = player.Name;
            Surname = player.Surname;

            var sum = results.Sum(r => r.Points);
            Sum = sum;

            var average = sum / results.Count();
            Average = average;
        }
    }
}
