using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VideoRentalApp.Models;

namespace VideoRentalApp.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.unknown  || customer.MembershipTypeId == MembershipType.pasAsYougo)
            {
                return ValidationResult.Success;
            }
            if (customer.Birthday == null)
                return new ValidationResult("Birthday is required");

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;
            return (age >= 18) ? ValidationResult.Success :
              new  ValidationResult("Customer should be at least 18 year old");
                
        }
    }
}