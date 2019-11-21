using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer;
using DivingTracker.ServiceLayer.Enums;
using DivingTracker.Web.Attributes;
using DivingTracker.Web.Models;

namespace DivingTracker.Web.Controllers
{
    [AuthoriseRoles(SystemRoles.Admin, SystemRoles.LeadInstructor, SystemRoles.Instructor)]
    public class ClubMembersController : DivingTrackerBaseController
    {
        public ClubMembersController(DivingTrackerEntities databaseContext)
            :base (databaseContext)
        {
        }
        
        // GET: User
        public ActionResult Index()
        {
            var users = DatabaseContext.Users.Include(u => u.SystemLogin).Include(u => u.SystemRole).Include(u => u.UserCriteria);
            return View(users.MapAll<User, UserModel>());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = DatabaseContext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = DatabaseContext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.SystemLoginId = new SelectList(DatabaseContext.SystemLogins, "SystemLoginId", "EmailAddress", user.SystemLoginId);
            ViewBag.SystemRoleId = new SelectList(DatabaseContext.SystemRoles, "SystemRoleId", "Description", user.SystemRoleId);
            ViewBag.UserId = new SelectList(DatabaseContext.UserCriterias, "UserId", "UserId", user.UserId);
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,CreatedDate,SystemLoginId,SystemRoleId,FirstName,Surname,DateOfBirth")] User user)
        {
            if (ModelState.IsValid)
            {
                DatabaseContext.Entry(user).State = EntityState.Modified;
                DatabaseContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SystemLoginId = new SelectList(DatabaseContext.SystemLogins, "SystemLoginId", "EmailAddress", user.SystemLoginId);
            ViewBag.SystemRoleId = new SelectList(DatabaseContext.SystemRoles, "SystemRoleId", "Description", user.SystemRoleId);
            ViewBag.UserId = new SelectList(DatabaseContext.UserCriterias, "UserId", "UserId", user.UserId);
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = DatabaseContext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = DatabaseContext.Users.Find(id);
            DatabaseContext.Users.Remove(user);
            DatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
