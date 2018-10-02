using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalApp.Models;

namespace VideoRentalApp.ViewModels
{
    public class MovieFormViewModel
    {
        public  IEnumerable<Genre> Genre { get; set; }
        public Movie movie { get; set; }
    }
}