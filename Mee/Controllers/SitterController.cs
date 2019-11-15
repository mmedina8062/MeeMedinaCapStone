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
    public class SitterController : Controller
    {
        ApplicationDbContext context;
        public SitterController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Parent
        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            var sitter = context.Sitters.ToList();
            return View(sitter);
        }

        // GET: Parent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sitter sitter = context.Sitters.Find(id);
            if (sitter == null)
            {
                return HttpNotFound();
            }
            return View(sitter);
        }

        // GET: Parent/Create
        public ActionResult Create()
        {
            Sitter sitter = new Sitter();
            return View(sitter);
        }

        // POST: Parent/Create
        [HttpPost]
        public ActionResult Create(Sitter sitter)
        {
            try
            {
                sitter.ApplicationId = User.Identity.GetUserId();
                context.Sitters.Add(sitter);
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
            Sitter sitter = context.Sitters.Find(id);
            if (sitter == null)
            {
                return HttpNotFound();
            }
            return View(sitter);
        }

        // POST: Parent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Sitter sitter)
        {
            if (ModelState.IsValid)
                try
                {
                    // TODO: Add update logic here
                    context.Entry(sitter).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(HttpNotFound());
                }
            return View(sitter);
        }

        // GET: Parent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sitter deletedSitter = context.Sitters.Find(id);
            if (deletedSitter == null)
            {
                return HttpNotFound();
            }
            return View(deletedSitter);
        }

        // POST: Parent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Sitter sitter)
        {
            try
            {
                Sitter deletedSitter = context.Sitters.Find(id);
                context.Sitters.Remove(deletedSitter);
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
