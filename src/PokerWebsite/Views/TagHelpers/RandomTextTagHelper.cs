using Microsoft.AspNet.Razor.TagHelpers;
using PokerWebsite.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerWebsite.Views.TagHelpers
{
    [HtmlTargetElement("players", Attributes = PlayersArrtibuteName)]
    public class RandomTextTagHelper : TagHelper
    {
        private const string PlayersArrtibuteName = "win";

        [HtmlAttributeName(PlayersArrtibuteName)]
        public IEnumerable<Player> Players  { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var players = Players.ToList();
            Random rnd = new Random();
            int r = rnd.Next(players.Count);
            output.Content.SetContent("Today will win: " + players[r].Name);            
        }
    }  
}
