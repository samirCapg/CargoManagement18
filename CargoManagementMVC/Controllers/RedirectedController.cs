using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoManagementMVC.Controllers
{
    public class RedirectedController : Controller
    {
        // GET: Redirected
        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult LoggedIn()
        {
            return View();
        }
    }
}