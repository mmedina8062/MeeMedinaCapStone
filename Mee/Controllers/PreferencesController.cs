using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Mee.Models;
using Newtonsoft.Json;

namespace Mee.Controllers
{
    public class PreferencesController : Controller
    {
        ApplicationDbContext context;
        public PreferencesController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Preferences
        public ActionResult Index()
        {
            return View(context.Preferences.ToList());
        }

        // GET: Preferences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preference preference = context.Preferences.Find(id);
            if (preference == null)
            {
                return HttpNotFound();
            }
            return View(preference);
        }

        // GET: Preferences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Preferences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PreferenceID,Preferences,selected")] Preference preference)
        {
            if (ModelState.IsValid)
            {
                context.Preferences.Add(preference);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(preference);
        }

        // GET: Preferences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preference preference = context.Preferences.Find(id);
            if (preference == null)
            {
                return HttpNotFound();
            }
            return View(preference);
        }

        // POST: Preferences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PreferenceID,Preferences,selected")] Preference preference)
        {
            if (ModelState.IsValid)
            {
                context.Entry(preference).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(preference);
        }

        // GET: Preferences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preference preference = context.Preferences.Find(id);
            if (preference == null)
            {
                return HttpNotFound();
            }
            return View(preference);
        }

        // POST: Preferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Preference preference = context.Preferences.Find(id);
            context.Preferences.Remove(preference);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        //GET preference selected
        /*public ActionResult GetSelectedPreferences(int Id, Preference preference)
        {
            *//*var selectedPreference = new Preference();
            foreach (var selectedPreferences in context.Preferences)
            {
                return View(preference.Preferences.ToList());
               //selectedPreference.Add(preference);
            }*//*
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preference preferences = context.Preferences.Find(Id);
            if (preference == null)
            {
                return HttpNotFound();
            }
            return View(preference);
            //return View(selectedPreference);
        }*/

        //POST bring back results searched through google maps
        //[HttpPost]
        /*public async Task<List<GooglePlaceMaps.Result>> GoogleMapsSearchResults(string LatLong)
        {
            var http = new HttpClient();
            var url = string.Format("https://maps.googleapis.com/maps/api/places/nearbysearch/json?location={0}&radius=500&minprice&maxprice&key=APIKey", LatLong, APIKeys.googleAPI);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<GooglePlaceMaps.Rootobject>(result);
            var resultsList = new List<GooglePlaceMaps.Result>();


            return resultsList;
        }*/
        /*public ActionResult GetNearByLocations(string Currentlat, string Currentlng)
        {
            using (var context = new POC_gmapsEntities())
            {
                var currentLocation = pare("POINT( " + Currentlng + " " + Currentlat + " )");

                //var currentLocation = DbGeography.FromText("POINT( 78.3845534 17.4343666 )");

                var places = (from u in context.SchoolInfoes
                              orderby u.GeoLocation.Distance(currentLocation)
                              select u).Take(4).Select(x => new Googlemaps.Models.SchoolInfo() { Name = x.SchoolName, lat = x.GeoLocation.Latitude, lng = x.GeoLocation.Longitude, Distance = x.GeoLocation.Distance(currentLocation) });
                var nearschools = places.ToList();

                return Json(nearschools, JsonRequestBehavior.AllowGet);
            }
        }*/

    }
}
