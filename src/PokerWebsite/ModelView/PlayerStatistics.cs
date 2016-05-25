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
        public double Average { get; set; }
        public int Sum { get; set; }

        public PlayerStatistics(Player player, IEnumerable<Result> results)
        {
            Name = player.Name;
            Surname = player.Surname;

            var sum = results.Sum(r => r.Points);
            Sum = sum;

            var average = (double) sum / results.Count();
            Average = average;
        }

        public PlayerStatistics(string name, string surname, double average, int sum)
        {
            Name = name;
            Surname = surname;
            Average = average;
            Sum = sum;
        }


        public override bool Equals(object obj)
        {
            var toCompareWith = obj as PlayerStatistics;
            if (toCompareWith == null)
                return false;
            return this.Name == toCompareWith.Name &&
                this.Surname == toCompareWith.Surname &&
                this.Sum == toCompareWith.Sum &&
                this.Average == toCompareWith.Average;          
        }
    }
}
