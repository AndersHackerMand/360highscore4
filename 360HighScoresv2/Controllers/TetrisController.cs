using System.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _360HighScoresv2.Models;
using System.Net.Mail;
using System.Net.Configuration;
using System.Configuration;



namespace _360HighScoresv2.Controllers
{
    public class TetrisController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            var tetris = db.Tetris.OrderByDescending(m => m.Point);
            return View(tetris);
        }
       
        public ActionResult Liste()
        {
            var tetris = db.Tetris.OrderByDescending(m => m.Point);
            return View(tetris);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Navn,Point,ID")] Tetris tetris)
        {
            if (ModelState.IsValid)
            {
                db.Tetris.Add(tetris);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tetris);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tetris tetris = db.Tetris.Find(id);
            if (tetris == null)
            {
                return HttpNotFound();
            }
            return View(tetris);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            Tetris tetris = db.Tetris.Find(id);
            db.Tetris.Remove(tetris);
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
