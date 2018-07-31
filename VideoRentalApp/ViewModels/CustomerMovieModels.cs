using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalApp.Models;

namespace VideoRentalApp.ViewModels
{
    public class CustomerMovieModels
    {
        public List<Customer> Customers { get; set; }
        public Movie Movie { get; set; }
    }
}