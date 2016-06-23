using Heroes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Heroes.Controllers
{
    public class HomeController : Controller
    {
        public ItemContext db = new ItemContext();
        public ApplicationDbContext accdb = new ApplicationDbContext();
        public Hero currentHero = null;
        


        public Hero CreateFromModel(int id)
        {
            Hero newhero, ret, model = null;
            model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
            newhero = new Hero
            {
                Name = "",
                Race = model.Race,
                Class = model.Class,
                AvatarUri = model.AvatarUri,
                Gold = model.Gold,
                Description = model.Description,
                Health = model.Health,
                Mann = model.Mann,
                Armor = model.Armor,
                Power = model.Power,
                Ability = model.Ability,
                Intelligence = model.Intelligence,
                UserName = HttpContext.User.Identity.Name
        };

            if (ModelState.IsValid)
            {
                accdb.Heroes.Add(newhero);
                accdb.SaveChanges();
                accdb.Dispose();
                ret = newhero;
                return ret;
            }
            return null;   
        }

        public ActionResult IndexStart(ItemContext db)
        {
            IEnumerable<Hero> heroes = db.HeroesList;
            var H = db.HeroesList;
            return View(H);
        }

        [Authorize]
        [HttpGet]
        public ActionResult ChangeHero(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Hero ret = null;

            switch (id)
            {               
                case 1:
                    ret = CreateFromModel(1);
                    break;
                case 2:
                    ret = CreateFromModel(2);
                    break;
                case 3:
                    ret = CreateFromModel(3);
                    break;
                case 4:
                    ret = CreateFromModel(4);
                    break;
                case 5:
                    ret = CreateFromModel(5);
                    break;
                case 6:
                    ret = CreateFromModel(6);
                    break;
                case 7:
                    ret = CreateFromModel(7);
                    break;
                case 8:
                    ret = CreateFromModel(8);
                    break;
                case 9:
                    ret = CreateFromModel(9);
                    break;
                case 10:
                    ret = CreateFromModel(10);
                    break;
                case 11:
                    ret = CreateFromModel(11);
                    break;
                case 12:
                    ret = CreateFromModel(12);
                    break;
                case 13:
                    ret = CreateFromModel(13);
                    break;
                case 14:
                    ret = CreateFromModel(14);
                    break;
                case 15:
                    ret = CreateFromModel(15);
                    break;
                case 16:
                    ret = CreateFromModel(16);
                    break;
            }
            return View(ret);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangeHero([Bind(Include = "HeroId, Name, Race, Class, Gold, AvatarUri, Description,Health,Mann,Armor,Power,Ability,Intelligence,UserName")]Hero h)
        {
            Hero mod = null;
            mod = accdb.Heroes.FirstOrDefault(x => x.Name == h.Name);
            if (mod != null)
            {
                ModelState.AddModelError("Name", "Герой с таким именем уже есть");
            }
            if (ModelState.IsValid)
            {
                accdb.Entry(h).State = EntityState.Modified;
                accdb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h);
        }

        public ActionResult BackToListChange(int? id)
        {
            Hero dlt = accdb.Heroes.Find(id);
            accdb.Heroes.Remove(dlt);
            accdb.SaveChanges();
            return View("Index");
        }

        [HttpGet]
        public ActionResult Details(int? HeroId)
        {
            Hero hero = accdb.Heroes.Single(x => x.HeroId == HeroId);
            return View(hero);
        }

        public ActionResult Index( ItemContext db)
        {
            
            var H = db.HeroesList;
            ViewBag.H = H;
            ViewBag.Accid = HttpContext.User.Identity.Name;
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

        public ActionResult MyHeroes()
        {
        string user = HttpContext.User.Identity.Name;
        var myHeroList = accdb.Heroes.Where<Hero>(x => x.UserName == user);
            return View(myHeroList);
        }
    }
}