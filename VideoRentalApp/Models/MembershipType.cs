using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VideoRentalApp.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public string NameOfType { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public Byte DiscountRate { get; set; }

        public static readonly byte unknown = 0;
        public static readonly byte pasAsYougo = 1;
        
    }
}