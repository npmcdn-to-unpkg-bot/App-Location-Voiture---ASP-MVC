using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class User
    {
       
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id_user { get; set; }

        public int Role { get; set; }

        [Required]
        [Display(Name = "Courrier électronique")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Name")]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Experience of drive")]
        public int DriveExperience { get; set; }

        [Display(Name = "Driving Habits")]
        [StringLength(60, MinimumLength = 3)]
        public string DriveHabits { get; set; }

       
    }

    public class LoginUser
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Display(Name = "Mémoriser le mot de passe ?")]
        public bool RememberMe { get; set; }
    }

}
