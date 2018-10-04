using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VideoRentalApp.Models;

namespace VideoRentalApp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Family { get; set; }
        [Min18YearsIfAMember]
        
        public DateTime? Birthday { get; set; }

        public bool IsSubscribToNewsletter { get; set; }

       

       
        public byte MembershipTypeId { get; set; }
    }
}