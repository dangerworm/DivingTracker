using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DivingTracker.ServiceLayer;
using DivingTracker.ServiceLayer.Enums;
using DivingTracker.Web.Attributes;
using DivingTracker.Web.Models;

namespace DivingTracker.Web.Controllers
{
    public class MembersController : DivingTrackerBaseController
    {
        public MembersController(DivingTrackerEntities databaseContext)
            : base(databaseContext)
        {
        }

        [AuthoriseRoles(SystemRoles.Admin, SystemRoles.Instructor)]
        public ActionResult Index()
        {
            var userQualifications = DatabaseContext.UserQualifications;
            var users = DatabaseContext.Users;

            var model = new BranchMembersModel(userQualifications, users);

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = DatabaseContext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var qualificationsCompleted = DatabaseContext.UserQualifications.Where(x => x.UserId == CurrentUserId).Select(x => x.Qualification);

            var trainingModuleIds = DatabaseContext.UserCriterions.Select(x => x.Criterion.ModuleSection.Module.ModuleId);
            var qualifiactionsInProgress = DatabaseContext.Qualifications.Where(x => x.UserQualifications.All(y => y.UserId != CurrentUserId) && x.Modules.Any(y => trainingModuleIds.Contains(y.ModuleId)));

            var model = new UserQualificationsModel(CurrentUser, qualificationsCompleted, qualifiactionsInProgress);
            return View(model);
        }

        [AuthoriseRoles(SystemRoles.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = DatabaseContext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var model = new UserModel(user);

            ViewBag.SystemLoginId = new SelectList(DatabaseContext.SystemLogins, "SystemLoginId", "EmailAddress", user.SystemLoginId);
            ViewBag.SystemRoleId = new SelectList(DatabaseContext.SystemRoles.Where(x => x.SystemRoleId > 0), "SystemRoleId", "Description", user.SystemRoleId);
            ViewBag.UserId = new SelectList(DatabaseContext.UserCriterions, "UserId", "UserId", user.UserId);

            return View(model);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AuthoriseRoles(SystemRoles.Admin)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,SystemRoleId,FirstName,Surname,DateOfBirth")] User user)
        {
            if (ModelState.IsValid)
            {
                DatabaseContext.Entry(user).State = EntityState.Modified;
                DatabaseContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SystemLoginId = new SelectList(DatabaseContext.SystemLogins, "SystemLoginId", "EmailAddress", user.SystemLoginId);
            ViewBag.SystemRoleId = new SelectList(DatabaseContext.SystemRoles.Where(x => x.SystemRoleId > 0), "SystemRoleId", "Description", user.SystemRoleId);
            ViewBag.UserId = new SelectList(DatabaseContext.UserCriterions, "UserId", "UserId", user.UserId);

            var model = new UserModel(user);
            return View(model);
        }

        [AuthoriseRoles(SystemRoles.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = DatabaseContext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [AuthoriseRoles(SystemRoles.Admin)]
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
