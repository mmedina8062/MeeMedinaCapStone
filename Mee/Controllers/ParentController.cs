using Mee.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mee.Controllers
{
    public class ParentController : Controller
    {
        ApplicationDbContext context;
        public ParentController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Parent
        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            var parent = context.Parents.ToList();
            return View();
        }

        // GET: Parent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Parent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parent/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Parent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
