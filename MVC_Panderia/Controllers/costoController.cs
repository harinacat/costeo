using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Panderia.Models;


namespace MVC_Panderia.Controllers
{
    public class costoController : Controller
    {
        // GET: Costo
        public ActionResult Index()
        {
            pan_dbEntities1 db = new pan_dbEntities1();
            var costo = db.costos.ToList();
            ViewBag.costo = costo;
            return View();
        }

        // GET: Costo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Linea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Costo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                pan_dbEntities1 db = new pan_dbEntities1();
                costo cs = new costo();
                cs.fecha = Convert.ToDateTime(collection.Get("fecha"));
                cs.valor = Convert.ToInt32(collection.Get("valor"));
                db.costos.Add(cs);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {
                return View();
            }
        }

        // GET: Costo/Edit/5
        public ActionResult Edit(int id)
        {
            pan_dbEntities1 db = new pan_dbEntities1();
            var Row = db.costos.Where(s => s.Id == id).FirstOrDefault();
            return View(Row);
        }

        // POST: Costo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                pan_dbEntities1 db = new pan_dbEntities1();
                costo cs = new costo();
                cs = db.costos.Find(Convert.ToInt16(collection.Get("id")));
                cs.fecha = Convert.ToDateTime(collection.Get("fecha"));
                cs.valor = Convert.ToInt32(collection.Get("valor"));
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Costo/Delete/5
        public ActionResult Delete(int id)
        {
            pan_dbEntities1 db = new pan_dbEntities1();
            var Row = db.costos.Where(s => s.Id == id).FirstOrDefault();
            return View(Row);
        }

        // POST: Costo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                pan_dbEntities1 db = new pan_dbEntities1();
                costo cs = new costo();
                cs = db.costos.Find(Convert.ToInt16(collection.Get("id")));
                db.costos.Remove(cs);
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