﻿using System;
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
            this.dataService = ds;
        }

   
        public ActionResult Index()
        {
            ViewBag.Users = this.dataService.GetUsers();
            return View();
        }

        //Нажатие ссылки "Изменить пользователя"
        [HttpGet]
        public ActionResult ChangeUserForm(int id)
        {
            ViewBag.user = this.dataService.GetUser(id);
            return View();
        }

        //ОТправка непосредственно формы с данными
        [HttpPost]
        public ActionResult ChangeUserForm(User user)
        {
            this.dataService.UpdateUser(user);
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
        public ActionResult AddRoute()
        {
            return View("AddRoute", new Route());
        }

        [HttpPost]
        public ActionResult AddRoute(Route route, User user)
        {
            dataService.AddRoute(route, user);
              // user.(route);
            return RedirectToAction("Index");
        }
    }
}