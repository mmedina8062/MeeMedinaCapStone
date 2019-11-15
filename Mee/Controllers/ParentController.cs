using Mee.Models;
using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        public ActionResult Delete(int id, Parent parent)
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
        public async Task<ActionResult> SendEmailToSitter(int id)
        {
            Sitter sitter = context.Sitters.Include(p => p.User).FirstOrDefault(p => p.Id == id);

            return View(sitter);

        }

        [HttpPost]
        public async Task<ActionResult> SendEmailToSitter(Sitter sitter)
        {

            var client = new SendGridClient(APIKeys.sendGridAPI);
            var from = new EmailAddress("parentsdatenights@gmail.com", "Parents");
            var subject = "Sitter Request";
            var to = new EmailAddress("sittersitters10@gmail.com", "Sitters");
            var plainTextContent = "Your Service Is Needed";
            var htmlContent = "<strong>Your service is needed, please confirm or cancel</strong><br /> https://localhost:44371/Sitter/CancelOrAccept";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            var startdate = DateTime.Today;

            return RedirectToAction("Index", "Home");
        }
        
        
        /*public ActionResult OptionToChooseSitter(Sitter sitters)
        {
            var applicationId = User.Identity.GetUserId();
            Parent parent = context.Parents.Where(p => p.ApplicationId == applicationId).FirstOrDefault();
            var loggedInParent = context.Parents.Where(p => p.ZipCode == sitters.ZipCode);
            List<Sitter> sittersByZipcode = new List<Sitter>();
            
            foreach (Sitter sitter in sittersByZipcode)
            if (parent.ZipCode == sitter.ZipCode) //.Where(p => p.ZipCode == sitter.ZipCode))
            {
                    sittersByZipcode.Add(sitter);
            }
            
            


            return View(sittersByZipcode);
        }*/
    }
}
