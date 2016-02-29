using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Role
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id_Role { get; set; }

        [Display(Name = "Role ")]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
    }
}