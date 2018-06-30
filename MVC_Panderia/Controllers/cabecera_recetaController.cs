using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Panderia.Models;


namespace MVC_Panderia.Controllers
{
    [Authorize]
    public class cabecera_recetaController : Controller
    {
        pan_dbEntities db = new pan_dbEntities();

        // GET: cabecera_receta
        public ActionResult Index()
        {
            return View(db.cabecera_receta.ToList().OrderByDescending(s => s.Id));
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
            if(Row==null)
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
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id;
            ViewBag.articuloId = new SelectList(db.articulo, "Id", "nombre");
            try
            {
                if (Convert.ToInt32(collection.Get("cantidad")) < 0)
                {
                    ViewBag.Error = "Valor no puede ser negativo";
                    return (View());
                }
                // TODO: Add insert logic here
                detalle_receta dr = new detalle_receta();
                dr.articuloId = Convert.ToInt32(collection.Get("articuloId"));
                dr.cantidad = Convert.ToDecimal(collection.Get("cantidad"));
                dr.cabecera_recetaId = id;
                db.detalle_receta.Add(dr);
                db.SaveChanges();
                return RedirectToAction("IndexDetail", new { id=id, nombre=nombre});
            }
            catch(Exception exp)
            {
                ViewBag.Error = exp.Message;
                return View();
            }
        }

        // GET: detalle_receta/Edit/5
        public ActionResult EditDetail(int id, int id_cabecera, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id_cabecera;
            var Row = db.detalle_receta.Where(s => s.Id == id).FirstOrDefault();
            ViewBag.articuloId = new SelectList(db.articulo, "Id", "nombre", Row.articuloId);
            return View(Row);
        }

        // POST: detalle_receta/Edit/5
        [HttpPost]
        public ActionResult EditDetail(FormCollection collection, int id, int id_cabecera, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id_cabecera;
            ViewBag.articuloId = new SelectList(db.articulo, "Id", "nombre");
            try
            {
                // TODO: Add update logic here
                detalle_receta Row = new detalle_receta();
                if (Convert.ToInt32(collection.Get("cantidad")) < 0)
                {
                    ViewBag.Error = "Valor no puede ser menor a cero";
                    return (View(Row));
                }
                Row = db.detalle_receta.Find(id);
                Row.articuloId = Convert.ToInt32(collection.Get("articuloId"));
                Row.cantidad = Convert.ToDecimal(collection.Get("cantidad"));
                db.SaveChanges();

                return RedirectToAction("IndexDetail", new { id = id_cabecera, nombre = nombre });
            }
            catch(Exception exp)
            {
                ViewBag.Error = exp.Message;
                costo Row = Row = db.costo.Find(new object[] { id_cabecera, Convert.ToDateTime(collection.Get("fecha")) });
                return View(Row);
            }
        }

