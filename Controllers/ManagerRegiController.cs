using Inventory_Management_system.Models.ValidationClasses;
using System;
using Inventory_Management_system.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
using System.Data.Common;

namespace Inventory_Management_system.Controllers
{
    public class ManagerRegiController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();


        // GET: ManagerRegi
        public ActionResult DisplayManager()
        {
            var display = db.tblManagers.Where(x => x.ManDeleted == false).ToList();
            return View();
        }



        [HttpGet]
        public ActionResult ManRegiCreate()
        {
            var Qualification = db.tblQualifications.ToList();
            TempData["Qualification"] = new SelectList(Qualification, "QualificationId", "Degree");
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public ActionResult ManRegiCreate(ManagerRegiValid mgv)
        {
            if (ModelState.IsValid)
            {
                int roleId = int.Parse(TempData["roleId"].ToString());

                int n = db.spManRegiCreate(mgv.ManName, mgv.ManMobile, mgv.ManEmail, mgv.ManDOB, mgv.ManGender, mgv.ManSalary, mgv.QualificationId, roleId, mgv.ManJoiningDate, mgv.ManPassword);
            }
            return RedirectToAction("Login", "Login");
        }


    }
}