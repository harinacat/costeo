using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Panderia.Models;


namespace MVC_Panderia.Controllers
{
    public class cabecera_recetaController : Controller
    {
        pan_dbEntities db = new pan_dbEntities();

        // GET: cabecera_receta
        public ActionResult Index()
        {
            return View(db.cabecera_receta.ToList());
        }

        // GET: cabecera_receta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: cabecera_receta/Create
        public ActionResult Create()
        {
            ViewBag.articuloId = new SelectList(db.articulo, "Id", "nombre");
            return View();
        }

        // POST: cabecera_receta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                cabecera_receta cr = new cabecera_receta();
                cr.articuloId = Convert.ToInt32(collection.Get("articuloId"));
                db.cabecera_receta.Add(cr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception exp)
            {
                return View();
            }
        }

        // GET: cabecera_receta/Edit/5
        public ActionResult Edit(int id)
        {
            var Row = db.cabecera_receta.Where(s => s.Id == id).FirstOrDefault();
            if (Row == null)
            {
                return View();
            }
            ViewBag.articuloId = new SelectList(db.articulo, "Id", "nombre", Row.articuloId);
            return View(Row);
        }

        // POST: cabecera_receta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                cabecera_receta cr = new cabecera_receta();
                cr = db.cabecera_receta.Find(id);
                cr.articuloId = Convert.ToInt32(collection.Get("articuloId"));
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: cabecera_receta/Delete/5
        public ActionResult Delete(int id)
        {
            var Row = db.cabecera_receta.Where(s => s.Id == id).FirstOrDefault();
            if (Row == null)
            {
                return View();
            }
            ViewBag.articuloId = new SelectList(db.articulo, "Id", "nombre", Row.articuloId);
            return View(Row);
        }

        // POST: cabecera_receta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                cabecera_receta cr = new cabecera_receta();
                cr = db.cabecera_receta.Find(Convert.ToInt16(collection.Get("id")));
                db.cabecera_receta.Remove(cr);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: detalle_receta
        public ActionResult IndexDetail(int id, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id;
            return View(db.detalle_receta.Where(s => s.cabecera_recetaId == id));
        }

        // GET: DetalleReceta/Create
        public ActionResult CreateDetail(int id, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id;
            ViewBag.articuloId = new SelectList(db.articulo, "Id", "nombre");
           
            return View();
        }

        // POST: DetalleReceta/CreateDetail
        [HttpPost]
        public ActionResult CreateDetail(FormCollection collection, int id, string nombre)
        {
            try
            {
                // TODO: Add insert logic here
                detalle_receta dr = new detalle_receta();
                dr.articuloId = Convert.ToInt32(collection.Get("articuloId"));
                dr.cantidad = Convert.ToDecimal(collection.Get("cantidad"));
                dr.cabecera_recetaId = id;
                db.detalle_receta.Add(dr);
                db.SaveChanges();
                return RedirectToAction("IndexDetail", new { id=id, nombre=nombre});
            }
            catch
            {
                return View();
            }
        }

        // GET: detalle_receta/Edit/5
        public ActionResult EditDetail(int id, int id_cabecera, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id_cabecera;
            var Row = db.detalle_receta.Where(s => s.Id == id).FirstOrDefault();
            if (Row == null)
            {
                return View();
            }
            ViewBag.articuloId = new SelectList(db.articulo, "Id", "nombre", Row.articuloId);
            return View(Row);
        }

        // POST: detalle_receta/Edit/5
        [HttpPost]
        public ActionResult EditDetail(FormCollection collection, int id, int id_cabecera, string nombre)
        {
            try
            {
                // TODO: Add update logic here
                detalle_receta cr = new detalle_receta();
                cr = db.detalle_receta.Find(id);
                cr.articuloId = Convert.ToInt32(collection.Get("articuloId"));
                cr.cantidad = Convert.ToDecimal(collection.Get("cantidad"));
                db.SaveChanges();

                return RedirectToAction("IndexDetail", new { id = id_cabecera, nombre = nombre });
            }
            catch
            {
                return View();
            }
        }

        // GET: detalle_receta/Delete/5
        public ActionResult DeleteDetail(int id, int id_cabecera, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id_cabecera;
            var Row = db.detalle_receta.Where(s => s.Id == id).FirstOrDefault();
            if (Row == null)
            {
                return View();
            }
            ViewBag.articuloId = new SelectList(db.articulo, "Id", "nombre", Row.articuloId);
            return View(Row);
        }

        // POST: detalle_receta/Delete/5
        [HttpPost]
        public ActionResult DeleteDetail(FormCollection collection, int id, int id_cabecera, string nombre)
        {
            try
            {
                detalle_receta cr = new detalle_receta();
                cr = db.detalle_receta.Find(Convert.ToInt16(collection.Get("id")));
                db.detalle_receta.Remove(cr);
                db.SaveChanges();

                return RedirectToAction("IndexDetail", new { id = id_cabecera, nombre = nombre });
            }
            catch
            {
                return View();
            }
        }


    }

}