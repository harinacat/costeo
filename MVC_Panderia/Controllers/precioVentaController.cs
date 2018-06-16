using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Panderia.Models;


namespace MVC_Panderia.Controllers
{
    public class precioVentaController : Controller
    {
        pan_dbEntities1 db = new pan_dbEntities1();
        // GET: Linea
        public ActionResult Index()
        {
            return View(db.precio_venta.ToList());
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
                precio_venta pv = new precio_venta();
                pv.fecha = Convert.ToDateTime(collection.Get("fecha"));
                pv.valor = Convert.ToInt32(collection.Get("valor"));
                db.precio_venta.Add(pv);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {
                return View();
            }
        }

        // GET: Linea/Edit/5
        public ActionResult Edit(int id)
        {
            pan_dbEntities1 db = new pan_dbEntities1();
            var Row = db.precio_venta.Where(s => s.Id == id).FirstOrDefault();
            return View(Row);
        }

        // POST: Precio_Venta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                pan_dbEntities1 db = new pan_dbEntities1();
                precio_venta pv = new precio_venta();
                pv = db.precio_venta.Find(Convert.ToInt16(collection.Get("id")));
                pv.fecha = Convert.ToDateTime(collection.Get("fecha"));
                pv.valor = Convert.ToInt32(collection.Get("valor"));
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
            var Row = db.precio_venta.Where(s => s.Id == id).FirstOrDefault();
            return View(Row);
        }

        // POST: Linea/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                pan_dbEntities1 db = new pan_dbEntities1();
                precio_venta pv = new precio_venta();
                pv = db.precio_venta.Find(Convert.ToInt16(collection.Get("id")));
                db.precio_venta.Remove(pv);
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