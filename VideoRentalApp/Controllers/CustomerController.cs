using System;
using System.Data.Entity;
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
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context=new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            // USE DATABASE FOR INITIALIZE NOW
            //var customers = new List<Customer>
            //{
            //    new Customer{Name="saeid",Id=1},
            //    new Customer{Name="sara",Id=2},
            //    new Customer{Name="sara2",Id=3},
            //    new Customer{Name="sahar",Id=4},
            //    new Customer{Name="samira",Id=5},
            //};
            try
            {
                var Customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(Customers);

            }
            catch (Exception e)
            {
                string mes = e.Message;
                throw;
            }
         
        }
       // [Route("customer/Details/{Id}")]
        public ActionResult Details(int id)
        {
            
            // var customers = new List<Customer>
            //{
            //    new Customer{Name="saeid",Id=1},
            //    new Customer{Name="sara",Id=2},
            //    new Customer{Name="sara2",Id=3},
            //    new Customer{Name="sahar",Id=4},
            //    new Customer{Name="samira",Id=5},
            //};

             var customer=_context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
             if (customer == null)
              return HttpNotFound();
             
             //else
             //{
             //    var mycys = new List<Customer> { 
             //new Customer{Name=CUST.Name,Id=id}
             //};

             return View(customer);



             
             
            
        }
    }
}