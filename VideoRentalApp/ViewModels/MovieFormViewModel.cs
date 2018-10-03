using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalApp.Models;
using System.ComponentModel.DataAnnotations;

namespace VideoRentalApp.ViewModels
{
    public class MovieFormViewModel
    {
        public  IEnumerable<Genre> Genre { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        [Required]
        [Display(Name = "Film Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release date")]
        public DateTime? ReleseDate { get; set; }

        [Required]
        [Range(1, 25)]
        [Display(Name = "Number in stuck")]
        public byte NumberInStuck { get; set; }
        public string Title
        { 
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            } 
        }
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
                Id = movie.Id;
                Name=movie.Name;
                GenreId=movie.GenreId;
                NumberInStuck=movie.NumberInStuck;
                ReleseDate = movie.ReleseDate;
        }
        
    }
}