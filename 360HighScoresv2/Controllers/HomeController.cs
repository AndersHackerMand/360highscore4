using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace _360HighScoresv2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kategorier() {
            return View();
        }
        public ActionResult AdminKategorier()
        {
            return View();
        }

        public ActionResult Indsendscore()
        {

            return View();
        }

        
    }
}