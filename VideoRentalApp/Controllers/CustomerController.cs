using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalApp.Models;
using VideoRentalApp.ViewModels;

namespace VideoRentalApp.Controllers
{
	public class CustomerController : Controller
	{
		
		// GET: Customer
		private ApplicationDbContext _context;
		public CustomerController()
		{
			_context = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
        public ActionResult CustomerForm()
        {
            
            var MembershipTypes = _context.MembershipType.ToList();
            var ViewModel = new CustomerFormViewModel {customer=new Customer(), MembershipTypes = MembershipTypes };
            return View("CustomerForm", ViewModel);

        }
		 [HttpPost]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormViewModel
				{
					customer=customer,MembershipTypes=_context.MembershipType.ToList()
				};
				return View("CustomerForm",viewModel);
			}
			if (customer.Id == 0)
				_context.Customers.Add(customer);
			else
			{
				var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

				customerInDb.Name = customer.Name;
				customerInDb.Family = customer.Family;
				customerInDb.Birthday = customer.Birthday;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribToNewsletter = customer.IsSubscribToNewsletter;
			}
			_context.SaveChanges();
			return RedirectToAction("Index","customer");
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
		public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
			if (customer==null)
			{
			  return  HttpNotFound()  ;
			}
			var viewModel = new CustomerFormViewModel

			{
				customer = customer,
				MembershipTypes = _context.MembershipType .ToList()
			};
			
			return View("CustomerForm",viewModel);
		}
	}
}