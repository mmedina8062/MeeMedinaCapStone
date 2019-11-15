using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mee.Models;



namespace Mee.Controllers
{
    public class ImageGalleryController : Controller
    {
        ApplicationDbContext context;
        public ImageGalleryController()
        {
            context = new ApplicationDbContext();
        }

        // GET: ImageGallery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            List<ImageGallery> all = new List<ImageGallery>();
            all = context.ImageGalleries.ToList();
            return View(all);
        }
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(ImageGallery IG)
        {
            if (IG.File.ContentLength > (2*1024*1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 25 MB");
                return View();
            }
            if (!(IG.File.ContentType == "image/jpeg" || IG.File.ContentType == "image/gif"))
            {
                ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                return View();
            }
            IG.FileName = IG.File.FileName;
            IG.ImageSize = IG.File.ContentLength;

            byte[] data = new byte[IG.File.ContentLength];
            IG.File.InputStream.Read(data, 0, IG.File.ContentLength);

            IG.imageData = data;
            context.ImageGalleries.Add(IG);
            context.SaveChanges();
            return RedirectToAction("Gallery");
        }
    }
}