using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data; // Entity
using System.Data.SqlClient; //Entity
using System.Data.Entity;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller, IDAL
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserRegistration()
        {
            return View("UserRegistration");
        }

        //User Info Summary
        public ActionResult UserInfoSummary(UserInfo info)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Name = info.Name;
                ViewBag.Email = info.Email;
                ViewBag.Password = info.Password;

                return View("UserInfoSummary");

            }

            else
            {
                return View("SummaryError");
            }
        }

        public ActionResult StoreIteminDB(Item item)
        {
            if (ModelState.IsValid)
            {
                CoffeeShopDBEntities CSDB = new CoffeeShopDBEntities();
                CSDB.Items.Add(item);
                CSDB.SaveChanges();
                return RedirectToAction("ThankYou");

            }

            else
            {
                return View("SummaryError");
            }

        }

        //TODO: For save button after entering new item data
        public ActionResult SaveUpdatedItem(Item itemUpdate)
        {

            CoffeeShopDBEntities CSDB = new CoffeeShopDBEntities();

            Item temp = CSDB.Items.Find(itemUpdate.Name);

            // 2. Do the update on that record, then save to the database
            temp.Name = itemUpdate.Name;
            temp.Description = itemUpdate.Description;
            temp.Quantity = itemUpdate.Quantity;
            temp.price = itemUpdate.price;

            CSDB.Entry(temp).State = EntityState.Modified;
            CSDB.SaveChanges();

            //3. Load all the customer records 
            return RedirectToAction("ItemList");
        }

        public ActionResult DeleteUser(string userName)
        {
            // ToDO: Add exception handling for db exceptions
            //1. Find the record 
            CoffeeShopDBEntities CSDB = new CoffeeShopDBEntities();

            // Find looks for a record based on the primary key
            User userDeletion = CSDB.Users.Find(userName);

            //2. Delete the record using the ORM
            if (userDeletion != null)
            {
                CSDB.Users.Remove(userDeletion);
                CSDB.SaveChanges();

            }

            //3. Reload the list 
            return RedirectToAction("UserList");
        }

        public ActionResult DeleteItem(string itemName)
        {
            CoffeeShopDBEntities CSDB = new CoffeeShopDBEntities();

            Item itemDeletion = CSDB.Items.Find(itemName);

            if (itemDeletion != null)
            {
                CSDB.Items.Remove(itemDeletion);
                CSDB.SaveChanges();

            }

            return RedirectToAction("ItemList");
        }


        public ActionResult Admin()
        {
            return View("Admin");
        }

        public ActionResult ThankYou()
        {
            return View("ThankYou");

        }

        //Implementation of the interface method //EDIT
        public ActionResult ItemList(Item item)
        {
            CoffeeShopDBEntities CSDB = new CoffeeShopDBEntities();

            List<Item> items = CSDB.Items.ToList();
            items.Add(item);

            ViewBag.ItemList = items;

            return View("ItemList");
        }



        //Implementation of the interface method
        public ActionResult UserList(User user)
        {
            CoffeeShopDBEntities CSDB = new CoffeeShopDBEntities();

            List<User> users = CSDB.Users.ToList();
            users.Add(user);

            ViewBag.UserList = users;

            return RedirectToAction("UserInfoSummary");
        }


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