using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PokerWebsite.Persistence;
using PokerWebsite.Core.Domain;
using PokerWebsite.Core.Validation;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PokerWebsite.Controllers
{
    public class VenueController : Controller
    {
        public IActionResult Index()
        {
            var venues = new List<Venue>();
            using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
            {
                // Example1
                venues = unitOfWork.Venues.GetAll().ToList();
            }
            return View(venues);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentMasters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
                {
                    var validation = new VenueValidation();
                    var result = validation.Validate(venue);
                    if (result.IsValid)
                    {
                        unitOfWork.Venues.Add(venue);
                        unitOfWork.Complete();
                        return RedirectToAction("Index");
                    }
                }                
            }
            return View(venue);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Venue player = null;
            using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
            {
                player = unitOfWork.Venues.Get((int)id);
            }

            if (player == null)
            {
                return HttpNotFound();
            }

            return View(player);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Venue player)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
        //        {
        //            var playerToUpdate = unitOfWork.Venues.Get(player.ID);
        //            playerToUpdate.Mobile = player.Mobile;
        //            playerToUpdate.Name = player.Name;
        //            playerToUpdate.Surname = player.Surname;
        //            playerToUpdate.Email = player.Email;
        //            unitOfWork.Complete();
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(player);
        //}
    }
}
