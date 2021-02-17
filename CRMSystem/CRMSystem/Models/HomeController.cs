using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMSystem.Models;
using System.Data.Entity;

namespace CRMSystem.Models
{
    public class HomeController : Controller
    {
        CRM_System1Entities db = new CRM_System1Entities();
        // GET: Home
        public ActionResult Index()
        {
            var techlist = db.tblTechnologies.ToList();
            return View(techlist);
        }
        [HttpGet]
        public ActionResult AddTechnology()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTechnology(tblTechnology tech)
        {
            db.tblTechnologies.Add(tech);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult EditTechnology(int id)
        {
            var tech = db.tblTechnologies.Find(id);
            return View(tech);
        }
        [HttpPost]
        public ActionResult EditTechnology(tblTechnology tech)
        {
            db.Entry(tech).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }
    }
}