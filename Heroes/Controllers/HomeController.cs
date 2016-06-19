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

        public ActionResult IndexStart(ItemContext db)
        {
            IEnumerable<Hero> heroes = db.HeroesList;
            var H = db.HeroesList;
            return View(H);
        }

        [HttpGet]
        public ActionResult ChangeHero(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Hero newhero, model, ret = null;

            switch (id)
            {
                
                case 1:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {   
                        Name = "",
                        Race = Races.Human,
                        Class = Clases.Warior,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 2:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Elf,
                        Class = Clases.Wizard,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 3:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Orc,
                        Class = Clases.Healer,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 6:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Human,
                        Class = Clases.Archer,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 7:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Human,
                        Class = Clases.Healer,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 5:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Human,
                        Class = Clases.Wizard,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 8:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Elf,
                        Class = Clases.Warior,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 9:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Elf,
                        Class = Clases.Archer,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 10:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Elf,
                        Class = Clases.Healer,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 11:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Orc,
                        Class = Clases.Warior,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 12:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Orc,
                        Class = Clases.Wizard,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 13:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Orc,
                        Class = Clases.Archer,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 14:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Undead,
                        Class = Clases.Warior,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 15:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Undead,
                        Class = Clases.Wizard,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 16:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Undead,
                        Class = Clases.Archer,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;
                case 21:
                    model = db.HeroesList.FirstOrDefault(x => x.HeroId == id);
                    newhero = new Hero
                    {
                        Name = "",
                        Race = Races.Undead,
                        Class = Clases.Healer,
                        AvatarUri = model.AvatarUri,
                        Gold = model.Gold,
                        Description = model.Description,
                        Health = model.Health,
                        Mann = model.Mann,
                        Armor = model.Armor,
                        Power = model.Power,
                        Ability = model.Ability,
                        Intelligence = model.Intelligence
                    };
                    accdb.Heroes.Add(newhero);
                    accdb.SaveChanges();
                    ret = newhero;
                    break;

            }
            return View(ret);
        }

        [HttpPost]
        public ActionResult ChangeHero([Bind(Include = "HeroId, Name, Race, Class, Gold, AvatarUri, Description,Health,Mann,Armor,Power,Ability,Intelligence")]Hero h)
        {
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
    }
}