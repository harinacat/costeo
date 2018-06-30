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
        pan_dbEntities db = new pan_dbEntities();

        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult signIn(FormCollection collection)
        {
            //var Row = db.usuarios.Where(s => s.Id == collection.Get("Id")).FirstOrDefault();
            var Row = db.usuario.Find(collection.Get("Id"));
            if (Row!=null)
            {
                Helpers.sha1 OjbSha1 = new Helpers.sha1();
                if (Row.contraseña == OjbSha1.Encode(collection.Get("contrasena")))
                {
                    Session["rol"] = Row.rolId;
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
        [Authorize]
        public ActionResult Index()
        {
            return View(db.usuario.ToList().OrderBy(s => s.Id));
        }

        // GET: Linea/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Linea/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.rolId = new SelectList(db.rol, "Id", "nombre_rol");
            return View();
        }

        // POST: Linea/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(FormCollection collection, string txt_password_confirmar)
        {
            try
            {
                // TODO: Add insert logic here
                usuario usr = new usuario();
                usr.Id = collection.Get("Id");
                usr.nombre_usuario = collection.Get("nombre_usuario");
                usr.rolId = Convert.ToInt32(collection.Get("rolId"));
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
                db.usuario.Add(usr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {
                return View();
            }
        }

        // GET: Linea/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            ViewBag.rolId = new SelectList(db.rol, "Id", "nombre_rol");
            
            var Row = db.usuario.Where(s => s.Id == id).FirstOrDefault();
            return View(Row);
        }

        // POST: Linea/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(string id, FormCollection collection, string txt_password_confirmar)
        {
            try
            {
                // TODO: Add update logic here
                usuario usr = new usuario();
                usr = db.usuario.Find(id);
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
                usr.rolId = Convert.ToInt32(collection.Get("rolId"));
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception exp)
            {
                return View();
            }
        }

        // GET: Linea/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            var Row = db.usuario.Where(s => s.Id == id).FirstOrDefault();
            return View(Row);
        }

        // POST: Linea/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                usuario usr = new usuario();
                usr = db.usuario.Find(id);
                db.usuario.Remove(usr);
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