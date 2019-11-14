using Mee.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            return View(parent);
        } 

        // GET: Parent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent parent = context.Parents.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        // GET: Parent/Create
        public ActionResult Create()
        {
            Parent parent = new Parent();
            return View(parent);
        }

        // POST: Parent/Create
        [HttpPost]
        public ActionResult Create(Parent parent)
        {
            try
            {
                parent.ApplicationId = User.Identity.GetUserId();
                context.Parents.Add(parent);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return HttpNotFound();
            }
        }

        // GET: Parent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent parent = context.Parents.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        // POST: Parent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Parent parent)
        {
            if (ModelState.IsValid)
                try
                {
                    // TODO: Add update logic here
                    context.Entry(parent).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(HttpNotFound());
                }
            return View(parent);
        }

        // GET: Parent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent deletedparent = context.Parents.Find(id);
            if (deletedparent == null)
            {
                return HttpNotFound();
            }
            return View(deletedparent);
        }

        // POST: Parent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Parent deletedparent = context.Parents.Find(id);
                context.Parents.Remove(deletedparent);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(HttpNotFound());
            }
        }
    }
}
