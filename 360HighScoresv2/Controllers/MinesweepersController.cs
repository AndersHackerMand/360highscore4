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
    public class MinesweepersController : Controller
    {
        private Entities db = new Entities();

        // GET: Minesweepers
        public ActionResult Index()
        {
            return View(db.Minesweeper.ToList());
        }


        public ActionResult Liste()
        {
            var mine = db.Minesweeper.OrderBy(m => m.Tid);
            return View(mine);
        }

        // GET: Minesweepers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Minesweepers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Navn,Tid")] Minesweeper minesweeper)
        {
            if (ModelState.IsValid)
            {
                db.Minesweeper.Add(minesweeper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(minesweeper);
        }

        // GET: Minesweepers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Minesweeper minesweeper = db.Minesweeper.Find(id);
            if (minesweeper == null)
            {
                return HttpNotFound();
            }
            return View(minesweeper);
        }

        // POST: Minesweepers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Minesweeper minesweeper = db.Minesweeper.Find(id);
            db.Minesweeper.Remove(minesweeper);
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
