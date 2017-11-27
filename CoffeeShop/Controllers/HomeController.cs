using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data; // Entity
using System.Data.SqlClient; //Entity
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
            return View("UserRegistration");
        }

        public ActionResult Summary(UserInfo info)
        {

            if (ModelState.IsValid)
            {
                ViewBag.Name = info.Name;
                ViewBag.Email = info.Email;
                ViewBag.Password = info.Password;


                return View("Summary");

            }

            else
            {
                //return RedirectToAction("Summary2");
                return View("SummaryError");
            }
        }

        //Display both the list of current users and items in stock
        public ActionResult Summary2(UserInfo info)
        {
            return View("Summary2");
        }

        public ActionResult ItemList(UserInfo info)
        {
            CoffeeShopDBEntities CSDB = new CoffeeShopDBEntities();

            List<Item> items = CSDB.Items.ToList();

            ViewBag.ItemList = items;

            return RedirectToAction("Summary2");

        }

        public ActionResult UserList(UserInfo info)
        {
            CoffeeShopDBEntities CSDB = new CoffeeShopDBEntities();

            List<User> users = CSDB.Users.ToList();

            ViewBag.UserList = users;

            return RedirectToAction("Summary2");

        }

        public ActionResult

        //public ActionResult AddInfo(UserInfo info)
        //{


        //    return View();
        //}

        //public ActionResult DeleteInfo(UserInfo info)
        //{
        //    // ToDO: Add exception handling for db exceptions
        //    //1. Find the record 
        //    NorthwindEntities NW = new NorthwindEntities();

        //    // Find looks for a record based on the primary key
        //    UserInfo infoDeletion = NW.Customers.Find(info);

        //    //2. Delete the record using the ORM
        //    if (infoDeletion != null)
        //    {
        //        NW.Database.CreateIfNotExists();
        //        NW.SaveChanges();
        //    }

        //    //else
        //    //{
        //    //    NW.Customers.Remove(infoDeletion);
        //    //}

        //    //3. Reload the list 

        //    return RedirectToAction("ListCustomers");
        //}

        //public ActionResult AddUserInfoToDB(UserInfo info)
        //{
        //    NorthwindEntities NW = new NorthwindEntities();

        //    if (ModelState.IsValid)
        //    {
        //        UserInfo infoUpdate = NW.Customers.Find(info.Name);

        //        infoUpdate.Name = info.Name;
        //        infoUpdate.Email = info.Email;
        //        infoUpdate.Password = info.Password;

        //        NW.Entry(info).State = System.Data.Entity.EntityState.Modified;
        //        NW.SaveChanges();

        //        return RedirectToAction("DBSummary");

        //    }

        //    return View("Summary");
        //}

    }
}