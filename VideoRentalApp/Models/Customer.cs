﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoRentalApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int Birthday { get; set; }
        public bool IsSubscribToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}