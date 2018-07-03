using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Panderia.Models;


namespace MVC_Panderia.Controllers
{
    [Authorize]
    public class unidad_medidaController : Controller
    {
        pan_dbEntities db = new pan_dbEntities();

        // GET: Unidad_medida
        public ActionResult Index()
        {
            //return View(db.unidad_medida.ToList());
            return View(db.unidad_medida.ToList().OrderByDescending(s => s.Id));
        }

        // GET: Unidad_medida/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Unidad_medida/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unidad_medida/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                unidad_medida ln = new unidad_medida();
                ln.nombre = collection.Get("nombre");
                db.unidad_medida.Add(ln);
               db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {
                return View();
            }
        }

        // GET: Unidad_medida/Edit/5
        public ActionResult Edit(int id)
        {
            var Row = db.unidad_medida.Where(s => s.Id == id).FirstOrDefault();
            return View(Row);
        }

        // POST: Unidad_medida/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                unidad_medida ln = new unidad_medida();
                ln = db.unidad_medida.Find(Convert.ToInt16(collection.Get("id")));
                ln.nombre = collection.Get("nombre");
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Unidad_medida/Delete/5
        public ActionResult Delete(int id)
        {
            var Row = db.unidad_medida.Where(s => s.Id == id).FirstOrDefault();
            return View(Row);
        }

        // POST: Unidad_medida/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                unidad_medida ln = new unidad_medida();
                ln = db.unidad_medida.Find(Convert.ToInt16(collection.Get("id")));
                db.unidad_medida.Remove(ln);
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