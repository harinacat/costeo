﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Panderia.Models;


namespace MVC_Panderia.Controllers
{
    public class familiaController : Controller
    {
        // GET: Familia
        public ActionResult Index()
        {
            pan_dbEntities db = new pan_dbEntities();
            var familias = db.familia.ToList();
            ViewBag.familias = familias;
            return View(db.familia.ToList());
        }

        // GET: Familia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Familia/Create
        public ActionResult Create()
        {
           
            pan_dbEntities db = new pan_dbEntities();
            ViewBag.lineaId = new SelectList(db.linea, "Id", "nombre");
            return View();

        }

        // POST: Familia/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
               
                pan_dbEntities db = new pan_dbEntities();
                familia fml = new familia();
                fml.lineaId = Convert.ToInt32(collection.Get("lineaId"));
                fml.nombre = collection.Get("nombre");
                db.familia.Add(fml);
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
            pan_dbEntities db = new pan_dbEntities();
            var Row = db.familia.Where(s => s.Id == id).FirstOrDefault();
            if (Row == null)
            {
                return View();
            }
            ViewBag.lineaId = new SelectList(db.linea, "Id", "nombre", Row.lineaId);
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
                familia fml = new familia();
                fml = db.familia.Find(Convert.ToInt16(collection.Get("id")));
                fml.nombre = collection.Get("nombre");
                fml.lineaId = Convert.ToInt16(collection.Get("lineaId"));
               
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Familia/Delete/5
        public ActionResult Delete(int id)
        {
            pan_dbEntities db = new pan_dbEntities();
            var Row = db.familia.Where(s => s.Id == id).FirstOrDefault();
            if (Row == null)
            {
                return View();
            }
            ViewBag.lineaId = new SelectList(db.linea, "Id", "nombre", Row.lineaId);
            return View(Row);
        }

        // POST: Familia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                pan_dbEntities db = new pan_dbEntities();
                familia fml = new familia();
                fml = db.familia.Find(Convert.ToInt16(collection.Get("id")));
                db.familia.Remove(fml);
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