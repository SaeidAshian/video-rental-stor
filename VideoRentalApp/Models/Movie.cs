using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRentalApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public Genre genre { get; set; }

        [Required]
        [Display(Name="Film Genre")]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Release date")]
        public DateTime ReleseDate { get; set; }
        [Display(Name = "Number in stuck")]
        public byte NumberInStuck { get; set; }
        
    }
}