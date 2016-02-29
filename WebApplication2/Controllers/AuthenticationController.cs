using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AuthenticationController : Controller
    {
        private ModelContext db = new ModelContext();
        // GET: Authentication
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                RedirectToAction("Denies");
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult Denies()
        {
            return View(); 
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUser model, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (ValidateUser(model.Email, model.Password) == null)
            {
                ModelState.AddModelError(string.Empty, "Le nom d'utilisateur ou le mot de passe est incorrect.");
                return View(model);
            }

            // L'authentification est réussie, 
            // injecter l'identifiant utilisateur dans le cookie d'authentification :
            var loginClaim = new Claim(ClaimTypes.NameIdentifier, ValidateUser(model.Email, model.Password).Name);
            var claimsIdentity = new ClaimsIdentity(new[] { loginClaim }, DefaultAuthenticationTypes.ApplicationCookie);
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignIn(claimsIdentity);

            // Rediriger vers l'URL d'origine :
            if (Url.IsLocalUrl(ViewBag.ReturnUrl))
                return Redirect(ViewBag.ReturnUrl);
            // Par défaut, rediriger vers la page d'accueil :
            return RedirectToAction("Index", "Home");
        }

        private User ValidateUser(string email, string password) {

            User user = null;
            var query = (from u in db.Users where u.Email == email && u.Password==password select u).ToList() ;
            if (query.Count > 0)
            {
                Session["id"] = query.First().Id_user;
                Session["role"] = query.First().Role;
                user = query.First();
               
            }
            return user;
        }
        [HttpGet]
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut();
            Session.Remove("id_user");
            // Rediriger vers la page d'accueil :
            return RedirectToAction("Index", "Home");
        }
    }
}