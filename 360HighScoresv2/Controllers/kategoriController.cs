using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _360HighScoresv2.Models;

namespace _360HighScoresv2.Controllers
{
    public class kategoriController : Controller
    {
        private Entities db = new Entities();
        // GET: kategori
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TetrisLB()
        {

            
            var tetris = db.Tetris.OrderByDescending(m => m.Point);
            return View(tetris);
        
        }
        
        }
    }
