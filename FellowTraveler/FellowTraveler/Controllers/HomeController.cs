using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FellowTraveler.Infrastructure;
using DataService;
namespace FellowTraveler.Controllers
{
    public class HomeController : Controller
    {
        IDataService dataService;

        //срабатывает иньекция зависимости
        //Сюда передается объект указанный в NinjectDependencyResolver.AddBindings
        public HomeController(IDataService ds)
        {
            dataService = ds;
        }

   
        public ActionResult Index()
        {
            ViewBag.Users = dataService.GetUsers();
            return View();
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
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddRoute(int id)
        {
            User user = dataService.GetUser(id);
            return View("AddRoute", new Route() { Owner = user});
        }

        [HttpPost]
        public ActionResult AddRoute(Route route, int ownerId)
        {
            User user = dataService.GetUser(ownerId);
            dataService.AddRoute(route, user);
            return RedirectToAction("Index");
        }

        public ActionResult RouteForm(User idUser, Route idRoute)
        {
            return View(dataService.GetRoute(idUser, idRoute));
        }
    }
}