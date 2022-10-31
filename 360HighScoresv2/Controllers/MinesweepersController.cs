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

        public ActionResult Index()
        {
            return View(db.Minesweeper.ToList());
        }


        public ActionResult Liste()
        {
            var mine = db.Minesweeper.OrderBy(m => m.Tid);
            return View(mine);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
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

        [HttpPost, ActionName("Delete")]
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
