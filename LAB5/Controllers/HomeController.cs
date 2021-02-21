using LAB5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LAB5.Controllers
{
    public class HomeController : Controller
    {
        

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View(UseDB.GetStaff());
        }

        [HttpGet]
        public ActionResult DelStaff(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            UseDB.DelStaff(id.GetValueOrDefault());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditStaff(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Staff staff = UseDB.FindStaff(id.GetValueOrDefault());
            if (staff != null)
            {
                return View(staff);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditStaff(Staff staff)
        {
            UseDB.EditStaff(staff);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            UseDB.AddStaff(staff);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult SearchStaff(string address)
        {
            if (address == null)
            {
                return RedirectToAction("Index");
            }
            if (address != null)
            {
                return View(UseDB.SearchStaff(address));
            }
            return HttpNotFound();
        }

        private ActionResult HttpNotFound()
        {
            return View();
        }
    }
}
