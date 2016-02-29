using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ModelContext : DbContext
    {
        public System.Data.Entity.DbSet<WebApplication2.Models.Role> Roles { get; set; }
        public System.Data.Entity.DbSet<WebApplication2.Models.Position> Positions { get; set; }
        public System.Data.Entity.DbSet<WebApplication2.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.Voiture> Voitures { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.Location> Locations { get; set; }
    }

   
}