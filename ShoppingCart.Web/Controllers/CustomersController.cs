using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.BusinessFactories;

namespace ShoppingCart.Web.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index(int? Page, string type)
        {
            const int pageSize = 3;

            var collection = CustomersFactory.GetAll();
            
            int rowCount = collection.Count();
             
            int lastPage = rowCount/pageSize;

            ViewBag.PageCount = lastPage;

            int noOfTake = Page != null ? Page.Value  : 0;

            if (type == "Next")
            {
                if (noOfTake < lastPage)
                {
                    noOfTake = noOfTake + 1;
                }
            }
            else if (type == "Previous")
            {
                noOfTake = noOfTake - 1 <= 0 ? 0 : noOfTake - 1; 
            }
            else if (type == "First")
            {
                noOfTake = 0;
            }
            else if (type == "Last")
            {
                noOfTake = lastPage;
            }
            else
            {
                noOfTake = 0;
            }

            ViewBag.CurrentPage = noOfTake;

            collection = collection.OrderBy(c => c.CustomerId).Skip(noOfTake * pageSize).Take(pageSize).ToList();

            return View(collection);
        }

        public ActionResult AjaxResult(int? Page, string type)
        {
            const int pageSize = 3;

            var collection = CustomersFactory.GetAll();

            int rowCount = collection.Count();

            int lastPage = rowCount / pageSize;

            ViewBag.PageCount = lastPage;

            int noOfTake = Page != null ? Page.Value : 0;

            if (type == "Next")
            {
                if (noOfTake < lastPage)
                {
                    noOfTake = noOfTake + 1;
                }
            }
            else if (type == "Previous")
            {
                noOfTake = noOfTake - 1 <= 0 ? 0 : noOfTake - 1;
            }
            else if (type == "First")
            {
                noOfTake = 0;
            }
            else if (type == "Last")
            {
                noOfTake = lastPage;
            }
            else
            {
                noOfTake = 0;
            }

            ViewBag.CurrentPage = noOfTake;

            collection = collection.OrderBy(c => c.CustomerId).Skip(noOfTake * pageSize).Take(pageSize).ToList();

            return Json(new {data = collection});
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            if (Convert.ToString(fc["CustomerName"]) == "") 
            {
                ModelState.AddModelError("CustomerName", "Enter customer name."); 
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}