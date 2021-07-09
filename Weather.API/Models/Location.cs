using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Weather.API.Models
{
    public class Location
    {
        [RegularExpression(@"^\d+.\d{0,4}$", ErrorMessage = "The latitude upto 4 decimal places of the location")]
        public decimal lat { get; set; }

        [RegularExpression(@"^\d+.\d{0,4}$", ErrorMessage = "The longitude upto 4 decimal places of the location")]
        public decimal lon { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
    }
}