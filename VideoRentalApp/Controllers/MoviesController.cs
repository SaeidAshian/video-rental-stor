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
        // ----------- with database ------------
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
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

        [HttpPost]
        public ActionResult Save(Movie  movie)
        {
            if (movie.Id == 0)
            {
                
                _context.movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleseDate = movie.ReleseDate;
                movieInDb.GenreId= movie.GenreId;
                movieInDb.NumberInStuck = movie.NumberInStuck;
            }
            //movie.genre = _context.genre.SingleOrDefault(c => c.Id == movie.GenreId);
            _context.SaveChanges();
            return RedirectToAction("Random", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel

            {
                movie = movie,
                Genre = _context.genre.ToList()
            };
            return View("EditOrAddMovie", viewModel);
        }



        // GET: Movies
        public ActionResult Random()
        {
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

            var movies = _context.movies.Include(m => m.genre).ToList();
            return View(movies);
            
        }
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
        public ActionResult EditOrAddMovie()
        {
            var Genre = _context.genre;
            var ViewModel = new MovieFormViewModel { Genre = Genre };
            return View("EditOrAddMovie", ViewModel);
        }
    }
}