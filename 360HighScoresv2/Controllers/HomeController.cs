using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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
        
        [HttpPost]
        
        public ActionResult Indsendscore(HttpPostedFileBase file)
        
        
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = Path.Combine(Server.MapPath("~/Billeder"), filename);
                    file.SaveAs(filepath);
                }
                ViewBag.Message = "Billedet er indsendt korrekt!";
                return View();
            }

            catch
            {
                ViewBag.Message = "Billedet er ikke indsendt korrekt!";
                return View();
            }
            
            
        }

    }
}