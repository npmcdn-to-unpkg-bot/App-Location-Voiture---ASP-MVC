using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private ModelContext db = new ModelContext();
       
        // GET: Users
        [Authorize(Roles = "ADMIN")]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

      
        public ActionResult IndexSearchVoiture()
        {
           
            IEnumerable<SelectListItem> items = db.Voitures.Select(
                Voiture => new SelectListItem
                {
                    Text = Voiture.Model,
                    Value = Voiture.Model
                });

            IEnumerable<SelectListItem> brand = db.Voitures.Select(
            Voiture => new SelectListItem
            {
                Text = Voiture.Brand,
                Value = Voiture.Brand
            });

            IEnumerable<SelectListItem> position = db.Positions.Select(
           Position => new SelectListItem
           {
               Text = Position.Latitude+" - "+Position.Longtitude,
               Value = Position.Id_position + ""
           });

            ViewData["Model"] = items;
            ViewData["Brand"] = brand;
            ViewData["Position"] = position;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AfficherListeVoiture(string model, string brand, int? id)
        {
            List<Voiture> list = db.Voitures.ToList();
            if (model != "") {
                foreach (Voiture v in list)
                {
                    if(v.Model != model)
                    {
                        list.Remove(v);
                    }
                }
            }
            if (brand != "")
            {
                foreach (Voiture v in list)
                {
                    if (v.Brand != brand)
                    {
                        list.Remove(v);
                    }
                }
            }

            if (id != null)
            {
                foreach (Voiture v in list)
                {
                    if (v.Position != id)
                    {
                        list.Remove(v);
                    }
                }
            }
            return View(list);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> role = db.Roles.Select(
          Role => new SelectListItem
          {
              Text = Role.Name,
              Value = Role.Id_Role + ""
          });
            ViewData["Role"] = role;
            return View();
        }

        // POST: Users/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create([Bind(Include = "Id_user,Role,Email,Name,Password,ConfirmPassword,DriveExperience,DriveHabits")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = 2;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login","Authentication");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            IEnumerable<SelectListItem> role = db.Roles.Select(
         Role => new SelectListItem
         {
             Text = Role.Name,
             Value = Role.Id_Role + ""
         });
            return View(user);
        }

        // POST: Users/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_user,Role,Email,Name,Password,ConfirmPassword,DriveExperience,DriveHabits")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "ADMIN")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
