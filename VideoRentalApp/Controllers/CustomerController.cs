using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalApp.Models;

namespace VideoRentalApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        
        public ViewResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer{Name="saeid",Id=1},
                new Customer{Name="sara",Id=2},
                new Customer{Name="sara2",Id=3},
                new Customer{Name="sahar",Id=4},
                new Customer{Name="samira",Id=5},
            };
            return View(customers);
        }
        [Route("customer/Details/{Id}")]
        public ActionResult Details(int id)
        {
            
             var customers = new List<Customer>
            {
                new Customer{Name="saeid",Id=1},
                new Customer{Name="sara",Id=2},
                new Customer{Name="sara2",Id=3},
                new Customer{Name="sahar",Id=4},
                new Customer{Name="samira",Id=5},
            };

             var CUST= customers.SingleOrDefault(c => c.Id == id);
             if (CUST == null)
             {
                 return HttpNotFound();
             }
             else
             {
                 var mycys = new List<Customer> { 
             new Customer{Name=CUST.Name,Id=id}
             };



                 return View(mycys);

             }
             
            
        }
    }
}