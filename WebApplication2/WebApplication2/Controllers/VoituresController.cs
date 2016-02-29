using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class VoituresController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: Voitures
        public ActionResult Index()
        {
            return View(db.Voitures.ToList());
        }

        // GET: Voitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // GET: Voitures/Create
        public ActionResult Create()
        {
            int id = Convert.ToInt32(HttpContext.Session["id"].ToString());

            IEnumerable<SelectListItem> position = db.Positions.Where(Position => Position.User == id).Select(
               Position => new SelectListItem
               {
                   Text = Position.Latitude + " - " + Position.Latitude,
                   Value = Position.Id_position + ""
               });

            ViewData["position"] = position;
            return View();
        }

        // POST: Voitures/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_voiture,User,Position,Brand,Model,Description,Kilometers,BuyIngDate,Status,Prix_parJour")] Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(HttpContext.Session["id"].ToString());
                voiture.User = id;
                db.Voitures.Add(voiture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voiture);
        }

        // GET: Voitures/Edit/5
        public ActionResult Edit(int? id)
        {
            String id_edit = Convert.ToString(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (HttpContext.Session["id"].ToString() != id_edit && HttpContext.Session["id"].ToString() != "1")
            {
                RedirectToAction("Login", "Authentication");
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            int id_user = Convert.ToInt32(HttpContext.Session["id"].ToString());

            IEnumerable<SelectListItem> position = db.Positions.Where(Position => Position.User == id_user).Select(
               Position => new SelectListItem
               {
                   Text = Position.Latitude + " - " + Position.Latitude,
                   Value = Position.Id_position + ""
               });

            ViewData["Position"] = position;
            return View(voiture);
        }

        // POST: Voitures/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_voiture,User,Position,Brand,Model,Description,Kilometers,BuyIngDate,Status,Prix_parJour")] Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voiture);
        }

        // GET: Voitures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voiture voiture = db.Voitures.Find(id);
            db.Voitures.Remove(voiture);
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
