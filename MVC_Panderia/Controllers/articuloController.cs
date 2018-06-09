using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Panderia.Models;

namespace MVC_Panderia.Controllers
{
    public class articuloController: Controller
    {
        pan_dbEntities1 db = new pan_dbEntities1();

        // GET: Linea
        public ActionResult Index()
        {
            return View(db.articuloes.ToList());
        }

        // GET: Linea/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Linea/Create
        public ActionResult Create()
        {
            ViewBag.familiaId = new SelectList(db.familias, "Id", "nombre");
            ViewBag.unidad_medidaId= new SelectList(db.unidad_medida, "Id", "nombre");
            return View();
        }

        // POST: Linea/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                articulo ar = new articulo();
                ar.familiaId = Convert.ToInt32(collection.Get("familiaId"));
                ar.nombre = collection.Get("nombre");
                ar.unidad_medidaId = Convert.ToInt32(collection.Get("unidad_medidaId"));
                ar.codigo_barra = collection.Get("codigo_barra");
                ar.marca= collection.Get("marca");
                ar.formato = collection.Get("formato");
                db.articuloes.Add(ar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Linea/Edit/5
        public ActionResult Edit(int id)
        {
            
            var Row = db.articuloes.Where(s => s.Id == id).FirstOrDefault();
            ViewBag.familiaId = new SelectList(db.familias, "Id", "nombre", Row.familiaId );
            ViewBag.unidad_medidaId = new SelectList(db.unidad_medida, "Id", "nombre", Row.unidad_medidaId);
            return View(Row);
        }

        // POST: Linea/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                articulo ar = new articulo();
                ar = db.articuloes.Find(Convert.ToInt16(collection.Get("id")));
                ar.familiaId = Convert.ToInt32(collection.Get("familiaId"));
                ar.nombre = collection.Get("nombre");
                ar.unidad_medidaId = Convert.ToInt32(collection.Get("unidad_medidaId"));
                ar.codigo_barra = collection.Get("codigo_barra");
                ar.marca = collection.Get("marca");
                ar.formato = collection.Get("formato");
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
            var Row = db.articuloes.Where(s => s.Id == id).FirstOrDefault();
            ViewBag.familiaId = new SelectList(db.familias, "Id", "nombre", Row.familiaId);
            ViewBag.unidad_medidaId = new SelectList(db.unidad_medida, "Id", "nombre", Row.unidad_medidaId);
            return View(Row);
        }

        // POST: Linea/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                articulo ar = new articulo();
                ar = db.articuloes.Find(Convert.ToInt16(collection.Get("id")));
                db.articuloes.Remove(ar);
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