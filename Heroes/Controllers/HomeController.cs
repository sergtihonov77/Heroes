using Heroes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heroes.Controllers
{
    public class HomeController : Controller
    {
        public ItemContext db = new ItemContext();

        public ActionResult IndexStart(ItemContext db)
        {
            IEnumerable<Hero> heroes = db.HeroesList;
            var H = db.HeroesList;
            return View(H);
        }

        [HttpGet]
        public ActionResult Details(int HeroId)
        {
            Hero hero = db.HeroesList.Single(x => x.HeroId == HeroId);
            //ViewData["HeroData"] = hero;
            return View(hero);
        }

        public ActionResult Index( ItemContext db)
        {
            
            var H = db.HeroesList;
            ViewBag.H = H;
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}