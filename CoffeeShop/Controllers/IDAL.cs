using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Models;
using System.Data; // Entity
using System.Data.SqlClient; //Entity
using System.Data.Entity;
using System.Web.Mvc;

namespace CoffeeShop.Controllers
{
    interface IDAL
    {

        ActionResult ItemList(Item item);
        ActionResult UserList(User user);

    }
}
