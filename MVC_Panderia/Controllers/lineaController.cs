using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Panderia.Models;


namespace MVC_Panderia.Controllers
{
    public class lineaController:Controller
     {
        // GET: Linea
        public ActionResult Index()
        {
            pan_dbEntities db = new pan_dbEntities();
            var lineas = db.linea.ToList();
            ViewBag.lineas = lineas;
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
                pan_dbEntities db = new pan_dbEntities();
                linea ln = new linea();
                ln.nombre = collection.Get("nombre");
                db.linea.Add(ln);
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
            pan_dbEntities db = new pan_dbEntities();
            var Row = db.linea.Where(s => s.Id == id).FirstOrDefault();
            if (Row == null)
            {
                return View();
            }
            return View(Row);
        }

        // POST: Linea/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                pan_dbEntities db = new pan_dbEntities();
                linea ln = new linea();
                ln = db.linea.Find(Convert.ToInt16(collection.Get("id")));
                ln.nombre = collection.Get("nombre");
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
            pan_dbEntities db = new pan_dbEntities();
            var Row = db.linea.Where(s => s.Id == id).FirstOrDefault();
            if (Row == null)
            {
                return View();
            }
            return View(Row);
        }

        // POST: Linea/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                pan_dbEntities db = new pan_dbEntities();
                linea ln = new linea();
                ln = db.linea.Find(Convert.ToInt16(collection.Get("id")));
                db.linea.Remove(ln);
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