using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Heroes.Models;
using Heroes.Controllers;

namespace Heroes.Controllers
{
    public class ShopController : Controller
    {
        private ItemContext db = new ItemContext();
        private ApplicationDbContext accdb = new ApplicationDbContext();

        public async Task<ActionResult> Sale()
        {

            if (HomeController.currentHero != null)
            {
                var h = HomeController.currentHero;
                return View(await accdb.Items.Where(x => x.HeroId == h.HeroId).ToListAsync());
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: Shop
        public async Task<ActionResult> Index()
        {
            return View(await db.ItemsList.ToListAsync());
        }

        // GET: Shop/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.ItemsList.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Description,Mark,ItemClass,IconUri,PurchacePrace,SalePrice,Health,Mann,Armor,Power,Ability,Intelligence")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.ItemsList.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Shop/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.ItemsList.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Shop/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Description,Mark,ItemClass,IconUri,PurchacePrace,SalePrice,Health,Mann,Armor,Power,Ability,Intelligence")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Shop/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.ItemsList.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Item item = await db.ItemsList.FindAsync(id);
            db.ItemsList.Remove(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public async Task<ActionResult> PartrialDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.ItemsList.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);

        }

        public async Task<ActionResult> BuyItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = await db.ItemsList.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            Hero h = null;
            if (HomeController.currentHero != null)
            {

                if (HomeController.currentHero.Gold >= item.PurchacePrace)
                {
                    h = await accdb.Heroes.FindAsync(HomeController.currentHero.HeroId);
                    item.HeroId = h.HeroId;
                    h.Gold = h.Gold - item.PurchacePrace;
                    accdb.Entry(h).State = EntityState.Modified;
                    accdb.Items.Add(item);
                    accdb.SaveChanges();
                }
                else
                {
                    ViewBag.ManyError = "Не хватает денег";
                }
            } 
            else
            {
                ViewBag.NullHeroErr = "Герой невыбран";            
            }
            return View("Details",item);

        }

        public async Task<ActionResult> SaleItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = await accdb.Items.FindAsync(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            Hero h = null;
            if (HomeController.currentHero != null)
            {
                h = await accdb.Heroes.FindAsync(HomeController.currentHero.HeroId);
                h.Gold = h.Gold + (item.PurchacePrace / 2);
                accdb.Entry(h).State = EntityState.Modified;
                accdb.Items.Remove(item);
                accdb.SaveChanges();      
            }
            else
            {
                ViewBag.NullHeroErr = "Герой невыбран";
            }
            return View("Details", item);

        }

    }
}
