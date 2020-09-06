using DivingTracker.ServiceLayer;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DivingTracker.Web.Models;

namespace DivingTracker.Web.Controllers
{
    public class QualificationsController : DivingTrackerBaseController
    {
        public QualificationsController(DivingTrackerEntities databaseContext)
            : base(databaseContext)
        {
        }

        // GET: Qualifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var qualification = DatabaseContext.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }

            return View(new QualificationModel(qualification));
        }

        // GET: Qualifications/Create
        public ActionResult Create()
        {
            ViewBag.AgencyId = new SelectList(DatabaseContext.Agencies, "AgencyId", "Name");
            ViewBag.QualificationTypeId = new SelectList(DatabaseContext.QualificationTypes, "QualificationTypeId", "Description");
            return View();
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QualificationId,AgencyId,QualificationTypeId,Name,Description")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                DatabaseContext.Qualifications.Add(qualification);
                DatabaseContext.SaveChanges();
                return RedirectToAction("Index", "Training");
            }

            ViewBag.AgencyId = new SelectList(DatabaseContext.Agencies, "AgencyId", "Name", qualification.AgencyId);
            ViewBag.QualificationTypeId = new SelectList(DatabaseContext.QualificationTypes, "QualificationTypeId", "Description", qualification.QualificationTypeId);
            return View(qualification);
        }

        // GET: Qualifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = DatabaseContext.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgencyId = new SelectList(DatabaseContext.Agencies, "AgencyId", "Name", qualification.AgencyId);
            ViewBag.QualificationTypeId = new SelectList(DatabaseContext.QualificationTypes, "QualificationTypeId", "Description", qualification.QualificationTypeId);
            return View(qualification);
        }

        // POST: Qualifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QualificationId,AgencyId,QualificationTypeId,Name,Description")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                DatabaseContext.Entry(qualification).State = EntityState.Modified;
                DatabaseContext.SaveChanges();
                return RedirectToAction("Index", "Training");
            }
            ViewBag.AgencyId = new SelectList(DatabaseContext.Agencies, "AgencyId", "Name", qualification.AgencyId);
            ViewBag.QualificationTypeId = new SelectList(DatabaseContext.QualificationTypes, "QualificationTypeId", "Description", qualification.QualificationTypeId);
            return View(qualification);
        }

        // GET: Qualifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = DatabaseContext.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Qualification qualification = DatabaseContext.Qualifications.Find(id);
            DatabaseContext.Qualifications.Remove(qualification);
            DatabaseContext.SaveChanges();
            return RedirectToAction("Index", "Training");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DatabaseContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
