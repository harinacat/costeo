using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Panderia.Models;


namespace MVC_Panderia.Controllers
{
    [Authorize]
    public class cabecera_produccionController : Controller
    {
        pan_dbEntities db = new pan_dbEntities();
        // GET: Linea
        public ActionResult Index()
        {
            return View(db.cabecera_produccion.ToList().OrderByDescending(x => x.Id));
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
                cabecera_produccion ln = new cabecera_produccion();
                ln.fecha = Convert.ToDateTime(collection.Get("fecha"));
                db.cabecera_produccion.Add(ln);
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
                cabecera_produccion ln = new cabecera_produccion();
                ln = db.cabecera_produccion.Find(Convert.ToInt16(collection.Get("Id")));
                ln.fecha = Convert.ToDateTime(collection.Get("fecha"));
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception exp)
            {
                return View();
            }
        }

        // GET: Linea/Delete/5
        public ActionResult Delete(int id)
        {
            var Row = db.cabecera_produccion.Where(s => s.Id == id).FirstOrDefault();
            return View(Row);
        }

        // POST: Linea/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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

        // GET: cabecera_produccion
        public ActionResult IndexDetail(int id, string nombre)
        {
            cabecera_produccion ln = new cabecera_produccion();
            ln = db.cabecera_produccion.Find(id);
            ViewBag.Fecha = ln.fecha.ToShortDateString();
            ViewBag.cabecera_produccionId = id;
            var Row = db.detalle_produccion.Where(s => s.cabecera_produccionId == id);
            return View(Row);
        }

        // GET: DetalleProduccion/Create
        public ActionResult CreateDetail(int id, string nombre)
        {

            var Resultado = from CabRec in db.cabecera_receta
                        join Articulo in db.articulo on CabRec.articuloId equals Articulo.Id
                        select new
                        {
                            CabRec.Id,
                            Articulo.nombre,
                        };

            ViewBag.cabecera_recetaId = new SelectList(Resultado, "Id", "nombre");
            return View();
        }

        // POST: DetalleProduccion/CreateDetail
        [HttpPost]
        public ActionResult CreateDetail(FormCollection collection, int id)
        {
            try
            {
                // TODO: Add insert logic here
                detalle_produccion dr = new detalle_produccion();
                dr.kilos = Convert.ToInt32(collection.Get("kilos"));
                dr.cabecera_recetaId = Convert.ToInt16(collection.Get("cabecera_recetaId"));
                dr.cabecera_produccionId = id;
                var RowCabeceraProduccion = db.cabecera_produccion.Where(s => s.Id == dr.cabecera_produccionId).First();
                var RowCosto = db.costo.Where(s => s.cabecera_recetaId == dr.cabecera_recetaId && s.fecha <= RowCabeceraProduccion.fecha).OrderByDescending(s => s.fecha).First();
                var RowVenta = db.precio_venta.Where(s => s.cabecera_recetaId == dr.cabecera_recetaId && s.fecha <= RowCabeceraProduccion.fecha).OrderByDescending(s => s.fecha).First();
                dr.fechacosto = RowCosto.fecha;
                dr.fechaventa = RowVenta.fecha;
                db.detalle_produccion.Add(dr);
                db.SaveChanges();
                return RedirectToAction("IndexDetail", new { id = id});
            }
            catch(Exception exp)
            {
                return View();
            }
        }

        // GET: detalle_produccion/Edit/5
        public ActionResult EditDetail(int id, int id_cabecera)
        {
            ViewBag.cabecera_produccionId = id_cabecera;
            var Row = db.detalle_produccion.Where(s => s.Id == id).FirstOrDefault();
            var Resultado = from CabRec in db.cabecera_receta
                            join Articulo in db.articulo on CabRec.articuloId equals Articulo.Id
                            select new
                            {
                                CabRec.Id,
                                Articulo.nombre,
                            };

            ViewBag.cabecera_recetaId = new SelectList(Resultado, "Id", "nombre", Row.cabecera_recetaId);
            return View(Row);
        }

        // POST: detalle_receta/Edit/5
        [HttpPost]
        public ActionResult EditDetail(FormCollection collection, int id, int id_cabecera)
        {
            try
            {
                // TODO: Add update logic here
                detalle_produccion dr = new detalle_produccion();
                dr = db.detalle_produccion.Find(id);

                dr.kilos = Convert.ToDecimal(collection.Get("kilos"));
                dr.cabecera_recetaId = Convert.ToInt16(collection.Get("cabecera_recetaId"));
                var RowCabeceraProduccion = db.cabecera_produccion.Where(s => s.Id == dr.cabecera_produccionId).First();
                var RowCosto = db.costo.Where(s => s.cabecera_recetaId == dr.cabecera_recetaId && s.fecha <= RowCabeceraProduccion.fecha).OrderByDescending(s => s.fecha).First();
                var RowVenta = db.precio_venta.Where(s => s.cabecera_recetaId == dr.cabecera_recetaId && s.fecha <= RowCabeceraProduccion.fecha).OrderByDescending(s => s.fecha).First();
                dr.fechacosto = RowCosto.fecha;
                dr.fechaventa = RowVenta.fecha;
                db.SaveChanges();

                return RedirectToAction("IndexDetail", new { id = id_cabecera});
            }
            catch(Exception exp)
            {
                return View();
            }
        }

        // GET: detalle_receta/Delete/5
        public ActionResult DeleteDetail(int id, int id_cabecera)
        {
            ViewBag.cabecera_produccionId = id_cabecera;
            var Row = db.detalle_produccion.Where(s => s.Id == id).FirstOrDefault();
            ViewBag.cabecera_recetaId = new SelectList(db.cabecera_receta, "Id", "Id", Row.cabecera_recetaId);
            return View(Row);
        }

        // POST: detalle_receta/Delete/5
        [HttpPost]
        public ActionResult DeleteDetail(FormCollection collection, int id, int id_cabecera, string nombre)
        {
            try
            {
                detalle_produccion cr = new detalle_produccion();
                cr = db.detalle_produccion.Find(Convert.ToInt16(collection.Get("id")));
                db.detalle_produccion.Remove(cr);
                db.SaveChanges();
                return RedirectToAction("IndexDetail", new { id = id_cabecera});
            }
            catch
            {
                return View();
            }
        }
    }
}