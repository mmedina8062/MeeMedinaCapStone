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
    public class SitterController : Controller
    {
        ApplicationDbContext context;
        public SitterController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Parent
        public ActionResult Index(string searchBy, string search)
        {
            if(searchBy == "Zip Code")
            {
                return View(context.Sitters.Where(s => s.ZipCode.ToString() == search).ToList());
            }
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
        public ActionResult CancelOrAccept()
        {
            return View();
        }

        /*[HttpPost]
        public ActionResult CancelOrAccept(Parent parent)
        {
            if (Sitter.Confirm == true)
            {
                return RedirectToAction("SendConfirmEmailToParent");
            }
            if (Sitter.Cancel == true)
            {
                return RedirectToAction("SendCancelEmailToParent");
            }
            return RedirectToAction("Index")
        }*/
        public async Task<ActionResult> SendConfirmEmailToParent(int id)
        {
            Sitter sitter = context.Sitters.Include(p => p.User).FirstOrDefault(p => p.Id == id);

            return View(sitter);

        }

        [HttpPost]
        public async Task<ActionResult> SendConfirmEmailToParent(Sitter sitter)
        {

            var client = new SendGridClient(APIKeys.sendGridAPI);
            var from = new EmailAddress("sittersitters10@gmail.com", "Sitters");
            var subject = "Sitter Request Confirmed";
            var to = new EmailAddress("parentsparent20@gmail.com");
            var plainTextContent = "Confirmation";
            var htmlContent = "<strong>We are excited to inform you that the Sitter has confirmed to sitter for you.  Any questions or concerns please visit our website.</strong><br />";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            var startdate = DateTime.Today;

            return RedirectToAction("Index", "Home");
        }
        public async Task<ActionResult> SendCancelEmailToParent(int id)
        {
            Sitter sitter = context.Sitters.Include(p => p.User).FirstOrDefault(p => p.Id == id);

            return View(sitter);

        }

        [HttpPost]
        public async Task<ActionResult> SendCancelEmailToParent(Sitter sitter)
        {

            var client = new SendGridClient(APIKeys.sendGridAPI);
            var from = new EmailAddress("sittersitters10@gmail.com", "Sitters");
            var subject = "Sitter Request Confirmed";
            var to = new EmailAddress("parentsparent20@gmail.com");
            var plainTextContent = "Not Available";
            var htmlContent = "<strong>The Sitter you selected is not available.  Please visit our website to view a list of our sitters by clicking the link below.  Thank you.</strong><br /> https://localhost:44371/Sitter/index";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            var startdate = DateTime.Today;

            return RedirectToAction("Index", "Home");
        }
        
    }
}
