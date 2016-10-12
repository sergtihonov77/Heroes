using Heroes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Heroes.Controllers
{
    public class HomeController : Controller
    {
        static public ItemContext db = new ItemContext();
        static public ApplicationDbContext accdb = new ApplicationDbContext();
        static public Hero currentHero = null;
        
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
            ret = newhero;
            return ret;   
        }

        [Authorize]
        public async Task<ActionResult> MyAccount(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Hero h, model = null;

            h = await accdb.Heroes.FindAsync(id);
            model = db.HeroesList.FirstOrDefault(x => x.Description == h.Description);

            var itms = accdb.Items.Where(x => x.HeroId == h.HeroId).ToList();
            h.Items.Clear();
            h.Items = itms;

            if (h != null && h.Health == model.Health && h.Mann == model.Mann && h.Armor == model.Armor && h.Ability == model.Ability
                && h.Power == model.Power && h.Intelligence == model.Intelligence)
            {
                foreach (Item item in h.Items)
                {
                    h.Health += item.Health;
                    h.Mann += item.Mann;
                    h.Armor += item.Armor;
                    h.Ability += item.Ability;
                    h.Power += item.Power;
                    h.Intelligence += item.Intelligence;
                }
                currentHero = h;
                return View(h);
            }
            currentHero = h;
            return View(h);
        } 

        [Authorize]
        [HttpGet]
        public ActionResult CreateHero(int? id)
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
            return View("CreateHero", ret);
        }

        [Authorize]
        [HttpPost, ActionName("CreateHero")]
        public ActionResult CreateHeroConf([Bind(Include = "HeroId, Name, Race, Class, Gold, AvatarUri, Description,Health,Mann,Armor,Power,Ability,Intelligence,UserName")]Hero h)
        {
            Hero mod = null;
            mod = accdb.Heroes.FirstOrDefault(x => x.Name == h.Name);
            if (mod != null)
            {
                ModelState.AddModelError("Name", "Герой с таким именем уже есть");
            }
            if (ModelState.IsValid)
            {
                accdb.Heroes.Add(h);
                accdb.SaveChanges();
                accdb.Entry(h).State = EntityState.Modified;
                accdb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h);
        }


        public ActionResult BackToListChange()
        {
            return View("MyHeroes");
        }

        [HttpGet]
        public ActionResult Details(int? HeroId)
        {
            Hero hero = accdb.Heroes.Single(x => x.HeroId == HeroId);
            return View(hero);
        }

        public ActionResult Index( ItemContext db)
        {
            
            var H = db.HeroesList.AsNoTracking();
            ViewBag.H = H;
            ViewBag.CurrHero = (currentHero != null) ? currentHero.Name : "Герой не выбран";
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

        [Authorize]
        public ActionResult MyHeroes()
        {
            if (currentHero != null)
            {
                ViewBag.CurrHero = currentHero.Name;
            }
            string user = HttpContext.User.Identity.Name;
            var myHeroList = accdb.Heroes.Where<Hero>(x => x.UserName == user);
            return View(myHeroList);
        }

        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hero h = await accdb.Heroes.FindAsync(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            return View(h);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Hero h = await accdb.Heroes.FindAsync(id);
            accdb.Heroes.Remove(h);
            foreach (Item item in accdb.Items.Where<Item>(x => x.HeroId == h.HeroId))
            {
                accdb.Items.Remove(item);
            }
            await accdb.SaveChangesAsync();
            return RedirectToAction("MyHeroes");
        }

    }
}