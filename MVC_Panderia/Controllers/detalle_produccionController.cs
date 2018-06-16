using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Panderia.Models;

namespace MVC_Panderia.Controllers
{

    public class detalle_produccionController
    {

    public class cabecera_produccionController:Controller
     {
        // GET: Linea
        public ActionResult Index()
        {
            pan_dbEntities1 db = new pan_dbEntities1();
            var cabecera_produccion = db.cabecera_produccion.ToList();
            ViewBag.cabecera_produccion = cabecera_produccion;
            return View();
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                pan_dbEntities1 db = new pan_dbEntities1();
                cabecera_produccion ln = new cabecera_produccion();
                ln.fecha = Convert.ToDateTime(collection.Get("fecha"));
                db.cabecera_produccion.Add(ln);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch(Exception exp)
            {
                return View();
            }
        }

        // GET: Linea/Edit/5
        public ActionResult Edit(int id)
        {
            pan_dbEntities1 db = new pan_dbEntities1();
            var Row = db.cabecera_produccion.Where(s => s.Id == id).FirstOrDefault();
            return View(Row);
        }

        // POST: Linea/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                pan_dbEntities1 db = new pan_dbEntities1();
                cabecera_produccion ln = new cabecera_produccion();
                ln = db.cabecera_produccion.Find(Convert.ToInt16(collection.Get("fecha")));
                ln.fecha = Convert.ToDateTime(collection.Get("fecha"));
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Linea/Delete/5
        public ActionResult Delete(int id)
        {
            pan_dbEntities1 db = new pan_dbEntities1();
            var Row = db.cabecera_produccion.Where(s => s.Id == id).FirstOrDefault();
            return View(Row);
        }

        // POST: Linea/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                pan_dbEntities1 db = new pan_dbEntities1();
                cabecera_produccion ln = new cabecera_produccion();
                ln = db.cabecera_produccion.Find(Convert.ToInt16(collection.Get("id")));
                db.cabecera_produccion.Remove(ln);
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
}