using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace memberDatabasetest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult index() //home page
        {
            return View();
        }

        public ActionResult join()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult officers()
        {
            return View();
        }

        public ActionResult leadershipopportunities()
        {
            return View();
        }

        public ActionResult physicianshadowing()
        {
            return View();
        }

        public ActionResult mcat()
        {
            return View();
        }

        public ActionResult research()
        {
            return View();
        }

        public ActionResult volunteeropportunities()
        {
            return View();
        }
    }
}