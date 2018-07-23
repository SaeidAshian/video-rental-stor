using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalApp.Models;

namespace VideoRentalApp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            //var movie = new Movie() { Name = "sherk" };
            //var movie1 = new List<Movie>();
            List<Movie> movie2 = new List<Movie>() {
                new Movie{Name="a123"},new Movie{Name="c123"},new Movie{Name="123"}
                ,new Movie{Name="f123"},
                new Movie{Name="fr123"},
                new Movie{Name="jh123"}
              
            };

            
                return View(movie2);
            

            
        }
    }
}