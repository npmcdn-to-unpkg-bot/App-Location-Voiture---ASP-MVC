using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Voiture
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id_voiture { get; set; }
       
        public int User {
            get; set;
        }
        
        public String getUser()
        {
            ModelContext db = new ModelContext();
            User u = db.Users.Find(this.User);
            return u.Name+"";
        }
        public int Position { get; set; }

        public String getPosition()
        {
            ModelContext db = new ModelContext();
            Position p = db.Positions.Find(this.Position);
            String s = p.Latitude.ToString() + "-" + p.Longtitude.ToString();
            return s;
        }
        
        [Display(Name = "Brand of Car")]
        [StringLength(60, MinimumLength = 3)]
        public string Brand { get; set; }

        [Display(Name = "Model of Car")]
        [StringLength(60, MinimumLength = 3)]
        public string Model { get; set; }

        [Display(Name = "Description of Car")]
        [StringLength(60, MinimumLength = 3)]
        public string Description { get; set; }

        [Display(Name = "Kilometers of Car")]
        public int Kilometers { get; set; }

        [Display(Name = "Date Buying of Car")]
        [DataType(DataType.Date)]
        public DateTime BuyIngDate { get; set; }

        [Display(Name = "Status of Car")]
        public int Status { get; set; }

        public String getStatus()
        {
            if (this.Status == 1)
                return "Open";
            if (this.Status == 2)
                return "Closed";
            if (this.Status == 3)
                return "Pending";

            return "";
        }
        [Display(Name = "Prix par jour")]
        public int Prix_parJour {get;set;}
    }
}