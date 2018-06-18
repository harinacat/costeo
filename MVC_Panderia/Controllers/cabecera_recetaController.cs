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
        pan_dbEntities1 db = new pan_dbEntities1();

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
            ViewBag.articuloId = new SelectList(db.articuloes, "Id", "nombre");
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
            ViewBag.articuloId = new SelectList(db.articuloes, "Id", "nombre", Row.articuloId);
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

    }
}