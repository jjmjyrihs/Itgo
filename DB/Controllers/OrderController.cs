using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert(Model.CustomerOrder Data,string  Order_ID)
        {
            Service.SQLCheckOut SCO = new Service.SQLCheckOut();
            Data.Customer_Email = Request.Cookies["cookie"]["Account"].ToString();
            SCO.InsertCustomer_Order(Data);
            Service.SQLGetShoppingCart SGSC = new Service.SQLGetShoppingCart();
            List<Model.ShippingCar> Data2 = new List<Model.ShippingCar>();
            Data2  = SGSC.Find(Data.Customer_Email);
            SCO.InsertOrder_Books(Data, Data2);
            Service.SQLDeleteShoppingCart SDSC = new Service.SQLDeleteShoppingCart();
            SDSC.Delete_Cart();
            return RedirectToAction("Index","DataShow",new { Order_ID=Order_ID});
        }
    }
}