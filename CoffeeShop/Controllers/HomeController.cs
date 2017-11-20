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

        //public ActionResult CreateTest()
        //{

        //    return View();
        //}

        public ActionResult Summary(UserInfo info)
        {

            //// first time we call this action
            //if (Session["Counter"] == null)
            //{
            //    Session.Add("Counter", 0);
            //}
            //// fetch the value of counter 
            //Counter = (int)Session["Counter"];

            //Counter += 1;

            //ViewBag.Message = $"Counter value = {Counter}";

            //Session["Counter"] = Counter;// save the Counter back

            //HttpCookie c; //Declare a cookie

            ////If no cookie exists
            //if (Request.Cookies["Counter"] == null)
            //{
            //    c = new HttpCookie("Counter");
            //    c.Value = "0";
            //    c.Expires = DateTime.Now.AddMinutes(4);

            //}

            //else // fetch the cookie from the request
            //{
            //    c = Request.Cookies["Counter"];
            //    c.Expires = DateTime.Now.AddMinutes(4);
            //}

            ViewBag.Email = info.Email;
            ViewBag.Password = info.Password;
            return View();
        }


    }
}