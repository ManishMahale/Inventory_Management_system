using Inventory_Management_system.Models;
using System.Linq;
using System.Web.Mvc;

namespace Inventory_Management_system.Controllers
{
    public class RegistrationController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();

        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            var role = db.tblRoles.Where(x => x.RoleId != 1).ToList();
            ViewBag.Role = new SelectList(role, "RoleId", "RoleName");
            return View();
        }

        [HttpPost]
        public ActionResult Registration(tblRole r)
        {
            var role = db.tblRoles.SingleOrDefault(x => x.RoleId == r.RoleId);
            TempData["roleId"] = r.RoleId;
            if (role.RoleId == 2)
            { 
                return RedirectToAction("ManRegiCreate", "ManagerRegi");
            }
            else
            {
                return RedirectToAction("StaffRegi", "StaffRegi");
            }
        }
    }
}