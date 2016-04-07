using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Core.Domain
{
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Place { get; set; }
        public int Points { get; set; }

        public int PlayerID { get; set; }
        public Player Player { get; set; }
        public int TournamentID { get; set; }
        public Tournament Tournament { get; set; }
    }
}
