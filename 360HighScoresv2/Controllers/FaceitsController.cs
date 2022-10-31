using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _360HighScoresv2.Models;

namespace _360HighScoresv2.Controllers
{
    public class FaceitsController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            var Csgo = db.Faceit.OrderByDescending(m => m.Elo);
            return View(Csgo);
        }
        public ActionResult Liste()
        {
            var Csgo = db.Faceit.OrderByDescending(m => m.Elo);
            return View(Csgo);
        }

        

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Create([Bind(Include = "ID,Navn,Elo")] Faceit faceit)
        {
            if (ModelState.IsValid)
            {
                db.Faceit.Add(faceit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faceit);
        }

       


        


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faceit faceit = db.Faceit.Find(id);
            if (faceit == null)
            {
                return HttpNotFound();
            }
            return View(faceit);
        }


        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            Faceit faceit = db.Faceit.Find(id);
            db.Faceit.Remove(faceit);
            db.SaveChanges();
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
    }
}
