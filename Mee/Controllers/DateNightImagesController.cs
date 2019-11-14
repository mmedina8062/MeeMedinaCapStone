using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mee.Controllers
{
    public class DateNightImagesController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
    }
}