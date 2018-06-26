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
    public class precioVentaTest
    {
        pan_dbEntities db = new pan_dbEntities();
        String nombre_articulo = "";
        int testId = 1;
        String fechaVenta = ""+DateTime.Now; 


        [TestMethod]
        public void insercionPrecioVenta()
        {
            int ln_originales = db.precio_venta.Count();
            precio_venta ln = new precio_venta();
            ln.cabecera_recetaId = 1;
            ln.fecha = Convert.ToDateTime(fechaVenta);
            ln.valor = 1;
            db.precio_venta.Add(ln);
            db.SaveChanges();

            int ln_cambiadas = db.precio_venta.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);
            db.precio_venta.Remove(ln);
            db.SaveChanges();
        }

        [TestMethod]
        public void eliminarPrecioVenta()
        {
            precio_venta ln = new precio_venta();
            int ln_originales = db.precio_venta.Count();
            ln.cabecera_recetaId = 1;
            ln.fecha = Convert.ToDateTime(fechaVenta);
            ln.valor = 1;
            db.precio_venta.Add(ln);
            db.SaveChanges();
            db.precio_venta.Remove(ln);
            db.SaveChanges();
            int ln_cambiadas = db.precio_venta.Count();
            Assert.AreEqual(ln_cambiadas, ln_originales);
        }

        [TestMethod]
        public void multiplePrecioVenta()
        {
            // insertar
            precio_venta ln = new precio_venta();
            int ln_originales = db.precio_venta.Count();
            ln.cabecera_recetaId = 1;
            ln.fecha = Convert.ToDateTime(fechaVenta);
            ln.valor = 1;
            db.precio_venta.Add(ln);
            db.SaveChanges();

            //prueba que se ingrese
            int ln_cambiadas = db.precio_venta.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);
            db.precio_venta.Remove(ln);
            db.SaveChanges();

            precio_venta ln2 = new precio_venta();
            int nuevo_valor = 2;
            ln2.cabecera_recetaId = 1;
            ln2.fecha = Convert.ToDateTime(fechaVenta);
            ln2.valor = nuevo_valor;
            db.precio_venta.Add(ln2);
            db.SaveChanges();
            //Prueba de buscar
            Assert.AreEqual(ln2.valor, nuevo_valor);

            db.precio_venta.Remove(ln2);
            db.SaveChanges();
            int ln_cambiadas_eliminacion = db.precio_venta.Count();
            //Prueba si se eliminó
            Assert.AreEqual(ln_cambiadas - 1, ln_cambiadas_eliminacion);
        }

    }
}
