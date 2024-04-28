using Inventory_Management_system.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_system.Controllers
{
    public class LoginController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            var role = db.tblRoles.ToList();
            ViewBag.Role = new SelectList(role, "RoleId", "RoleName");
            return View();
        }

        [HttpPost]
        public ActionResult Login(tblLogin lg)
        {
            var role = db.tblRoles.ToList();
            ViewBag.Role = new SelectList(role, "RoleId", "RoleName");

            if (lg.RoleId == 1)
            {
                bool checkAdmin = db.tblLogins.Any(x => x.LoginName == lg.LoginName && x.Password == lg.Password);
                if (checkAdmin)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.NotFound = "User Not Found";
                    return View();
                }
            }
            else if (lg.RoleId == 2)
            {
                bool checkManager = db.tblLogins.Any(x => x.LoginName == lg.LoginName && x.Password == lg.Password);
                if (checkManager)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.NotFound = "User Not Found";
                    return View();
                }
            }
            else if (lg.RoleId == 3)
            {
                bool checkStaff = db.tblLogins.Any(x => x.LoginName == lg.LoginName && x.Password == lg.Password);
                if (checkStaff)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.NotFound = "User Not Found";
                    return View();
                }
            }
            else
            {
                ViewBag.NotFound = "User Not Found";
                return View();
            }
        }

    }
}