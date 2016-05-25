using Microsoft.AspNet.Mvc;
using PokerWebsite.Core.Domain;
using PokerWebsite.Core.Validation;
using PokerWebsite.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerWebsite.Controllers
{
    public class PlayerController : Controller
    {

        public List<Result> GetResultsForPlayer()
        {
            var Tournament1 = new Tournament() { Date = new DateTime(2016, 4, 4) };
            var Tournament2 = new Tournament() { Date = new DateTime(2016, 4, 11) };
            var Tournament3 = new Tournament() { Date = new DateTime(2016, 4, 18) };
            var results = new List<Result>()
            {
                new Result() { Points = 20, Place = 3, Tournament = Tournament1 },
                new Result() { Points = 15, Place = 4, Tournament = Tournament2 },
                new Result() { Points = 25, Place = 2, Tournament = Tournament3 }
            };

            return results;
        }

        public IActionResult Chart(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var results = new List<Result>();
            Player player = null;
            using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
            {
                player = unitOfWork.Players.Get((int)id);
                if (player == null)
                {
                    return HttpNotFound();
                }

                var enumerableResults = player.GetSeasonResults(2016, 1);
                if (enumerableResults == null)
                {
                    return HttpNotFound();
                }

                results = enumerableResults.ToList();
            }         
            return View(results);
        }

        public IActionResult Index()
        {
            var players = new List<Player>();
            using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
            {
                 players = unitOfWork.Players.GetAll().ToList();
            }
            return View(players);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentMasters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
                {
                    var validation = new PlayerValidation();
                    var result = validation.Validate(player);
                    if (result.IsValid)
                    {
                        unitOfWork.Players.Add(player);
                        unitOfWork.Complete();
                        return RedirectToAction("Index");
                    }
                }               
            }
            return View(player);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Player player = null;
            using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
            {
                player = unitOfWork.Players.Get((int)id);                   
            }

            if (player == null)
            {
                return HttpNotFound();
            }

            return View(player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
                {
                    var playerToUpdate = unitOfWork.Players.Get(player.ID);
                    playerToUpdate.Mobile = player.Mobile;
                    playerToUpdate.Name = player.Name;
                    playerToUpdate.Surname = player.Surname;
                    playerToUpdate.Email = player.Email;
                    unitOfWork.Complete();
                }
                return RedirectToAction("Index");
            }
            return View(player);
        }
    }
}
