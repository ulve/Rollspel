using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Rollspel.Models;
using MongoDB.Driver.Builders;

namespace Rollspel.Controllers
{
    public class PlatsController : Controller
    {
        // GET: Plats
        public ActionResult Index()
        {
            var platsRepo = GetPlatsRepository();
            var lista = platsRepo.FindAll().ToList();            
            
            return View(lista);
        }

        private static MongoCollection<Plats> GetPlatsRepository()
        {
            MongoClient client = new MongoClient();
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("platser");


            var collection = db.GetCollection<Plats>("plats");
            return collection;
        }

        // GET: Plats/Details/5
        public ActionResult Details(string id)
        {
            var repo = GetPlatsRepository();
            var plats = repo.AsQueryable<Plats>().Where(p => p.Id == ObjectId.Parse(id)).First();
            return View(plats);
        }

        // GET: Plats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plats/Create
        [HttpPost]
        public ActionResult Create(Plats plats)
        {
            try
            {                
                var c = GetPlatsRepository();
                c.Insert(plats);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Plats/Edit/5
        public ActionResult Edit(string id)
        {
            var repo = GetPlatsRepository();
            var plats = repo.AsQueryable<Plats>().Where(p => p.Id == ObjectId.Parse(id)).First();
            
            return View(plats);
        }

        // POST: Plats/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Plats plats)
        {
            try
            {
                var repo = GetPlatsRepository();
                plats.Id = ObjectId.Parse(id);
                repo.Save(plats);
            
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Plats/Delete/5
        public ActionResult Delete(string id)
        {            
            return View();
        }

        // POST: Plats/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                var repo = GetPlatsRepository();
                var query = Query<Plats>.EQ(p => p.Id, ObjectId.Parse(id));
                repo.Remove(query);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
