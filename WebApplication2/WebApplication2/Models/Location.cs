using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Location
    {
        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id_location { get; set; }

        [Display(Name = "Date Debut")]
        [DataType(DataType.Date)]
        public DateTime date_deb { get; set; }

        [Display(Name = "Date Fin")]
        [DataType(DataType.Date)]
        public DateTime date_fin { get; set; }

        public int Voiture { get; set; }

        public int User { get; set; }

        public int exist { get; set; }
    }
}