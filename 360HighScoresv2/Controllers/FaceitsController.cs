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

        // GET: Faceits
        public ActionResult Index()
        {
            var Csgo = db.Faceit.OrderByDescending(m => m.Elo);
            return View(Csgo);
        }

        // GET: Faceits/Details/5
        public ActionResult Details(int? id)
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

        // GET: Faceits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faceits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Faceits/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Faceits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Navn,Elo")] Faceit faceit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faceit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faceit);
        }

        // GET: Faceits/Delete/5
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

        // POST: Faceits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