        // GET: detalle_receta/Delete/5
        public ActionResult DeleteDetail(int id, int id_cabecera, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id_cabecera;
            var Row = db.detalle_receta.Where(s => s.Id == id).FirstOrDefault();
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

        // GET: Costo
        public ActionResult IndexDetailCosto(int id, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id;
            return View(db.costo.Where(s => s.cabecera_recetaId == id).OrderByDescending(s => s.fecha));
        }

        // GET: Costo/Create
        public ActionResult CreateDetailCosto(int id, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id;
            return View();
        }

        // POST: costo/CreateDetail
        [HttpPost]
        public ActionResult CreateDetailCosto(FormCollection collection, int id, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id;
            try
            {
                if (Convert.ToInt32(collection.Get("valor")) < 0)
                {
                    ViewBag.Error = "Valor no puede ser negativo";
                    return (View());
                }
                // TODO: Add insert logic here
                costo dr = new costo();
                dr.cabecera_recetaId = id;
                dr.fecha= Convert.ToDateTime(collection.Get("fecha"));
                dr.valor = Convert.ToInt32(collection.Get("valor"));
                db.costo.Add(dr);
                db.SaveChanges();
                return RedirectToAction("IndexDetailCosto", new { id = id, nombre = nombre });
            }
            catch( Exception exp)
            {
                ViewBag.Error = exp.Message;
                return View();
            }
        }

        // GET: Costo/Edit/5
        public ActionResult EditDetailCosto(DateTime fecha, int id_cabecera, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id_cabecera;
            var Row = db.costo.Where(s => s.cabecera_recetaId == id_cabecera).Where(s=> s.fecha == fecha).FirstOrDefault();
            return View(Row);
        }

        // POST: costo/Edit/5
        [HttpPost]
        public ActionResult EditDetailCosto(FormCollection collection,  int id_cabecera, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id_cabecera;
            try
            {   
                // TODO: Add update costo here
                costo Row = new costo();
                Row = db.costo.Find(new object[] { id_cabecera, Convert.ToDateTime(collection.Get("fecha")) });
                if(Convert.ToInt32(collection.Get("valor"))<0)
                {   
                    ViewBag.Error = "Valor no puede ser menor a cero";
                    return (View(Row));
                }
                Row.valor = Convert.ToInt32(collection.Get("valor"));
                db.SaveChanges();
                return RedirectToAction("IndexDetailCosto", new { id = id_cabecera, nombre = nombre });
            }
            catch(Exception exp)
            {
                ViewBag.Error = exp.Message;
                costo Row = Row = db.costo.Find(new object[] { id_cabecera, Convert.ToDateTime(collection.Get("fecha")) });
                return View(Row);
            }
        }

        // GET: Costo/Delete/5
        public ActionResult DeleteDetailCosto(DateTime fecha, int id_cabecera, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id_cabecera;
            var Row = db.costo.Where(s => s.cabecera_recetaId == id_cabecera).Where(s => s.fecha == fecha).FirstOrDefault();
            return View(Row);
        }

        // POST: Costo/Delete/5
        [HttpPost]
        public ActionResult DeleteDetailCosto(FormCollection collection, int id_cabecera, string nombre)
        {
            try
            {
                costo cr = new costo();
                cr = db.costo.Find(new object[] { id_cabecera, Convert.ToDateTime(collection.Get("fecha")) });
                db.costo.Remove(cr);
                db.SaveChanges();

                return RedirectToAction("IndexDetailCosto", new { id = id_cabecera, nombre = nombre });
            }
            catch
            {
                return View();
            }
        }
        // GET: Precio Venta
        public ActionResult IndexDetailPrecioVenta(int id, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id;
            return View(db.precio_venta.Where(s => s.cabecera_recetaId == id));
        }

        // GET: PrecioVenta/Create
        public ActionResult CreateDetailPrecioVenta(int id, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id;
            return View();
        }

        // POST: PrecioVenta/CreateDetail
        [HttpPost]
        public ActionResult CreateDetailPrecioVenta(FormCollection collection, int id, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id;
            try
            {
                if (Convert.ToInt32(collection.Get("valor")) < 0)
                {
                    ViewBag.Error = "Valor no puede ser negativo";
                    return (View());
                }

                // TODO: Add insert logic here
                precio_venta dr = new precio_venta();
                dr.cabecera_recetaId = id;
                dr.fecha = Convert.ToDateTime(collection.Get("fecha"));
                dr.valor = Convert.ToInt32(collection.Get("valor"));
                db.precio_venta.Add(dr);
                db.SaveChanges();
                return RedirectToAction("IndexDetailPrecioVenta", new { id = id, nombre = nombre });
            }
            catch (Exception exp)
            {
                ViewBag.Error = exp.Message;
                return View();
            }
        }

        // GET: PrecioVenta/Edit/5
        public ActionResult EditDetailPrecioVenta(DateTime fecha, int id_cabecera, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id_cabecera;
            var Row = db.precio_venta.Where(s => s.cabecera_recetaId == id_cabecera).Where(s => s.fecha == fecha).FirstOrDefault();
            return View(Row);
        }

        // POST: PrecioVenta/Edit/5
        [HttpPost]
        public ActionResult EditDetailPrecioVenta(FormCollection collection, int id_cabecera, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id_cabecera;
            try
            {
                // TODO: Add update PrecioVenta here
                precio_venta Row = new precio_venta();
                Row = db.precio_venta.Find(new object[] { id_cabecera, Convert.ToDateTime(collection.Get("fecha")) });
                if (Convert.ToInt32(collection.Get("valor")) < 0)
                {
                    ViewBag.Error = "Valor no puede ser menor a cero";
                    return (View(Row));
                }
                Row.valor = Convert.ToInt32(collection.Get("valor"));
                db.SaveChanges();
                return RedirectToAction("IndexDetailPrecioVenta", new { id = id_cabecera, nombre = nombre });
            }
            catch (Exception exp)
            {
                ViewBag.Error = exp.Message;
                precio_venta Row = Row = db.precio_venta.Find(new object[] { id_cabecera, Convert.ToDateTime(collection.Get("fecha")) });
                return View(Row);
            }
        }

        // GET: PrecioVenta/Delete/5
        public ActionResult DeleteDetailPrecioVenta(DateTime fecha, int id_cabecera, string nombre)
        {
            ViewBag.NombreReceta = nombre;
            ViewBag.cabecera_recetaId = id_cabecera;
            var Row = db.precio_venta.Where(s => s.cabecera_recetaId == id_cabecera).Where(s => s.fecha == fecha).FirstOrDefault();
            return View(Row);
        }

        // POST: PrecioVenta/Delete/5
        [HttpPost]
        public ActionResult DeleteDetailPrecioVenta(FormCollection collection, int id_cabecera, string nombre)
        {
            try
            {
                precio_venta cr = new precio_venta();
                cr = db.precio_venta.Find(new object[] { id_cabecera, Convert.ToDateTime(collection.Get("fecha")) });
                db.precio_venta.Remove(cr);
                db.SaveChanges();

                return RedirectToAction("IndexDetailPrecioVenta", new { id = id_cabecera, nombre = nombre });
            }
            catch
            {
                return View();
            }
        }

    }

}