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

        [AuthoriseRoles(SystemRoles.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = DatabaseContext.Users.Find(id);
            if (user == null)
                return HttpNotFound();
            return View(user);
        }

        [AuthoriseRoles(SystemRoles.Admin)]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = DatabaseContext.Users.Find(id);
            DatabaseContext.Users.Remove(user);
            DatabaseContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = DatabaseContext.Users.Find(id);
            if (user == null)
                return HttpNotFound();

            var qualificationsCompleted = DatabaseContext.UserQualifications.Where(x => x.UserId == id)
                .Select(x => x.Qualification);

            var trainingModuleIds = DatabaseContext.UserCriterions.Where(x => x.UserId == id)
                .Select(x => x.Criterion.ModuleSection.Module.ModuleId);
            var qualificationsInProgress =
                DatabaseContext.Qualifications.Where(x => x.UserQualifications.All(y => y.UserId != id) &&
                                                          x.Modules.Any(y => trainingModuleIds.Contains(y.ModuleId)));

            var model = new UserQualificationsModel(user, qualificationsCompleted, qualificationsInProgress);
            return View(model);
        }

        [AuthoriseRoles(SystemRoles.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = DatabaseContext.Users.Find(id);
            if (user == null)
                return HttpNotFound();

            var model = new UserModel(user);

            ViewBag.SystemRoleId = new SelectList(DatabaseContext.SystemRoles, "SystemRoleId", "Description",
                user.SystemRoleId);
            ViewBag.UserId = new SelectList(DatabaseContext.UserCriterions, "UserId", "UserId", user.UserId);

            return View(model);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AuthoriseRoles(SystemRoles.Admin)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,SystemLoginId,SystemRoleId,FirstName,Surname,DateOfBirth")] User user)
        {
            if (ModelState.IsValid)
            {
                DatabaseContext.Entry(user).State = EntityState.Modified;
                DatabaseContext.SaveChanges();
                return RedirectToAction("Index");
            }

            var dbUser = DatabaseContext.Users.Find(user.UserId);
            if (dbUser == null)
                return HttpNotFound();

            user.SystemLogin = dbUser.SystemLogin;

            ViewBag.SystemRoleId = new SelectList(DatabaseContext.SystemRoles.Where(x => x.SystemRoleId > 0),
                "SystemRoleId", "Description", user.SystemRoleId);
            ViewBag.UserId = new SelectList(DatabaseContext.UserCriterions, "UserId", "UserId", user.UserId);

            var model = new UserModel(user);
            return View(model);
        }

        [AuthoriseRoles(SystemRoles.Admin, SystemRoles.Instructor)]
        public ActionResult Index()
        {
            var userQualifications = DatabaseContext.UserQualifications;
            var users = DatabaseContext.Users;

            var model = new BranchMembersModel(userQualifications, users);

            return View(model);
        }
    }
}