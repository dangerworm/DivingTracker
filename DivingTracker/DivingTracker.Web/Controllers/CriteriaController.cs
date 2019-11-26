using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Controllers
{
    public class CriteriaController : Controller
    {
        private DivingTrackerEntities db = new DivingTrackerEntities();

        // GET: Criteria
        public ActionResult Index()
        {
            var criteria = db.Criteria.Include(c => c.ModuleSection);
            return View(criteria.ToList());
        }

        // GET: Criteria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criterion criterion = db.Criteria.Find(id);
            if (criterion == null)
            {
                return HttpNotFound();
            }
            return View(criterion);
        }

        // GET: Criteria/Create
        public ActionResult Create()
        {
            ViewBag.ModuleSectionId = new SelectList(db.ModuleSections, "ModuleSectionId", "Name");
            return View();
        }

        // POST: Criteria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CriterionId,ModuleSectionId,Description,Details,IncludeInSyllabus")] Criterion criterion)
        {
            if (ModelState.IsValid)
            {
                db.Criteria.Add(criterion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModuleSectionId = new SelectList(db.ModuleSections, "ModuleSectionId", "Name", criterion.ModuleSectionId);
            return View(criterion);
        }

        // GET: Criteria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criterion criterion = db.Criteria.Find(id);
            if (criterion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModuleSectionId = new SelectList(db.ModuleSections, "ModuleSectionId", "Name", criterion.ModuleSectionId);
            return View(criterion);
        }

        // POST: Criteria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CriterionId,ModuleSectionId,Description,Details,IncludeInSyllabus")] Criterion criterion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criterion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModuleSectionId = new SelectList(db.ModuleSections, "ModuleSectionId", "Name", criterion.ModuleSectionId);
            return View(criterion);
        }

        // GET: Criteria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criterion criterion = db.Criteria.Find(id);
            if (criterion == null)
            {
                return HttpNotFound();
            }
            return View(criterion);
        }

        // POST: Criteria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Criterion criterion = db.Criteria.Find(id);
            db.Criteria.Remove(criterion);
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
    }
}
