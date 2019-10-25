using SuperHero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHero.Controllers
{
    public class HeroController : Controller
    {



        ApplicationDbContext context;
        public HeroController()
        {
            context = new ApplicationDbContext();
        }

       
        
        // GET: Hero
        public ActionResult Index()
        {
            
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            List<Hero> heroes = context.Heroes.ToList();
            return View(heroes);
        }
        

        // GET: Hero/Details/5
        public ActionResult Details(int id)
        {
            Hero hero = context.Heroes.Where(h => h.Id == id).FirstOrDefault();

            return View(hero);
        }

        // GET: Hero/Create
        public ActionResult Create()
        {
            Hero hero = new Hero();
            return View(hero);
        }

        // POST: Hero/Create
        [HttpPost]
        public ActionResult Create(Hero hero)
        {
            try
            {
                // TODO: Add insert logic here
                context.Heroes.Add(hero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hero/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Hero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Hero hero)
        {
            try
            {
                var edithero = context.Heroes.Where(h => h.Id == id).FirstOrDefault();
                edithero.firstName = hero.firstName;
                edithero.lastName = hero.lastName;
                edithero.primaryPower = hero.primaryPower;
                edithero.secondaryPower = hero.secondaryPower;
                edithero.catchphrase = hero.catchphrase;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(id);
            }
        }

        // GET: Hero/Delete/5
        public ActionResult Delete(int id)
        {
            Hero hero = context.Heroes.Where(h => h.Id == id).FirstOrDefault();

            return View(hero);
        }

        // POST: Hero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Hero hero)
        {
            try
            {
                hero = context.Heroes.Where(h => h.Id == id).FirstOrDefault();
                context.Heroes.Remove(hero);
                context.SaveChanges();



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
