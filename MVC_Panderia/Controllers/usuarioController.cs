using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_Panderia.Models;


namespace MVC_Panderia.Controllers
{
    public class usuarioController : Controller
    {
        pan_dbEntities1 db = new pan_dbEntities1();

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult signIn(FormCollection collection)
        {
            //var Row = db.usuarios.Where(s => s.Id == collection.Get("Id")).FirstOrDefault();
            var Row = db.usuarios.Find(collection.Get("Id"));
            if (Row!=null)
            {
                Helpers.sha1 OjbSha1 = new Helpers.sha1();
                if (Row.contraseña == OjbSha1.Encode(collection.Get("contrasena")))
                {
                    FormsAuthentication.SetAuthCookie(collection.Get("Id"), false);
                }
                else
                {
                    TempData["message-error"] = "Usuario o contraseña incorrectas";
                }
            }
            else
            {
                TempData["message-error"] = "Usuario o contraseña incorrectas";
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            return Redirect(Url.Content("~/"));

        }

        // GET: Linea
        public ActionResult Index()
        {
            return View(db.usuarios.ToList());
        }

        // GET: Linea/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Linea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Linea/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, string txt_password_confirmar)
        {
            try
            {
                // TODO: Add insert logic here
                pan_dbEntities1 db = new pan_dbEntities1();
                usuario usr = new usuario();
                usr.Id = collection.Get("Id");
                usr.nombre_usuario = collection.Get("nombre_usuario");
                if (txt_password_confirmar != null)
                {
                    MVC_Panderia.Helpers.sha1 objSha1 = new Helpers.sha1();
                    usr.contraseña = objSha1.Encode(txt_password_confirmar);
                }
                else
                {
                    usr.contraseña = collection.Get("contraseña");
                }
                usr.email = collection.Get("email");
                db.usuarios.Add(usr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {
                return View();
            }
        }

        // GET: Linea/Edit/5
        public ActionResult Edit(string id)
        {
            pan_dbEntities1 db = new pan_dbEntities1();
            var Row = db.usuarios.Where(s => s.Id == id).FirstOrDefault();
            return View(Row);
        }

        // POST: Linea/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection, string txt_password_confirmar)
        {
            try
            {
                // TODO: Add update logic here
                pan_dbEntities1 db = new pan_dbEntities1();
                usuario usr = new usuario();
                usr = db.usuarios.Find(id);
                usr.nombre_usuario = collection.Get("nombre_usuario");
                if (txt_password_confirmar != null)
                {
                    MVC_Panderia.Helpers.sha1 objSha1 = new Helpers.sha1();
                    usr.contraseña = objSha1.Encode(txt_password_confirmar);
                }
                else
                {
                    usr.contraseña = collection.Get("contraseña");
                }
                usr.email = collection.Get("email");
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception exp)
            {
                return View();
            }
        }

        // GET: Linea/Delete/5
        public ActionResult Delete(string id)
        {
            pan_dbEntities1 db = new pan_dbEntities1();
            var Row = db.usuarios.Where(s => s.Id == id).FirstOrDefault();
            return View(Row);
        }

        // POST: Linea/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                pan_dbEntities1 db = new pan_dbEntities1();
                usuario usr = new usuario();
                usr = db.usuarios.Find(id);
                db.usuarios.Remove(usr);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}