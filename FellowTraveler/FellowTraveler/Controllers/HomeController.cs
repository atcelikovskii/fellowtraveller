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
    public class HomeController : Controller
    {
        IDataService dataService;
        //private PoputchikContext db = new PoputchikContext();
        //срабатывает иньекция зависимости
        // Сюда передается объект указанный в NinjectDependencyResolver.AddBindings

        //protected string CurrentUser
        //{
        //    get
        //    {
        //        return (string)HttpContext.Session["User"];
        //    }

        //    set
        //    {
        //        HttpContext.Session["User"] = value;
        //    }
        //}

        //[HttpGet]
        //[ChildActionOnly]
        //public ActionResult ChoiceUser()
        //{
        //    return View(new CurrentUserViewModel() { CurrentUser = CurrentUser, Users = dataService.GetUsers() });
        //}

        //[HttpPost]
        //[ChildActionOnly]
        //public ActionResult ChoiceUser(string user)
        //{
        //    CurrentUser = user;
        //    return View(new CurrentUserViewModel() { CurrentUser = user, Users = dataService.GetUsers() });
        //}



        public HomeController(IDataService ds)
        {
            dataService = ds;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {

            return View();
        }


        public ActionResult Routes()
        {
            var Users = dataService.GetUsers();
            return View("Routes", Users);
        }


        //Нажатие ссылки "Изменить пользователя"
        [HttpGet]
        public ActionResult ChangeUserForm(int id)
        {
            ViewBag.user = dataService.GetUser(id);
            return View();
        }


        //ОТправка непосредственно формы с данными
        [HttpPost]
        public ActionResult ChangeUserForm(User user)
        {
            dataService.UpdateUser(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View("AddUser", new User());
        }

        [HttpPost]
        public ActionResult AddUser(User us)
        {
            dataService.AddUser(us);
            return RedirectToAction("Routes");
        }

        [HttpGet]
        public ActionResult AddRoute(int id)
        {
            User user = dataService.GetUser(id);
            return View("AddRoute", new Route() { Owner = user });
        }

        [HttpPost]
        public ActionResult AddRoute(Route route, int ownerId)
        {
            User user = dataService.GetUser(ownerId);
            route.Id = null;
            dataService.AddRoute(route, user);
            return RedirectToAction("Routes");
        }

        //public ActionResult RouteForm(User idUser, Route idRoute)
        //{
        //    return View(dataService.GetRoute(idUser, idRoute));
        //}

        public ActionResult RouteForm(int userId, int routeId)
        {
            return View(dataService.GetRoute(userId, routeId));
        }

        [HttpPost]
        public ActionResult UserSearch(string name)
        {
            var allUsers = dataService.GetUsers().Where(a => a.Name.Contains(name)).ToList();
            if (allUsers.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(allUsers);
        }

        //[HttpPost]
        //public ActionResult EditRoute(string name)
        //{
        //    var route = dataService.GetRouteListForUser().Where(a => a.Name.Contains(name)).ToList();

        //    return PartialView(route);
        //}
    }
}