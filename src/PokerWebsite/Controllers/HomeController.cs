using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PokerWebsite.Persistence.Repositories;
using PokerWebsite.Persistence;

namespace PokerWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
            {
                // Example1
                var players = unitOfWork.Players.GetAll();
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
