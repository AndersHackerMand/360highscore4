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

        // GET: Tetris
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
        // GET: Tetris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tetris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        

        
        // GET: Tetris/Edit/5
        

        // POST: Tetris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Navn,Point,ID")] Tetris tetris)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tetris).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tetris);
        }

        // GET: Tetris/Delete/5
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

        // POST: Tetris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
