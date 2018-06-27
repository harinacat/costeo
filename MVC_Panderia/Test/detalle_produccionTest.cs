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
    public class Detalle_produccionTest
    {
        pan_dbEntities db = new pan_dbEntities();
       
      

        [TestMethod]
        public void InsercionDetalleProduccion()
        {
            int dprod_originales = db.detalle_produccion.Count(); 
            detalle_produccion dprod = new detalle_produccion();
            
            int cabecera_producion_id = 1;
            decimal kilos_produccion = 10;
            int cabecera_receta_id = 1;
            int costo_id = 1;
            int venta_id = 1;


            dprod.cabecera_produccionId = cabecera_producion_id;
            dprod.kilos = kilos_produccion;
            dprod.cabecera_recetaId = cabecera_receta_id;
            dprod.costoId = costo_id;
            dprod.ventaId = venta_id;
            db.detalle_produccion.Add(dprod);
            db.SaveChanges();

            int dprod_cambiadas = db.detalle_produccion.Count();
            Assert.AreEqual(dprod_originales + 1, dprod_cambiadas);
            db.detalle_produccion.Remove(dprod);
            db.SaveChanges();
        }
        [TestMethod]
        public void EliminarDetalleProduccion()
        {
            
                int dprod_originales = db.detalle_produccion.Count();
                detalle_produccion dprod = new detalle_produccion();
                int cabecera_produccion_id = 1;
                decimal kilos_produccion = 10;
                int cabecera_receta_id = 1;
                int costo_id = 1;
                int venta_id = 1;
                dprod.cabecera_produccionId = cabecera_produccion_id;
                dprod.kilos = kilos_produccion;
                dprod.cabecera_recetaId = cabecera_receta_id;
                dprod.costoId = costo_id;
                dprod.ventaId = venta_id;
                db.detalle_produccion.Add(dprod);
                db.SaveChanges();

            int ultimo_detalle_agregado = db.detalle_produccion.OrderByDescending(x => x.Id).First().Id;
            dprod = db.detalle_produccion.Find(Convert.ToInt16(ultimo_detalle_agregado));
            db.detalle_produccion.Remove(dprod);
            db.SaveChanges();
            int dprod_cambiadas = db.detalle_produccion.Count();
            Assert.AreEqual(dprod_cambiadas, dprod_originales);

        }

        [TestMethod]
        public void MultipleDetalleProduccion()
        {
            
            detalle_produccion dprod = new detalle_produccion();
            int dprod_originales = db.detalle_produccion.Count();
            int cabecera_produccion_id = 1;
            decimal kilos_produccion = 10;
            int cabecera_receta_id = 1;
            int costo_id = 1;
            int venta_id = 1;
            dprod.cabecera_produccionId = cabecera_produccion_id;
            dprod.kilos = kilos_produccion;
            dprod.cabecera_recetaId = cabecera_receta_id;
            dprod.costoId = costo_id;
            dprod.ventaId = venta_id;
            db.detalle_produccion.Add(dprod);
            db.SaveChanges();

            //prueba que se ingrese
            int dprod_cambiadas = db.detalle_produccion.Count();
            Assert.AreEqual(dprod_originales + 1, dprod_cambiadas);


            detalle_produccion dprod2 = new detalle_produccion();
            int detalle_agregado = db.detalle_produccion.OrderByDescending(x => x.Id).First().Id;
            dprod2 = db.detalle_produccion.Find(Convert.ToInt16(detalle_agregado));
            //Prueba de buscar
            Assert.AreEqual(dprod2.cabecera_produccionId, cabecera_produccion_id);

            db.detalle_produccion.Remove(dprod2);
            db.SaveChanges();
            int dprod_cambiadas_eliminacion = db.detalle_produccion.Count();
            //Prueba si se eliminó
            Assert.AreEqual(dprod_cambiadas - 1, dprod_cambiadas_eliminacion);
        }

    }
}
