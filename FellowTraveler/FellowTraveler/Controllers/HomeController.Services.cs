using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using FellowTraveler.Infrastructure;
using DataService;
using DataService.DomainModel;
//using FellowTraveler.Models;

namespace FellowTraveler.Controllers
{
    partial class HomeController : Controller
    {

        [HttpPost]
        public JsonResult AddRouteJSON(Route route, int ownerId)
        {
            //  Route route = new Route();
            User user = dataService.GetUser(ownerId);
            route.Id = null;
            dataService.AddRoute(route, user);
            return Json(route.Id);
        }


        [HttpPost]
        public JsonResult SearchRoutes(Point point1, Point point2, int sMax)
        {
            return Json(dataService.SearchClosedRoutes(point1, point2, sMax));
        }

    }
}