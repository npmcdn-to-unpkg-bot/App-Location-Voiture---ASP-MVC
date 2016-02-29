using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Position
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id_position { get; set; }

        [Display(Name = "Lattitude de la position")]
        public String Latitude { get; set; }

        [Display(Name = "Longtitude de la position")]
        public String Longtitude { get; set; }

        public int User { get; set; }

    }
}