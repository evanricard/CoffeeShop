using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        public ActionResult Summary(UserInfo info)
        {
            ViewBag.Email = info.GetEmail;
            ViewBag.Password = info.GetPassword;
            return View();
        }

    }
}