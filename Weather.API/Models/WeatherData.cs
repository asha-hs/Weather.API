using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Weather.API.Models
{
    public class WeatherData
    {
        public int Id { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Date is required.")]
        [RegularExpression(@"^\d{4}$|^\d{4}-((0?\d)|(1[012]))-(((0?|[12])\d)|3[01])$", ErrorMessage = "Invalid date format.")]
        public string Date { get; set; }

        public Location Location { get; set; }

        [RegularExpression(@"[0-9]{0,}\.[0-9]{1}", ErrorMessage = "Temprature is an array of floats upto one decimal place")]
        public decimal[] Temprature { get; set; }
    }
}