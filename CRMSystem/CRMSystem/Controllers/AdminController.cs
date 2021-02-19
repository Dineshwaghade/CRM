using CRMSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSystem.Controllers
{
    public class AdminController : Controller
    {
        CRM_System1Entities db = new CRM_System1Entities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddTechnology()
        {
            ViewBag.list = db.tblTechnologies.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddTechnology(tblTechnology tech)
        {

            db.tblTechnologies.Add(tech);
            db.SaveChanges();
            ViewBag.success = "Added successfully!";
            ViewBag.list = db.tblTechnologies.ToList();

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
            return RedirectToAction("AddTechnology");
        }
        public ActionResult DeleteTechnology(int id)
        {
    //        var cat = db.tblTechnologies.Find(id);
            db.tblTechnologies.Remove(db.tblTechnologies.Find(id));
            db.SaveChanges();
            return RedirectToAction("AddTechnology");
        }

    }
}