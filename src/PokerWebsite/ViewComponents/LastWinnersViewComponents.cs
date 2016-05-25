using Microsoft.AspNet.Mvc;
using PokerWebsite.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerWebsite.ViewComponents
{
    public class DisplayAllPlayersViewComponents : ViewComponent
    {
        public DisplayAllPlayersViewComponents()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<Player> Player)
        {           
            return View(Player);
        }
    }
}
