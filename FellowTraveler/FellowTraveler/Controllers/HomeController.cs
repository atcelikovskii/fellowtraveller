using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FellowTraveler.Infrastructure;
namespace FellowTraveler.Controllers
{
    public class HomeController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            ViewBag.Users = this.GetDataService().GetUsers();
            return View();
        }
    }
}