using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Panderia.Models;
using MVC_Panderia.Controllers;
namespace MVC_Panderia.Tests.Datos
{
    [TestClass]
    public class Detalle_recetaTest
    {
        pan_dbEntities db = new pan_dbEntities();
       
      

        [TestMethod]
        public void InsercionDetalleReceta()
        {
            int drct_originales = db.detalle_receta.Count(); 
            detalle_receta drct = new detalle_receta();
            decimal cantidad_detalle_receta = 18;
            int cabecera_receta_id = 1;
            int id_articulo = 1;
            drct.cantidad = cantidad_detalle_receta;
            drct.articuloId = id_articulo;
            drct.cabecera_recetaId = cabecera_receta_id;
            db.detalle_receta.Add(drct);
            db.SaveChanges();

            int drct_cambiadas = db.detalle_receta.Count();
            Assert.AreEqual(drct_originales + 1, drct_cambiadas);
            db.detalle_receta.Remove(drct);
            db.SaveChanges();
        }
        [TestMethod]
        public void EliminarDetalleReceta()
        {
            int drct_originales = db.detalle_receta.Count();
            detalle_receta drct = new detalle_receta();
            decimal cantidad_detalle_receta = 18;
            int cabecera_receta_id = 1;
            int id_articulo = 1;
            drct.cantidad = cantidad_detalle_receta;
            drct.articuloId = id_articulo;
            drct.cabecera_recetaId = cabecera_receta_id;
            db.detalle_receta.Add(drct);
            db.SaveChanges();

            int ultimo_detalle_agregado = db.detalle_receta.OrderByDescending(x => x.Id).First().Id;
            drct = db.detalle_receta.Find(Convert.ToInt16(ultimo_detalle_agregado));
            db.detalle_receta.Remove(drct);
            db.SaveChanges();
            int drct_cambiadas = db.detalle_receta.Count();
            Assert.AreEqual(drct_cambiadas, drct_originales);

        }

        [TestMethod]
        public void MultipleDetalleReceta()
        {
            // insertar
            int drct_originales = db.detalle_receta.Count();
            detalle_receta drct = new detalle_receta();
            decimal cantidad_detalle_receta = 18;
            int cabecera_receta_id = 1;
            int id_articulo = 1;
            drct.cantidad = cantidad_detalle_receta;
            drct.articuloId = id_articulo;
            drct.cabecera_recetaId = cabecera_receta_id;
            db.detalle_receta.Add(drct);
            db.SaveChanges();

            //prueba que se ingrese
            int drct_cambiadas = db.detalle_receta.Count();
            Assert.AreEqual(drct_originales + 1, drct_cambiadas);

            detalle_receta drct2 = new detalle_receta();
            int detalle_agregado = db.detalle_receta.OrderByDescending(x => x.Id).First().Id;
            drct2 = db.detalle_receta.Find(Convert.ToInt16(detalle_agregado));
            //Prueba de buscar
            Assert.AreEqual(drct2.articuloId, id_articulo);

            db.detalle_receta.Remove(drct2);
            db.SaveChanges();
            int drct_cambiadas_eliminacion = db.detalle_receta.Count();
            //Prueba si se eliminó
            Assert.AreEqual(drct_cambiadas - 1, drct_cambiadas_eliminacion);
        }

    }
}
