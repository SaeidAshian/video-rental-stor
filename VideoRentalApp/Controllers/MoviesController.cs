using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalApp.Models;
using VideoRentalApp.ViewModels;
using System.Data.Entity;

namespace VideoRentalApp.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.movies.Include(m => m.genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.movies.Include(m => m.genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();   
            }
            return View(movie);
        }







        // GET: Movies
        //public ActionResult Random()
        //{
            // ---------- this part without database
            //var movie = new Movie() { Name = "sherk" };
            //var movie1 = new List<Movie>();
            //List<Movie> movie2 = new List<Movie>() {
            //    new Movie{Name="a123"},new Movie{Name="c123"},new Movie{Name="123"}
            //    ,new Movie{Name="f123"},
            //    new Movie{Name="fr123"},
            //    new Movie{Name="jh123"}
              
            //};            
            //  return View(movie2);
           
           // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });    
        
            // ----------- with database ------------
            

            
        //}
        //[Route("movies/byrealeasdate/{year}/{month:regex(\\d{2}):range(1 , 12)}")]
        //public ActionResult ByRealeaseYear(int year , int month)
        //{
        //    return Content(year+"/"+ month);
        //}

        //public ActionResult ListOfCustomerRentedOnefilm()
        //{
        //    var movie = new Movie() { Name = "sherk" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer{Name="saeid"},
        //        new Customer{Name="sara"},
        //        new Customer{Name="sara2"},
        //        new Customer{Name="sahar"},
        //        new Customer{Name="samira"},
        //    };
        //    var viewModel = new CustomerMovieModels
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };


        //    return View(viewModel);
        //}

    }
}