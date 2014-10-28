using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using memberDatabasetest.Models;

namespace memberDatabasetest.Controllers
{
    public class SignupsController : Controller
    {
        private SignupDBContext db = new SignupDBContext();

        private MultiSelectList GetVolunteerActivity(string[] selectedValues)
        {
            List<VolunteerActivity> Activities = new List<VolunteerActivity>()
            {
                new VolunteerActivity() {ID = 1, Name = "Big Brothers Big Sisters"},
                new VolunteerActivity() {ID = 2, Name = "Camillus House"},
                new VolunteerActivity() {ID = 3, Name = "Camp Boggy Creek"},
                new VolunteerActivity() {ID = 4, Name = "Food Pantry and Clothing/Food Drives"},
                new VolunteerActivity() {ID = 5, Name = "Fun Day"},
                new VolunteerActivity() {ID = 6, Name = "Habitat for Humanity"},
                new VolunteerActivity() {ID = 7, Name = "High School Pre-Med Mentorship"},
                new VolunteerActivity() {ID = 8, Name = "National Gandhi Day of Service"},
                new VolunteerActivity() {ID = 9, Name = "Relay for Life"}
            };

            return new MultiSelectList(Activities, "ID", "Name", selectedValues);
        }



        private MultiSelectList GetAvailabilities(string[] selectedValues)
        {
            List<Availability> Availabilities = new List<Availability>()
            {
                new Availability() {ID = 1, Name = "Monday morning"},
                new Availability() {ID = 2, Name = "Monday afternoon"},
                new Availability() {ID = 3, Name = "Tuesday morning"},
                new Availability() {ID = 4, Name = "Tuesday afternoon"},
                new Availability() {ID = 5, Name = "Wednesday morning"},
                new Availability() {ID = 6, Name = "Wednesday afternoon"},
                new Availability() {ID = 7, Name = "Thursday morning"},
                new Availability() {ID = 8, Name = "Thursday afternoon"},
                new Availability() {ID = 9, Name = "Friday morning"},
                new Availability() {ID = 10, Name = "Friday afternoon"},
                new Availability() {ID = 11, Name = "Weekends (Not normally available)"}
            };

            return new MultiSelectList(Availabilities, "ID", "Name", selectedValues);
        }

        private MultiSelectList GetSpecialties(string[] selectedValues)
        {
            List<Specialty> Specialties = new List<Specialty>()
            {
                new Specialty() {ID = 1, Name = "Dermatology"},
                new Specialty() {ID = 2, Name = "Cardiology"},
                new Specialty() {ID = 3, Name = "Endocrinology"},
                new Specialty() {ID = 4, Name = "General Surgery"},
                new Specialty() {ID = 5, Name = "Internal Medicine"},
                new Specialty() {ID = 6, Name = "Nephrology"},
                new Specialty() {ID = 7, Name = "Ophthalmology"},
                new Specialty() {ID = 8, Name = "Orthopedic Surgery"},
                new Specialty() {ID = 9, Name = "Otolaryngology"},
                new Specialty() {ID = 10, Name = "Pediatric Otolaryngology"},
                new Specialty() {ID = 11, Name = "Pediatric Surgery"},
                new Specialty() {ID = 12, Name = "Pediatrics"},
                new Specialty() {ID = 13, Name = "Plastic Surgery"},
                new Specialty() {ID = 14, Name = "Rheumatology"},
                new Specialty() {ID = 15, Name = "Thoracic & Cardiac Surgery"}
            };

            return new MultiSelectList(Specialties, "ID", "Name", selectedValues);
        }

        // GET: Signups
        public ActionResult Index()
        {
            return View(db.Signups.ToList());
        }

        // GET: Signups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Signup signup = db.Signups.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        public enum eSchoolYears { Freshman, Sophomore, Junior, Senior };

        private void SetViewBagSchoolYear(eSchoolYears selectedSchoolYear)
        {
            IEnumerable<eSchoolYears> values = Enum.GetValues(typeof(eSchoolYears)).Cast<eSchoolYears>();

            IEnumerable<SelectListItem> items =
                from value in values
                select new SelectListItem
                {
                    Text = value.ToString(),
                    Value = value.ToString(),
                    Selected = value == selectedSchoolYear,
                };
            ViewBag.SchoolYear = items;
        }


        // GET: Signups/Create
        public ActionResult Create()
        {
            //OLD METHOD OF LISTBOX ENUMERATION
            //List<SelectListItem> items = new List<SelectListItem>();
            //items.Add(new SelectListItem { Text = "Freshman", Value = "0", Selected = true });
            //items.Add(new SelectListItem { Text = "Sophomore", Value = "1" });
            //items.Add(new SelectListItem { Text = "Junior", Value = "2" });
            //items.Add(new SelectListItem { Text = "Senior", Value = "3" });
           // List<Specialty> specs = GetSpecialties(null);

            SetViewBagSchoolYear(eSchoolYears.Freshman);
            ViewBag.SpecialtiesList = GetSpecialties(null);
            ViewBag.VolunteerActivitiesList = GetVolunteerActivity(null);
            ViewBag.AvailabilitiesList = GetAvailabilities(null);
            //ViewBag.Specialty = new MultiSelectList(specs, "Specialty", "Name");
            //SetViewBagSchoolYear(eSchoolYears.Freshman);
            //ViewBag.Specialty = GetSpecialties(null);
            //var signup = new Signup();
            return View();
        }

        // POST: Signups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,SchoolYear,PhoneNumber,Email,Major,Specialty,HasCar,Availability,BrowardAvailable,VolunteerActivity")] Signup signup, eSchoolYears SchoolYear, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                //string selectedSpecialties = form["Specialties"];
                //signup.Specialty = selectedSpecialties;
                signup.SchoolYear = ViewBag.SchoolYear.Value;
                string selectedSpecialties = form["Specialty"].ToString();
                signup.Specialty = selectedSpecialties;
                string selectedVolunteerActivities = form["VolunteerActivity"].ToString();
                signup.VolunteerActivity = selectedVolunteerActivities;
                string selectedAvailabilities = form["Availability"].ToString();
                signup.Availability = selectedAvailabilities;
                //SchoolYear = SchoolYear.ToString();
                //ViewBag.SchoolYear = new SelectList(items, "SchoolYear", "Text");

                db.Signups.Add(signup);
                db.SaveChanges();
                return RedirectToAction("Submitted");
            }

            return View(signup);
        }

        // GET: Signups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Signup signup = db.Signups.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        // POST: Signups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,SchoolYear,PhoneNumber,Email,Major,Specialty,HasCar,Availability,BrowardAvailable,VolunteerActivity")] Signup signup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(signup);
        }

        // GET: Signups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Signup signup = db.Signups.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        // POST: Signups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Signup signup = db.Signups.Find(id);
            db.Signups.Remove(signup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Submitted()
        {
            return View();
        }


    }


}
